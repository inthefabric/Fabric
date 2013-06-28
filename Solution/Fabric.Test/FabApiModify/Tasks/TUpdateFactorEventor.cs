using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorEventor : TModifyTasks {

		private const string Query = 
			"g.V('"+PropDbName.Factor_FactorId+"',_P)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Eventor_TypeId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Eventor_PrecisionId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Eventor_DateTime+"',_P);"+
				"};";

		private Factor vFactor;
		private byte vEveTypeId;
		private byte vEvePrecId;
		private long vDateTime;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vEveTypeId = 9;
			vEvePrecId = 23;
			vDateTime = 253125123523;

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
				vEveTypeId,
				vEvePrecId,
				vDateTime
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Update() {
			Tasks.UpdateFactorEventor(MockApiCtx.Object, vFactor, vEveTypeId, vEvePrecId, vDateTime);
			AssertDataExecution(true);
		}

	}

}