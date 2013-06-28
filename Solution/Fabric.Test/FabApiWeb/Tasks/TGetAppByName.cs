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
	public class TGetAppByName : TWebTasks {

		private const string Query = "g.V('"+PropDbName.App_NameKey+"',_P0);";

		private string vName;
		private App vAppResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Test App";

			vAppResult = new App();
			vAppResult.Name = vName;

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vAppResult);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vName.ToLower());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			App result = Tasks.GetAppByName(MockApiCtx.Object, vName);

			AssertDataExecution(true);
			Assert.AreEqual(vAppResult, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Failure() {
			vAppResult.Name = vName+" Extra Tokens";

			App result = Tasks.GetAppByName(MockApiCtx.Object, vName);

			AssertDataExecution(true);
			Assert.Null(result, "Incorrect Result.");
		}

	}

}