using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddApp : TWebTasks {

		private const string Query = 
			"_V0=[];"+ //Member
			"_EM=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP)"+
				".outE('"+EdgeDbName.UserUsesEmail+"').inV.next();"+
			"_V2=g.addVertex(["+
				PropDbName.App_Name+":_TP,"+
				PropDbName.App_NameKey+":_TP,"+
				PropDbName.Artifact_ArtifactId+":_TP,"+
				PropDbName.Artifact_Created+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_PROP=[:];"+
			"g.addEdge(_V2,_EM,_TP,_PROP);"+
			"_PROP=[:];"+
			"_TRY=[A_Cr:_V2];"+
			TestUtil.TryPropScript+
			"g.addEdge(_V0,_V2,_TP,_PROP);";

		private string vName;
		private long vUserId;
		private long vNewArtifactId;
		private DateTime vUtcNow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "NewApp";
			vUserId = 9876;
			vNewArtifactId = 27357427;
			vUtcNow = DateTime.UtcNow;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Artifact>()).Returns(vNewArtifactId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>("_V0");
			IWeaverVarAlias<App> appVar;
			Action<IWeaverVarAlias<Member>> setMem;

			Tasks.TxAddApp(MockApiCtx.Object, TxBuild, vName, vUserId, out appVar, out setMem);
			setMem(memVar);
			FinishTx();

			Assert.NotNull(appVar, "AppVar should not be null.");
			Assert.AreEqual("_V2", appVar.Name, "Incorrect AppVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vUserId,
				vName,
				vName.ToLower(),
				vNewArtifactId,
				vUtcNow.Ticks,
				(byte)VertexFabType.App,
				EdgeDbName.AppUsesEmail,
				EdgeDbName.MemberCreatesArtifact
			});
		}

	}

}