using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Test.Common;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateUserPassword : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.User_Password+"',_P1);"+
				"};";

		private long vUserId;
		private string vPassword;
		private User vUserResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vUserId = 3456;
			vPassword = "MyTestPass";
			vUserResult = new User();

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vUserResult);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vUserId);
			TestUtil.CheckParam(cmd.Params, "_P1", FabricUtil.HashPassword(vPassword));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			User result = Tasks.UpdateUserPassword(MockApiCtx.Object, vUserId, vPassword);

			AssertDataExecution(true);
			Assert.AreEqual(vUserResult, result, "Incorrect Result.");
		}

	}

}