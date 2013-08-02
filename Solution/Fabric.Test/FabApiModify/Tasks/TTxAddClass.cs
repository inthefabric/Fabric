using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddClass : TModifyTasks {

		private const string Query = 
			"_V0=[];"+ //Member
			"_V1=g.addVertex(["+
				PropDbName.Class_Name+":_TP,"+
				PropDbName.Class_NameKey+":_TP,"+
				PropDbName.Class_Disamb+":_TP,"+
				PropDbName.Class_Note+":_TP,"+
				PropDbName.Artifact_ArtifactId+":_TP,"+
				PropDbName.Artifact_Created+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_PROP=[:];"+
			"_TRY=[A_Cr:_V1];"+
			TestUtil.TryPropScript+
			"g.addEdge(_V0,_V1,_TP,_PROP);";

		private string vName;
		private string vDisamb;
		private string vNote;
		private long vNewArtifactId;
		private DateTime vUtcNow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Class";
			vDisamb = "by Zach";
			vNote = "It's just okay.";
			vNewArtifactId = 27357427;
			vUtcNow = DateTime.UtcNow;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Artifact>()).Returns(vNewArtifactId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("my disamb text")]
		[TestCase(null)]
		public void BuildTx(string pDisamb) {
			vDisamb = pDisamb;

			IWeaverVarAlias<Member> memVar = GetTxVar<Member>("_V0");
			IWeaverVarAlias<Class> classVar;

			Tasks.TxAddClass(MockApiCtx.Object, TxBuild, vName, vDisamb, vNote, memVar, out classVar);
			FinishTx();

			Assert.NotNull(classVar, "ClassVar should not be null.");
			Assert.AreEqual("_V1", classVar.Name, "Incorrect ClassVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vName,
				vName.ToLower(),
				vDisamb,
				vNote,
				vNewArtifactId,
				vUtcNow.Ticks,
				(byte)VertexFabType.Class,
				EdgeDbName.MemberCreatesArtifact
			});
		}

	}

}