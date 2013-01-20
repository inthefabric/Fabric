﻿using System;
using System.Collections.Generic;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
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
			"g.V('RootId',0)[0]"+
				".outE('"+typeof(RootContainsOauthGrant).Name+"').inV"+
					".has('Code',Tokens.T.eq,_TP0)"+
					".has('Expires',Tokens.T.gt,{{UtcNowTicks}}L)"+
					".aggregate(_V0)"+
					".as('step6')"+
				".outE('"+typeof(OauthGrantUsesApp).Name+"').inV"+
					".aggregate(_V0)"+
				".back('step6')"+
				".outE('"+typeof(OauthGrantUsesUser).Name+"').inV"+
					".aggregate(_V0)"+
				".back('step6')"+
					".each{it.setProperty('Code',_TP1)};"+
			"_V0;";

		private OauthGrant vOauthGrant;
		private App vUsesApp;
		private User vUsesUser;
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
			
			vOauthGrant = new OauthGrant();
			vOauthGrant.Id = 99;
			vOauthGrant.OauthGrantId = 123;
			vOauthGrant.Code = "abcdefghijklmnopqrstuvwxyz789012";
			vOauthGrant.RedirectUri = "test.com/redir";
			
			vUsesApp = new App();
			vUsesApp.AppId = 456;
			
			vUsesUser = new User();
			vUsesUser.UserId = 9878;
			
			var mockGrantDbDto = new Mock<IDbDto>();
			mockGrantDbDto.Setup(x => x.ToNode<OauthGrant>()).Returns(vOauthGrant);
			
			var mockAppDbDto = new Mock<IDbDto>();
			mockAppDbDto.Setup(x => x.ToNode<App>()).Returns(vUsesApp);
			
			var mockUserDbDto = new Mock<IDbDto>();
			mockUserDbDto.Setup(x => x.ToNode<User>()).Returns(vUsesUser);
			
			var list = new List<IDbDto>();
			list.Add(mockGrantDbDto.Object);
			list.Add(mockAppDbDto.Object);
			list.Add(mockUserDbDto.Object);
			
			vMockGetAndUpdateTxResult = new Mock<IApiDataAccess>();
			vMockGetAndUpdateTxResult.SetupGet(x => x.ResultDtoList).Returns(list);

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
				return new OauthTasks().GetGrant(vOauthGrant.Code, vMockCtx.Object);
			}

			var task = new GetGrant(vOauthGrant.Code);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess GetAndUpdateTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(GetGrant.Query.GetAndUpdateTx+"");
			string expect = QueryGetAndUpdateTx
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"");

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", vOauthGrant.Code);
			TestUtil.CheckParam(pTx.Params, "_TP1", "");

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
			Assert.AreEqual(vOauthGrant.OauthGrantId, result.GrantId, "Incorrect Result.GrantId.");
			Assert.AreEqual(vOauthGrant.Code, result.Code, "Incorrect Result.AccessToken.");
			Assert.AreEqual(vOauthGrant.RedirectUri, result.RedirectUri,
				"Incorrect Result.RedirectUri.");
			Assert.AreEqual(vUsesApp.AppId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vUsesUser.UserId, result.UserId, "Incorrect Result.UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase(0)]
		public void NotFound(int? pLen) {
			IList<IDbDto> list = null;
			if ( pLen == 0 ) { list = new List<IDbDto>(); }
			vMockGetAndUpdateTxResult.SetupGet(x => x.ResultDtoList).Returns(list);

			GrantResult result = TestGo();

			vUsageMap.AssertUses(GetGrant.Query.GetAndUpdateTx+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullCode() {
			vOauthGrant.Code = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}