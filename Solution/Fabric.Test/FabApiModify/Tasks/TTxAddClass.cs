using Fabric.Domain;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddClass : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=g.addVertex(["+
				typeof(Class).Name+"Id:{{NewClassId}}L,"+
				"Name:'{{Name}}',"+
				"Disamb:'{{Disamb}}',"+
				"Note:'{{Note}}'"+
			"]);"+
			"g.addEdge(_V0,_V1,'"+typeof(RootContainsClass).Name+"');";

		private string vName;
		private string vDisamb;
		private string vNote;
		private string vNoteExpect;
		private long vNewClassId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Class";
			vDisamb = "by Zach";
			vNote = "It's just okay.";
			vNoteExpect= "It\\'s just okay.";
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

			string expect = Query
				.Replace("{{NewClassId}}", vNewClassId+"")
				.Replace("{{Name}}", vName+"")
				.Replace("{{Disamb}}", vDisamb+"")
				.Replace("{{Note}}", vNoteExpect+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
		}

	}

}