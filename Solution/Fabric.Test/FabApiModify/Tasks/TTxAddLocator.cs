﻿using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddLocator : TModifyTasks {

		private static readonly string Query = 
			"_V1=g.addVertex(["+
				typeof(Locator).Name+"Id:_TP1,"+
				"ValueX:_TP2,"+
				"ValueY:_TP3,"+
				"ValueZ:_TP4,"+
				"FabType:_TP5"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP6);"+
			"_V2=g.V('"+typeof(Factor).Name+"Id',_TP7)[0].next();"+
			"g.addEdge(_V2,_V1,_TP8);"+
			"_V3=g.V('"+typeof(LocatorType).Name+"Id',_TP9)[0].next();"+
			"g.addEdge(_V1,_V3,_TP10);";

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

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", 0);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vNewLocatorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vValueX);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", vValueY);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", vValueZ);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", (int)NodeFabType.Locator);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", f.FactorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP8",
				typeof(FactorUsesLocator).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP9", vLocTypeId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP10",
				typeof(LocatorUsesLocatorType).Name);
		}

	}

}