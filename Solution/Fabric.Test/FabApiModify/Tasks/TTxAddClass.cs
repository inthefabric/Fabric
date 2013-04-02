using System;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddClass : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=[];"+ //Member
			"_V2=g.addVertex(["+
				typeof(Class).Name+"Id:_TP0,"+
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
		private long vNewClassId;
		private long vNewArtifactId;
		private DateTime vUtcNow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Class";
			vDisamb = "by Zach";
			vNote = "It's just okay.";
			vNewClassId = 798756473;
			vNewArtifactId = 27357427;
			vUtcNow = DateTime.UtcNow;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Class>()).Returns(vNewClassId);
			MockApiCtx.Setup(x => x.GetSharpflakeId<Artifact>()).Returns(vNewArtifactId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<Class> urlVar;

			Log.Debug(typeof(Artifact).IsAssignableFrom(typeof(Class))+"");
			Log.Debug(typeof(Class).IsAssignableFrom(typeof(Artifact))+"");

			Tasks.TxAddClass(MockApiCtx.Object, TxBuild, vName, vDisamb, vNote, 
				rootVar, memVar, out urlVar);
			FinishTx();

			Assert.NotNull(urlVar, "ClassVar should not be null.");
			Assert.AreEqual("_V2", urlVar.Name, "Incorrect ClassVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewClassId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vDisamb);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", vNote);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", vNewArtifactId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", vUtcNow.Ticks);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", typeof(RootContainsClass).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", typeof(MemberCreatesArtifact).Name);
		}

	}

}