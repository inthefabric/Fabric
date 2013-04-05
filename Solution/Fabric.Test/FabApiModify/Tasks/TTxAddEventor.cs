using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddEventor : TModifyTasks {

		private static readonly string Query = 
			"_V0=g.addVertex(["+
				typeof(Eventor).Name+"Id:_TP,"+
				"DateTime:_TP,"+
				"FabType:_TP"+
			"]);"+
			"_V1=g.V('"+typeof(Factor).Name+"Id',_TP).next();"+
			"g.addEdge(_V1,_V0,_TP);"+
			"_V2=g.V('"+typeof(EventorType).Name+"Id',_TP).next();"+
			"g.addEdge(_V0,_V2,_TP);"+
			"_V3=g.V('"+typeof(EventorPrecision).Name+"Id',_TP).next();"+
			"g.addEdge(_V0,_V3,_TP);";

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
			Assert.AreEqual("_V0", elemVar.Name, "Incorrect ElemVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewEventorId,
				vDateTime,
				(int)NodeFabType.Eventor,
				f.FactorId,
				typeof(FactorUsesEventor).Name,
				vEveTypeId,
				typeof(EventorUsesEventorType).Name,
				vEvePrecId,
				typeof(EventorUsesEventorPrecision).Name
			});
		}

	}

}