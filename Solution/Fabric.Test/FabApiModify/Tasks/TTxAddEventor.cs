using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddEventor : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',_TP0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(Eventor).Name+"Id:_TP1,"+
				"DateTime:_TP2"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP3);"+
			"g.V('"+typeof(Factor).Name+"Id',_TP4)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V2,_V1,_TP5);"+
			"g.V('"+typeof(EventorType).Name+"Id',_TP6)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,_TP7);"+
			"g.V('"+typeof(EventorPrecision).Name+"Id',_TP8)[0].each{_V4=g.v(it)};"+
			"g.addEdge(_V1,_V4,_TP9);";

		private long vEveTypeId;
		private long vEvePrecId;
		private long vDateTime;
		private long vNewEventorId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vEveTypeId = 9;
			vEvePrecId = 935823;
			vDateTime = 253125123523;
			vNewEventorId = 346137173314;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Eventor>()).Returns(vNewEventorId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Eventor> elemVar;
			var f = new Factor { FactorId = 132414 };

			Tasks.TxAddEventor(MockApiCtx.Object, TxBuild,
				vEveTypeId, vEvePrecId, vDateTime, f, out elemVar);
			FinishTx();

			Assert.NotNull(elemVar, "ElemVar should not be null.");
			Assert.AreEqual("_V1", elemVar.Name, "Incorrect ElemVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", 0);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vNewEventorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vDateTime);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3",
				typeof(RootContainsEventor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", f.FactorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5",
				typeof(FactorUsesEventor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", vEveTypeId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7",
				typeof(EventorUsesEventorType).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP8", vEvePrecId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP9",
				typeof(EventorUsesEventorPrecision).Name);
		}

	}

}