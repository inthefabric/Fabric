using System;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetGrant {

		private const string QueryGetAndUpdateTx =
			"_V0=[];"+
			"g.V('"+PropDbName.Node_FabType+"',_TP)"+
				".has('"+PropDbName.OauthGrant_Code+"',Tokens.T.eq,_TP)"+
				".has('"+PropDbName.OauthGrant_Expires+"',Tokens.T.gt,_TP)"+
				".aggregate(_V0)"+
				".as('step4')"+
			".outE('"+RelDbName.OauthGrantUsesApp+"').inV"+
				".aggregate(_V0)"+
			".back('step4')"+
			".outE('"+RelDbName.OauthGrantUsesUser+"').inV"+
				".aggregate(_V0)"+
			".back('step4')"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.OauthGrant_Code+"',_TP)"+
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
			vResultGrant.Id = "x99";
			vResultGrant.OauthGrantId = 123;
			vResultGrant.Code = "abcdefghijklmnopqrstuvwxyz789012";
			vResultGrant.RedirectUri = "test.com/redir";
			
			vResultApp = new App();
			vResultApp.ArtifactId = 456;
			
			vResultUser = new User();
			vResultUser.ArtifactId = 9878;

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

			string expect = TestUtil.InsertParamIndexes(QueryGetAndUpdateTx, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pTx.Params, "_TP", new object[] {
				(byte)NodeFabType.OauthGrant,
				vResultGrant.Code,
				vUtcNow.Ticks,
				""
			});

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
			Assert.AreEqual(vResultApp.ArtifactId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vResultUser.ArtifactId, result.UserId, "Incorrect Result.UserId.");
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