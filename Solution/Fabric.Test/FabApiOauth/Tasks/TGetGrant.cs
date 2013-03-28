﻿using System;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetGrant {

		private readonly static string QueryGetAndUpdateTx =
			"_V0=[];"+
			"g.V('RootId',_TP0)[0]"+
				".outE('"+typeof(RootContainsOauthGrant).Name+"').inV"+
					".has('Code',Tokens.T.eq,_TP1)"+
					".has('Expires',Tokens.T.gt,_TP2)"+
					".aggregate(_V0)"+
					".as('step6')"+
				".outE('"+typeof(OauthGrantUsesApp).Name+"').inV"+
					".aggregate(_V0)"+
				".back('step6')"+
				".outE('"+typeof(OauthGrantUsesUser).Name+"').inV"+
					".aggregate(_V0)"+
				".back('step6')"+
					".sideEffect{"+
						"it.setProperty('Code',_TP3)"+
					"}"+
					".iterate();"+
			"_V0;";

		private OauthGrant vResultGrant;
		private App vResultApp;
		private User vResultUser;
		private DateTime vUtcNow;
		private Mock<IApiContext> vMockCtx;
		private Mock<IApiDataAccess> vMockGetAndUpdateTxResult;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vUtcNow = DateTime.UtcNow;
			vUsageMap = new UsageMap();
			
			vResultGrant = new OauthGrant();
			vResultGrant.Id = 99;
			vResultGrant.OauthGrantId = 123;
			vResultGrant.Code = "abcdefghijklmnopqrstuvwxyz789012";
			vResultGrant.RedirectUri = "test.com/redir";
			
			vResultApp = new App();
			vResultApp.AppId = 456;
			
			vResultUser = new User();
			vResultUser.UserId = 9878;

			vMockGetAndUpdateTxResult = new Mock<IApiDataAccess>();
			vMockGetAndUpdateTxResult.Setup(x => x.GetResultAt<OauthGrant>(0)).Returns(vResultGrant);
			vMockGetAndUpdateTxResult.Setup(x => x.GetResultAt<App>(1)).Returns(vResultApp);
			vMockGetAndUpdateTxResult.Setup(x => x.GetResultAt<User>(2)).Returns(vResultUser);
			vMockGetAndUpdateTxResult.Setup(x => x.GetResultCount()).Returns(3);

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);

			vMockCtx
				.Setup(x => x.DbData(
					GetGrant.Query.GetAndUpdateTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => GetAndUpdateTx(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private GrantResult TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetGrant(vResultGrant.Code, vMockCtx.Object);
			}

			var task = new GetGrant(vResultGrant.Code);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess GetAndUpdateTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(GetGrant.Query.GetAndUpdateTx+"");

			Assert.AreEqual(QueryGetAndUpdateTx, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", 0);
			TestUtil.CheckParam(pTx.Params, "_TP1", vResultGrant.Code);
			TestUtil.CheckParam(pTx.Params, "_TP2", vUtcNow.Ticks);
			TestUtil.CheckParam(pTx.Params, "_TP3", "");

			return vMockGetAndUpdateTxResult.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			GrantResult result = TestGo(pViaTask);

			vUsageMap.AssertUses(GetGrant.Query.GetAndUpdateTx+"", 1);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vResultGrant.OauthGrantId, result.GrantId, "Incorrect Result.GrantId.");
			Assert.AreEqual(vResultGrant.Code, result.Code, "Incorrect Result.AccessToken.");
			Assert.AreEqual(vResultGrant.RedirectUri, result.RedirectUri,
				"Incorrect Result.RedirectUri.");
			Assert.AreEqual(vResultApp.AppId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vResultUser.UserId, result.UserId, "Incorrect Result.UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1)]
		[TestCase(0)]
		public void NotFound(int pCount) {
			vMockGetAndUpdateTxResult.Setup(x => x.GetResultCount()).Returns(pCount);

			GrantResult result = TestGo();

			vUsageMap.AssertUses(GetGrant.Query.GetAndUpdateTx+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullCode() {
			vResultGrant.Code = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}