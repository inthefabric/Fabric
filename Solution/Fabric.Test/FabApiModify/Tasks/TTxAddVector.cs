using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddVector : TModifyTasks {

		private static readonly string Query = 
			"_V1=g.addVertex(["+
				typeof(Vector).Name+"Id:_TP1,"+
				"Value:_TP2,"+
				"FabType:_TP3"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP4);"+
			"_V2=g.V('"+typeof(Factor).Name+"Id',_TP5)[0].next();"+
			"g.addEdge(_V2,_V1,_TP6);"+
			"_V3=g.V('"+typeof(VectorType).Name+"Id',_TP7)[0].next();"+
			"g.addEdge(_V1,_V3,_TP8);"+
			"_V4=g.V('"+typeof(Artifact).Name+"Id',_TP9)[0].next();"+
			"g.addEdge(_V1,_V4,_TP10);"+
			"_V5=g.V('"+typeof(VectorUnit).Name+"Id',_TP11)[0].next();"+
			"g.addEdge(_V1,_V5,_TP12);"+
			"_V6=g.V('"+typeof(VectorUnitPrefix).Name+"Id',_TP13)[0].next();"+
			"g.addEdge(_V1,_V6,_TP14);";

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
			Assert.AreEqual("_V1", elemVar.Name, "Incorrect ElemVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", 0);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vNewVectorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vValue);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", (int)NodeFabType.Vector);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", f.FactorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6",
				typeof(FactorUsesVector).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", vVecTypeId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP8",
				typeof(VectorUsesVectorType).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP9", vAxisArtId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP10",
				typeof(VectorUsesAxisArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP11", vVecUnitId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP12",
				typeof(VectorUsesVectorUnit).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP13", vVecUnitPrefId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP14",
				typeof(VectorUsesVectorUnitPrefix).Name);
		}

	}

}