using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddInstance : TModifyTasks {

		private const string Query = 
			"_V0=[];"+ //Member
			"_V1=g.addVertex(["+
				PropDbName.Instance_InstanceId+":_TP,"+
				PropDbName.Instance_Name+":_TP,"+
				PropDbName.Instance_Disamb+":_TP,"+
				PropDbName.Instance_Note+":_TP,"+
				PropDbName.Artifact_ArtifactId+":_TP,"+
				PropDbName.Artifact_Created+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP);";

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
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<Instance> urlVar;

			Tasks.TxAddInstance(MockApiCtx.Object, TxBuild, vName, vDisamb, vNote, memVar, out urlVar);
			FinishTx();

			Assert.NotNull(urlVar, "InstanceVar should not be null.");
			Assert.AreEqual("_V1", urlVar.Name, "Incorrect InstanceVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewInstanceId,
				vName,
				vDisamb,
				vNote,
				vNewArtifactId,
				vUtcNow.Ticks,
				(int)NodeFabType.Instance,
				RelDbName.MemberCreatesArtifact
			});
		}

	}

}