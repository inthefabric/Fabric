using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddDirector : TModifyTasks {

		private static readonly string Query = 
			"_V0=g.V('"+typeof(Root).Name+"Id',_TP0)[0].next();"+
			"_V1=g.addVertex(["+
				typeof(Director).Name+"Id:_TP1"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP2);"+
			"_V2=g.V('"+typeof(Factor).Name+"Id',_TP3)[0].next();"+
			"g.addEdge(_V2,_V1,_TP4);"+
			"_V3=g.V('"+typeof(DirectorType).Name+"Id',_TP5)[0].next();"+
			"g.addEdge(_V1,_V3,_TP6);"+
			"_V4=g.V('"+typeof(DirectorAction).Name+"Id',_TP7)[0].next();"+
			"g.addEdge(_V1,_V4,_TP8);"+
			"_V5=g.V('"+typeof(DirectorAction).Name+"Id',_TP9)[0].next();"+
			"g.addEdge(_V1,_V5,_TP10);";

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
			Assert.AreEqual("_V1", elemVar.Name, "Incorrect ElemVar name.");

			string expect = Query
				.Replace("{{NewDirectorId}}", vNewDirectorId+"")
				.Replace("{{FactorId}}", f.FactorId+"")
				.Replace("{{DirTypeId}}", vDirTypeId+"")
				.Replace("{{PrimActId}}", vPrimActId+"")
				.Replace("{{RelActId}}", vRelActId+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", 0);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vNewDirectorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2",
				typeof(RootContainsDirector).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", f.FactorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4",
				typeof(FactorUsesDirector).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", vDirTypeId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6",
				typeof(DirectorUsesDirectorType).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", vPrimActId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP8",
				typeof(DirectorUsesPrimaryDirectorAction).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP9", vRelActId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP10",
				typeof(DirectorUsesRelatedDirectorAction).Name);
		}

	}

}