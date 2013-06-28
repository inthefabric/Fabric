using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorLocator : TModifyTasks {

		private const string Query = 
			"g.V('"+PropDbName.Factor_FactorId+"',_P)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Locator_TypeId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Locator_ValueX+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Locator_ValueY+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Locator_ValueZ+"',_P);"+
				"};";

		private Factor vFactor;
		private byte vLocTypeId;
		private double vValueX;
		private double vValueY;
		private double vValueZ;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vLocTypeId = 9;
			vValueX = 1.34236;
			vValueY = 99.52352;
			vValueZ = 37.023983;

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
				vLocTypeId,
				vValueX,
				vValueY,
				vValueZ,
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Update() {
			Tasks.UpdateFactorLocator(MockApiCtx.Object, vFactor, vLocTypeId, vValueX, vValueY,vValueZ);
			AssertDataExecution(true);
		}

	}

}