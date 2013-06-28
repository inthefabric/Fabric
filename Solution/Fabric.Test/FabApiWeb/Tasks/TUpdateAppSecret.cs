using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Test.Common;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateAppSecret : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.App_Secret+"',_P1);"+
				"};";

		private long vAppId;
		private string vSecret;
		private App vAppResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vSecret = "abcdefgHIJKLMNOPqrsTUVwxyz12345678";
			vAppResult = new App();

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vAppResult);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			
			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vAppId);
			TestUtil.CheckParam(cmd.Params, "_P1", vSecret);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			App result = Tasks.UpdateAppSecret(MockApiCtx.Object, vAppId, vSecret);

			AssertDataExecution(true);
			Assert.AreEqual(vAppResult, result, "Incorrect Result.");
		}

	}

}