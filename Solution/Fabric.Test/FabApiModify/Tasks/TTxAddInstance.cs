using System;
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
			"_V1=[];"+ //Member
			"_V2=g.addVertex(["+
				typeof(Instance).Name+"Id:_TP0,"+
				"Name:_TP1,"+
				"Disamb:_TP2,"+
				"Note:_TP3,"+
				"ArtifactId:_TP4,"+
				"Created:_TP5"+
			"]);"+
			"g.addEdge(_V0,_V2,_TP6);"+
			"g.addEdge(_V1,_V2,_TP7);";

		private string vName;
		private string vDisamb;
		private string vNote;
		private long vNewInstanceId;
		private long vNewArtifactId;
		private DateTime vUtcNow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Instance";
			vDisamb = "by Zach";
			vNote = "It's just okay.";
			vNewInstanceId = 798756473;
			vNewArtifactId = 27357427;
			vUtcNow = DateTime.UtcNow;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Instance>()).Returns(vNewInstanceId);
			MockApiCtx.Setup(x => x.GetSharpflakeId<Artifact>()).Returns(vNewArtifactId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<Instance> urlVar;

			Tasks.TxAddInstance(MockApiCtx.Object, TxBuild, vName, vDisamb, vNote,
				rootVar, memVar, out urlVar);
			FinishTx();

			Assert.NotNull(urlVar, "InstanceVar should not be null.");
			Assert.AreEqual("_V2", urlVar.Name, "Incorrect InstanceVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewInstanceId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vDisamb);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", vNote);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", vNewArtifactId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", vUtcNow.Ticks);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", typeof(RootContainsInstance).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", typeof(MemberCreatesArtifact).Name);
		}

	}

}