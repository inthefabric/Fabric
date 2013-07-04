using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorVector : TModifyTasks {

		private const string Query = 
			"_F=g.V('"+PropDbName.Factor_FactorId+"',_TP)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Vector_TypeId+"',_TP);"+
					"it.setProperty('"+PropDbName.Factor_Vector_UnitId+"',_TP);"+
					"it.setProperty('"+PropDbName.Factor_Vector_UnitPrefixId+"',_TP);"+
					"it.setProperty('"+PropDbName.Factor_Vector_Value+"',_TP);"+
				"}"+
				".next();"+
			"_V1=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			
			"_PROP=[:];"+
			"_TRY=[F_Fa:_F,F_Df:_F,F_Cr:_F,F_DeT:_F,F_DiT:_F,F_DiP:_F,F_DiR:_F,F_EvT:_F,F_EvP:_F,"+
				"F_EvD:_F,F_IdT:_F,F_IdV:_F,F_LoT:_F,F_LoX:_F,F_LoY:_F,F_LoZ:_F,F_VeT:_F,F_VeU:_F,"+
				"F_VeP:_F,F_VeV:_F,A_Cr:_V1];"+
			TestUtil.TryPropScript+
			"g.addEdge(_F,_V1,_TP,_PROP);";

		private Factor vFactor;
		private byte vVecTypeId;
		private long vValue;
		private long vAxisArtId;
		private byte vVecUnitId;
		private byte vVecUnitPrefId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vVecTypeId = 9;
			vValue = 987654;
			vAxisArtId = 123525;
			vVecUnitId = 235;
			vVecUnitPrefId = 132;

			var mda = MockDataAccess.Create(OnExecute);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vFactor.FactorId,
				vVecTypeId,
				vVecUnitId,
				vVecUnitPrefId,
				vValue,
				vAxisArtId,
				EdgeDbName.FactorVectorUsesAxisArtifact
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Update() {
			Tasks.UpdateFactorVector(MockApiCtx.Object, vFactor, vVecTypeId, vValue, vAxisArtId,
				vVecUnitId, vVecUnitPrefId);
			AssertDataExecution(true);
		}

	}

}