using Fabric.Domain;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddVector : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(Vector).Name+"Id:{{NewVectorId}}L,"+
				"Value:{{Value}}L"+
			"]);"+
			"g.addEdge(_V0,_V1,'"+typeof(RootContainsVector).Name+"');"+
			"g.V('"+typeof(Factor).Name+"Id',{{FactorId}}L)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V2,_V1,'"+typeof(FactorUsesVector).Name+"');"+
			"g.V('"+typeof(VectorType).Name+"Id',{{VecTypeId}}L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,'"+typeof(VectorUsesVectorType).Name+"');"+
			"g.V('"+typeof(Artifact).Name+"Id',{{AxisArtId}}L)[0].each{_V4=g.v(it)};"+
			"g.addEdge(_V1,_V4,'"+typeof(VectorUsesAxisArtifact).Name+"');"+
			"g.V('"+typeof(VectorUnit).Name+"Id',{{VecUnitId}}L)[0].each{_V5=g.v(it)};"+
			"g.addEdge(_V1,_V5,'"+typeof(VectorUsesVectorUnit).Name+"');"+
			"g.V('"+typeof(VectorUnitPrefix).Name+"Id',{{VecUnitPrefId}}L)[0].each{_V6=g.v(it)};"+
			"g.addEdge(_V1,_V6,'"+typeof(VectorUsesVectorUnitPrefix).Name+"');";

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

			string expect = Query
				.Replace("{{NewVectorId}}", vNewVectorId+"")
				.Replace("{{FactorId}}", f.FactorId+"")
				.Replace("{{VecTypeId}}", vVecTypeId+"")
				.Replace("{{Value}}", vValue+"")
				.Replace("{{AxisArtId}}", vAxisArtId+"")
				.Replace("{{VecUnitId}}", vVecUnitId+"")
				.Replace("{{VecUnitPrefId}}", vVecUnitPrefId+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
		}

	}

}