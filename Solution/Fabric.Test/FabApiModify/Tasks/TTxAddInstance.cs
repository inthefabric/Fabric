using Fabric.Domain;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddInstance : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=g.addVertex(["+
				typeof(Instance).Name+"Id:{{NewInstanceId}}L,"+
				"Name:'{{Name}}',"+
				"Disamb:'{{Disamb}}',"+
				"Note:'{{Note}}'"+
			"]);"+
			"g.addEdge(_V0,_V1,'"+typeof(RootContainsInstance).Name+"');";

		private string vName;
		private string vDisamb;
		private string vNote;
		private long vNewInstanceId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Instance";
			vDisamb = "by Zach";
			vNote = "Just okay.";
			vNewInstanceId = 798756473;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Instance>()).Returns(vNewInstanceId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Instance> urlVar;

			Tasks.TxAddInstance(MockApiCtx.Object, TxBuild, vName, vDisamb, vNote, rootVar, out urlVar);
			FinishTx();

			Assert.NotNull(urlVar, "InstanceVar should not be null.");
			Assert.AreEqual("_V1", urlVar.Name, "Incorrect InstanceVar name.");

			string expect = Query
				.Replace("{{NewInstanceId}}", vNewInstanceId+"")
				.Replace("{{Name}}", vName)
				.Replace("{{Disamb}}", vDisamb)
				.Replace("{{Note}}", vNote);

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
		}

	}

}