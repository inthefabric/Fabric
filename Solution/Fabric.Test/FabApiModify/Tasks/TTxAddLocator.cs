using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddLocator : TModifyTasks {

		private static readonly string Query = 
			"_V0=g.addVertex(["+
				typeof(Locator).Name+"Id:_TP,"+
				"ValueX:_TP,"+
				"ValueY:_TP,"+
				"ValueZ:_TP,"+
				"FabType:_TP"+
			"]);"+
			"_V1=g.V('"+typeof(Factor).Name+"Id',_TP).next();"+
			"g.addEdge(_V1,_V0,_TP);"+
			"_V2=g.V('"+typeof(LocatorType).Name+"Id',_TP).next();"+
			"g.addEdge(_V0,_V2,_TP);";

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
			Assert.AreEqual("_V0", elemVar.Name, "Incorrect ElemVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewLocatorId,
				vValueX,
				vValueY,
				vValueZ,
				(int)NodeFabType.Locator,
				f.FactorId,
				typeof(FactorUsesLocator).Name,
				vLocTypeId,
				typeof(LocatorUsesLocatorType).Name
			});
		}

	}

}