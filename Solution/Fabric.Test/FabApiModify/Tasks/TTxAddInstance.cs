using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddInstance : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=g.addVertex(["+
				typeof(Instance).Name+"Id:_TP0,"+
				"Name:_TP1,"+
				"Disamb:_TP2,"+
				"Note:_TP3"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP4);";

		private string vName;
		private string vDisamb;
		private string vNote;
		private long vNewInstanceId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Instance";
			vDisamb = "by Zach";
			vNote = "It's just okay.";
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

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewInstanceId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vDisamb);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", vNote);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", typeof(RootContainsInstance).Name);
		}

	}

}