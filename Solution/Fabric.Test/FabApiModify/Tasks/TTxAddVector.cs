using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddVector : TModifyTasks {

		private static readonly string Query = 
			"_V0=g.addVertex(["+
				typeof(Vector).Name+"Id:_TP,"+
				"Value:_TP,"+
				"FabType:_TP"+
			"]);"+
			"_V1=g.V('"+typeof(Factor).Name+"Id',_TP).next();"+
			"g.addEdge(_V1,_V0,_TP);"+
			"_V2=g.V('"+typeof(VectorType).Name+"Id',_TP).next();"+
			"g.addEdge(_V0,_V2,_TP);"+
			"_V3=g.V('"+typeof(Artifact).Name+"Id',_TP).next();"+
			"g.addEdge(_V0,_V3,_TP);"+
			"_V4=g.V('"+typeof(VectorUnit).Name+"Id',_TP).next();"+
			"g.addEdge(_V0,_V4,_TP);"+
			"_V5=g.V('"+typeof(VectorUnitPrefix).Name+"Id',_TP).next();"+
			"g.addEdge(_V0,_V5,_TP);";

		private long vVecTypeId;
		private long vValue;
		private long vAxisArtId;
		private long vVecUnitId;
		private long vVecUnitPrefId;
		private long vNewVectorId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vVecTypeId = 9;
			vValue = 987654;
			vAxisArtId = 123525;
			vVecUnitId = 5325235;
			vVecUnitPrefId = 32525;
			vNewVectorId = 346137173314;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Vector>()).Returns(vNewVectorId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Vector> elemVar;
			var f = new Factor { FactorId = 132414 };

			Tasks.TxAddVector(MockApiCtx.Object, TxBuild, vVecTypeId, vValue, vAxisArtId,
				vVecUnitId, vVecUnitPrefId, f, out elemVar);
			FinishTx();

			Assert.NotNull(elemVar, "ElemVar should not be null.");
			Assert.AreEqual("_V0", elemVar.Name, "Incorrect ElemVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewVectorId,
				vValue,
				(int)NodeFabType.Vector,
				f.FactorId,
				typeof(FactorUsesVector).Name,
				vVecTypeId,
				typeof(VectorUsesVectorType).Name,
				vAxisArtId,
				typeof(VectorUsesAxisArtifact).Name,
				vVecUnitId,
				typeof(VectorUsesVectorUnit).Name,
				vVecUnitPrefId,
				typeof(VectorUsesVectorUnitPrefix).Name,
			});
		}

	}

}