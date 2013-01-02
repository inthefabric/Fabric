using Moq;
using Fabric.Infrastructure.Api;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using NUnit.Framework;
using Weaver.Interfaces;
using Fabric.Domain;
using Fabric.Infrastructure;
using System;
using Fabric.Test.Util;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Api.Oauth.Results;
using System.Collections.Generic;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetGrant {

		private static string[] vQueries = new [] {
			//GetAndUpdateTx
			"g.startTransaction();"+
			"_var0=[];"+
			"g.v(0)"+
				".outE('RootContainsOauthGrant').inV"+
					".has('Code',Tokens.T.eq,_TP0)"+
					".has('Expires',Tokens.T.gt,{{UtcNowTicks}}L)"+
					".aggregate(_var0)"+
					".each{it.Code=null}"+
					".as('step7')"+
				".outE('OauthGrantUsesApp')[0].inV(0)"+
					".aggregate(_var0)"+
				".back('step7')"+
				".outE('OauthGrantUsesUser')[0].inV(0)"+
					".aggregate(_var0)"+
					".iterate();"+
			"g.stopTransaction(TransactionalGraph.Conclusion.SUCCESS);"+
			"_var0;"
		};

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
			string expect = vQueries[(int)GetGrant.Query.GetAndUpdateTx]
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"");

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", vOauthGrant.Code);

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

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void NotFound() {
			vGetAccessResult = null;

			vMockCtx
				.Setup(x => x.DbSingle<OauthAccess>(
					GetAccessToken.Query.GetAccess+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetAccess(q));

			FabOauthAccess result = TestGo();

			vUsageMap.AssertUses(GetAccessToken.Query.GetAccess+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void ErrNullToken() {
			vToken = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

		/*--------------------------------------------------------------------------------------------* /
		[TestCase("")]
		[TestCase("x")]
		[TestCase("1234567890123456789012345678901")]
		[TestCase("123456789012345678901234567890123")]
		public void ErrTokenLen(string pToken) {
			vToken = pToken;
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

		/*--------------------------------------------------------------------------------------------* /
		[TestCase("1234567890123456789012345678901_")]
		[TestCase("123456789 1234567890123456789012")]
		public void ErrTokenChars(string pToken) {
			vToken = pToken;
			TestUtil.CheckThrows<FabArgumentFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}*/

	}

}