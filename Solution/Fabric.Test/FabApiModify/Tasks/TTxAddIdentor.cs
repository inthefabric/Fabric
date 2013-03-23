using Fabric.Domain;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddIdentor : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(Identor).Name+"Id:{{NewIdentorId}}L,"+
				"Value:'{{Value}}'"+
			"]);"+
			"g.addEdge(_V0,_V1,'"+typeof(RootContainsIdentor).Name+"');"+
			"g.V('"+typeof(Factor).Name+"Id',{{FactorId}}L)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V2,_V1,'"+typeof(FactorUsesIdentor).Name+"');"+
			"g.V('"+typeof(IdentorType).Name+"Id',{{EveTypeId}}L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,'"+typeof(IdentorUsesIdentorType).Name+"');";

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

			string expect = Query
				.Replace("{{NewIdentorId}}", vNewIdentorId+"")
				.Replace("{{FactorId}}", f.FactorId+"")
				.Replace("{{EveTypeId}}", vIdenTypeId+"")
				.Replace("{{Value}}", vValue);

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
		}

	}

}