using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetUrlByPath : TModifyTasks {

		private const string Query = "g.V('"+PropDbName.Url_Path+"',_P0);";

		private string vPath;
		private Url vUrlResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vPath = "http://www.DUPlicate.com";
			vUrlResult = new Url();

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vUrlResult);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vPath.ToLower());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Url result = Tasks.GetUrlByPath(MockApiCtx.Object, vPath);

			AssertDataExecution(true);
			Assert.AreEqual(vUrlResult, result, "Incorrect Result.");
		}

	}

}