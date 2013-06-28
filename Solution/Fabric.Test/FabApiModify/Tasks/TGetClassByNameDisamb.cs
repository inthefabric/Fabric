using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetClassByNameDisamb : TModifyTasks {

		private const string QueryStart = "g.V('"+PropDbName.Class_NameKey+"',_P0).scatter()";

		private const string QueryNoDisamb = QueryStart+
			".hasNot('"+PropDbName.Class_Disamb+"');";

		private const string QueryDisamb = QueryStart+
			".filter{"+
				"_DI=it.getProperty('"+PropDbName.Class_Disamb+"');"+
				"(_DI && _DI.toLowerCase()==_P1);"+
			"};";

		private string vName;
		private string vDisamb;
		private Class vClassResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Class";
			vDisamb = "The awesome version";
			vClassResult = new Class();

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vClassResult);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			string expect = (vDisamb != null ? QueryDisamb : QueryNoDisamb);

			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vName.ToLower());

			if ( vDisamb != null ) {
				TestUtil.CheckParam(cmd.Params, "_P1", vDisamb.ToLower());
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pNullDisamb) {
			vDisamb = (pNullDisamb ? null : vDisamb);
			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			AssertDataExecution(true);
			Assert.AreEqual(vClassResult, result, "Incorrect Result.");
		}

	}

}