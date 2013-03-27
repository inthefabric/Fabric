using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddLocator : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(Locator).Name+"Id:{{NewLocatorId}}L,"+
				"ValueX:{{X}}D,"+
				"ValueY:{{Y}}D,"+
				"ValueZ:{{Z}}D"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP0);"+
			"g.V('"+typeof(Factor).Name+"Id',{{FactorId}}L)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V2,_V1,_TP1);"+
			"g.V('"+typeof(LocatorType).Name+"Id',{{LocTypeId}}L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,_TP2);";

		private long vLocTypeId;
		private double vValueX;
		private double vValueY;
		private double vValueZ;
		private long vNewLocatorId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vLocTypeId = 9;
			vValueX = 1.34236;
			vValueY = 99.52352;
			vValueZ = 37.023983;
			vNewLocatorId = 346137173314;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Locator>()).Returns(vNewLocatorId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Locator> elemVar;
			var f = new Factor { FactorId = 132414 };

			Tasks.TxAddLocator(MockApiCtx.Object, TxBuild,
				vLocTypeId, vValueX, vValueY, vValueZ, f, out elemVar);
			FinishTx();

			Assert.NotNull(elemVar, "ElemVar should not be null.");
			Assert.AreEqual("_V1", elemVar.Name, "Incorrect ElemVar name.");

			string expect = Query
				.Replace("{{NewLocatorId}}", vNewLocatorId+"")
				.Replace("{{FactorId}}", f.FactorId+"")
				.Replace("{{LocTypeId}}", vLocTypeId+"")
				.Replace("{{X}}", vValueX+"")
				.Replace("{{Y}}", vValueY+"")
				.Replace("{{Z}}", vValueZ+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0",
				typeof(RootContainsLocator).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1",
				typeof(FactorUsesLocator).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2",
				typeof(LocatorUsesLocatorType).Name);
		}

	}

}