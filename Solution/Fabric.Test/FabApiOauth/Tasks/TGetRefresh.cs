using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetRefresh : TTestBase {

		private const string QueryGetAccessTx =
			"_V0=[];"+
			"g.V('"+PropDbName.OauthAccess_Refresh+"',_TP)"+
				".has('"+PropDbName.OauthAccess_IsClientOnly+"',Tokens.T.eq,_TP)"+
				".as('step4')"+
			".outE('"+EdgeDbName.OauthAccessUsesApp+"').inV"+
				".aggregate(_V0)"+
			".back('step4')"+
			".outE('"+EdgeDbName.OauthAccessUsesUser+"').inV"+
				".aggregate(_V0)"+
				".iterate();"+
			"_V0;";

		private string vRefToken;
		private App vResultApp;
		private User vResultUser;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vRefToken = "abcdefghijklmnopqrstuvwxyz789012";
			
			vResultApp = new App();
			vResultApp.ArtifactId = 456;
			
			vResultUser = new User();
			vResultUser.ArtifactId = 9878;

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.Setup(x => x.GetCommandResultCount(0)).Returns(2);
			mda.MockResult.Setup(x => x.ToElementAt<App>(0,0)).Returns(vResultApp);
			mda.MockResult.Setup(x => x.ToElementAt<User>(0,1)).Returns(vResultUser);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private RefreshResult TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetRefresh(vRefToken, MockApiCtx.Object);
			}

			var task = new GetRefresh(vRefToken);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = TestUtil.InsertParamIndexes(QueryGetAccessTx, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vRefToken,
				false
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			RefreshResult result = TestGo(pViaTask);

			AssertDataExecution(true);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vResultApp.ArtifactId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vResultUser.ArtifactId, result.UserId, "Incorrect Result.UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1)]
		[TestCase(0)]
		public void NotFound(int pCount) {
			MockDataList[0].MockResult.Setup(x => x.GetCommandResultCount(0)).Returns(pCount);

			RefreshResult result = TestGo();

			AssertDataExecution(true);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullCode() {
			vRefToken = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

	}

}