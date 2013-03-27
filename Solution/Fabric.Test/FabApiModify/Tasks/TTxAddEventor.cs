using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddEventor : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(Eventor).Name+"Id:{{NewEventorId}}L,"+
				"DateTime:{{DateTime}}L"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP0);"+
			"g.V('"+typeof(Factor).Name+"Id',{{FactorId}}L)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V2,_V1,_TP1);"+
			"g.V('"+typeof(EventorType).Name+"Id',{{EveTypeId}}L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,_TP2);"+
			"g.V('"+typeof(EventorPrecision).Name+"Id',{{EvePrecId}}L)[0].each{_V4=g.v(it)};"+
			"g.addEdge(_V1,_V4,_TP3);";

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

			string expect = Query
				.Replace("{{NewEventorId}}", vNewEventorId+"")
				.Replace("{{DateTime}}", vDateTime+"")
				.Replace("{{FactorId}}", f.FactorId+"")
				.Replace("{{EveTypeId}}", vEveTypeId+"")
				.Replace("{{EvePrecId}}", vEvePrecId+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0",
				typeof(RootContainsEventor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1",
				typeof(FactorUsesEventor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2",
				typeof(EventorUsesEventorType).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3",
				typeof(EventorUsesEventorPrecision).Name);
		}

	}

}