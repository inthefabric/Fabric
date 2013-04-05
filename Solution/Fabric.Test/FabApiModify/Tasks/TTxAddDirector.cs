using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddDirector : TModifyTasks {

		private static readonly string Query = 
			"_V0=g.addVertex(["+
				typeof(Director).Name+"Id:_TP,"+
				"FabType:_TP"+
			"]);"+
			"_V1=g.V('"+typeof(Factor).Name+"Id',_TP)[0].next();"+
			"g.addEdge(_V1,_V0,_TP);"+
			"_V2=g.V('"+typeof(DirectorType).Name+"Id',_TP)[0].next();"+
			"g.addEdge(_V0,_V2,_TP);"+
			"_V3=g.V('"+typeof(DirectorAction).Name+"Id',_TP)[0].next();"+
			"g.addEdge(_V0,_V3,_TP);"+
			"_V4=g.V('"+typeof(DirectorAction).Name+"Id',_TP)[0].next();"+
			"g.addEdge(_V0,_V4,_TP);";

		private long vDirTypeId;
		private long vPrimActId;
		private long vRelActId;
		private long vNewDirectorId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vDirTypeId = 9;
			vPrimActId = 935823;
			vRelActId = 25323;
			vNewDirectorId = 346137173314;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Director>()).Returns(vNewDirectorId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Director> elemVar;
			var f = new Factor { FactorId = 132414 };

			Tasks.TxAddDirector(MockApiCtx.Object, TxBuild,
				vDirTypeId, vPrimActId, vRelActId, f, out elemVar);
			FinishTx();

			Assert.NotNull(elemVar, "ElemVar should not be null.");
			Assert.AreEqual("_V0", elemVar.Name, "Incorrect ElemVar name.");

			string expect = Query
				.Replace("{{NewDirectorId}}", vNewDirectorId+"")
				.Replace("{{FactorId}}", f.FactorId+"")
				.Replace("{{DirTypeId}}", vDirTypeId+"")
				.Replace("{{PrimActId}}", vPrimActId+"")
				.Replace("{{RelActId}}", vRelActId+"");

			expect = TestUtil.InsertParamIndexes(expect, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewDirectorId,
				(int)NodeFabType.Director,
				f.FactorId,
				typeof(FactorUsesDirector).Name,
				vDirTypeId,
				typeof(DirectorUsesDirectorType).Name,
				vPrimActId,
				typeof(DirectorUsesPrimaryDirectorAction).Name,
				vRelActId,
				typeof(DirectorUsesRelatedDirectorAction).Name
			});
		}

	}

}