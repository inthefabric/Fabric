using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorDirector : TModifyTasks {

		private const string Query = 
			"g.V('"+PropDbName.Factor_FactorId+"',_P)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Director_TypeId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Director_PrimaryActionId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Director_RelatedActionId+"',_P);"+
				"};";

		private Factor vFactor;
		private byte vDirTypeId;
		private byte vPrimActId;
		private byte vEdgeActId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vDirTypeId = 9;
			vPrimActId = 25;
			vEdgeActId = 64;

			var mda = MockDataAccess.Create(OnExecute);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);


			string expect = TestUtil.InsertParamIndexes(Query, "_P").Replace('*', '_');
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_P", new object[] {
				vFactor.FactorId,
				vDirTypeId,
				vPrimActId,
				vEdgeActId
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Update() {
			Tasks.UpdateFactorDirector(MockApiCtx.Object, vFactor, vDirTypeId, vPrimActId, vEdgeActId);
			AssertDataExecution(true);
		}

	}

}