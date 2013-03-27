using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddDirector : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(Director).Name+"Id:{{NewDirectorId}}L"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP0);"+
			"g.V('"+typeof(Factor).Name+"Id',{{FactorId}}L)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V2,_V1,_TP1);"+
			"g.V('"+typeof(DirectorType).Name+"Id',{{DirTypeId}}L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,_TP2);"+
			"g.V('"+typeof(DirectorAction).Name+"Id',{{PrimActId}}L)[0].each{_V4=g.v(it)};"+
			"g.addEdge(_V1,_V4,_TP3);"+
			"g.V('"+typeof(DirectorAction).Name+"Id',{{RelActId}}L)[0].each{_V5=g.v(it)};"+
			"g.addEdge(_V1,_V5,_TP4);";

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
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0",
				typeof(RootContainsDirector).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1",
				typeof(FactorUsesDirector).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2",
				typeof(DirectorUsesDirectorType).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3",
				typeof(DirectorUsesPrimaryDirectorAction).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4",
				typeof(DirectorUsesRelatedDirectorAction).Name);
		}

	}

}