using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddClass : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=g.addVertex(["+
				typeof(Class).Name+"Id:_TP0,"+
				"Name:_TP1,"+
				"Disamb:_TP2,"+
				"Note:_TP3"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP4);";

		private string vName;
		private string vDisamb;
		private string vNote;
		private long vNewClassId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Class";
			vDisamb = "by Zach";
			vNote = "It's just okay.";
			vNewClassId = 798756473;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Class>()).Returns(vNewClassId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Class> urlVar;

			Tasks.TxAddClass(MockApiCtx.Object, TxBuild, vName, vDisamb, vNote, rootVar, out urlVar);
			FinishTx();

			Assert.NotNull(urlVar, "ClassVar should not be null.");
			Assert.AreEqual("_V1", urlVar.Name, "Incorrect ClassVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewClassId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vDisamb);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", vNote);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", typeof(RootContainsClass).Name);
		}

	}

}