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
	public class TGetRefresh {

		private const string QueryGetAccessTx =
			"_V0=[];"+
			"g.V('"+PropDbName.Node_FabType+"',_TP)"+
				".has('"+PropDbName.OauthAccess_Refresh+"',Tokens.T.eq,_TP)"+
				".has('"+PropDbName.OauthAccess_IsClientOnly+"',Tokens.T.eq,_TP)"+
				".as('step3')"+
			".outE('"+RelDbName.OauthAccessUsesApp+"').inV"+
				".aggregate(_V0)"+
			".back('step3')"+
			".outE('"+RelDbName.OauthAccessUsesUser+"').inV"+
				".aggregate(_V0)"+
				".iterate();"+
			"_V0;";

		private string vRefToken;
		private App vResultApp;
		private User vResultUser;
		private Mock<IApiContext> vMockCtx;
		private Mock<IApiDataAccess> vMockGetAccessTxResult;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vRefToken = "abcdefghijklmnopqrstuvwxyz789012";
			vUsageMap = new UsageMap();
			
			vResultApp = new App();
			vResultApp.ArtifactId = 456;
			
			vResultUser = new User();
			vResultUser.ArtifactId = 9878;

			vMockGetAccessTxResult = new Mock<IApiDataAccess>();
			vMockGetAccessTxResult.Setup(x => x.GetResultAt<App>(0)).Returns(vResultApp);
			vMockGetAccessTxResult.Setup(x => x.GetResultAt<User>(1)).Returns(vResultUser);
			vMockGetAccessTxResult.Setup(x => x.GetResultCount()).Returns(2);

			vMockCtx = new Mock<IApiContext>();
			vMockCtx
				.Setup(x => x.DbData(
					GetRefresh.Query.GetAppUserTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => GetAccessTx(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private RefreshResult TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetRefresh(vRefToken, vMockCtx.Object);
			}

			var task = new GetRefresh(vRefToken);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess GetAccessTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(GetRefresh.Query.GetAppUserTx+"");

			string expect = TestUtil.InsertParamIndexes(QueryGetAccessTx, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pTx.Params, "_TP", new object[] {
				(int)NodeFabType.OauthAccess,
				vRefToken,
				false
			});

			return vMockGetAccessTxResult.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			RefreshResult result = TestGo(pViaTask);

			vUsageMap.AssertUses(GetRefresh.Query.GetAppUserTx+"", 1);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vResultApp.ArtifactId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vResultUser.ArtifactId, result.UserId, "Incorrect Result.UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1)]
		[TestCase(0)]
		public void NotFound(int pCount) {
			vMockGetAccessTxResult.Setup(x => x.GetResultCount()).Returns(pCount);

			RefreshResult result = TestGo();

			vUsageMap.AssertUses(GetRefresh.Query.GetAppUserTx+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullCode() {
			vRefToken = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}