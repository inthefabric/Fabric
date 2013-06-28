using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorIdentor : TModifyTasks {

		private const string Query = 
			"g.V('"+PropDbName.Factor_FactorId+"',_P)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Identor_TypeId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Identor_Value+"',_P);"+
				"};";

		private Factor vFactor;
		private byte vIdenTypeId;
		private string vValue;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vIdenTypeId = 9;
			vValue = "my unique value";

			var mda = MockDataAccess.Create(OnExecute);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = TestUtil.InsertParamIndexes(Query, "_P");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_P", new object[] {
				vFactor.FactorId,
				vIdenTypeId,
				vValue
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Update() {
			Tasks.UpdateFactorIdentor(MockApiCtx.Object, vFactor, vIdenTypeId, vValue);
			AssertDataExecution(true);
		}

	}

}