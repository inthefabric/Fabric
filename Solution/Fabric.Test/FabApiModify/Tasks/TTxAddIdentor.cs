using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddIdentor : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',_TP0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(Identor).Name+"Id:_TP1,"+
				"Value:_TP2"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP3);"+
			"g.V('"+typeof(Factor).Name+"Id',_TP4)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V2,_V1,_TP5);"+
			"g.V('"+typeof(IdentorType).Name+"Id',_TP6)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,_TP7);";

		private long vIdenTypeId;
		private string vValue;
		private long vNewIdentorId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vIdenTypeId = 9;
			vValue = "my unique value";
			vNewIdentorId = 346137173314;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Identor>()).Returns(vNewIdentorId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Identor> elemVar;
			var f = new Factor { FactorId = 132414 };

			Tasks.TxAddIdentor(MockApiCtx.Object, TxBuild, vIdenTypeId, vValue, f, out elemVar);
			FinishTx();

			Assert.NotNull(elemVar, "ElemVar should not be null.");
			Assert.AreEqual("_V1", elemVar.Name, "Incorrect ElemVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", 0);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vNewIdentorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vValue);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3",
				typeof(RootContainsIdentor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", f.FactorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5",
				typeof(FactorUsesIdentor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", vIdenTypeId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7",
				typeof(IdentorUsesIdentorType).Name);
		}

	}

}