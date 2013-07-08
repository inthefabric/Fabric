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
	public class TGetAppAuth : TTestBase {

		private const string QueryGetApp =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
				".has('"+PropDbName.App_Secret+"',Tokens.T.eq,_P1);";

		private long vAppId;
		private string vAppSecret;
		private App vGetAppResult;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 123;
			vAppSecret = "abcdefghijklmnopqrstuvwxyz789012";
			vGetAppResult = new App();
			
			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vGetAppResult);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private App TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetAppAuth(vAppId, vAppSecret, MockApiCtx.Object);
			}

			var task = new GetAppAuth(vAppId, vAppSecret);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			Assert.AreEqual(QueryGetApp, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vAppId);
			TestUtil.CheckParam(cmd.Params, "_P1", vAppSecret);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			App result = TestGo(pViaTask);
			
			AssertDataExecution(true);
			Assert.AreEqual(vGetAppResult, result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			MockDataList[0].MockResult.SetupToElement<App>(null);

			App result = TestGo();

			AssertDataExecution(true);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAppIdRange() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullSecret() {
			vAppSecret = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

	}

}