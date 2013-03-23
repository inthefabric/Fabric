using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddArtifact : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=[];"+ //User
			"_V2=[];"+ //Member
			"_V3=g.addVertex(["+
				typeof(Artifact).Name+"Id:{{NewArtId}}L,"+
				"IsPrivate:false,"+
				"Created:0L"+
			"]);"+
			"g.addEdge(_V0,_V3,'"+typeof(RootContainsArtifact).Name+"');"+
			"g.V('"+typeof(ArtifactType).Name+"Id',{{ArtifactTypeId}}L)[0].each{_V4=g.v(it)};"+
			"g.addEdge(_V3,_V4,'"+typeof(ArtifactUsesArtifactType).Name+"');"+
			"g.addEdge(_V2,_V3,'"+typeof(MemberCreatesArtifact).Name+"');"+
			"g.addEdge(_V1,_V3,'{{HasArtifact}}');";

		private ArtifactTypeId vArtTypeId;
		private long vNewArtId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vNewArtId = 346137173314;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Artifact>()).Returns(vNewArtId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTxUser() {
			vArtTypeId = ArtifactTypeId.User;

			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<User> userVar = GetTxVar<User>();
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<Artifact> artVar;

			Tasks.TxAddArtifact<User, UserHasArtifact>(MockApiCtx.Object, TxBuild,
				vArtTypeId, rootVar, userVar, memVar, out artVar);
			FinishTx();

			Assert.NotNull(artVar, "ArtifactVar should not be null.");
			Assert.AreEqual("_V3", artVar.Name, "Incorrect ArtifactVar name.");

			string expect = Query
				.Replace("{{NewArtId}}", vNewArtId+"")
				.Replace("{{ArtifactTypeId}}", (long)vArtTypeId+"")
				.Replace("{{HasArtifact}}", typeof(UserHasArtifact).Name);

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTxApp() {
			vArtTypeId = ArtifactTypeId.App;

			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<App> appVar = GetTxVar<App>();
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<Artifact> artVar;

			Tasks.TxAddArtifact<App, AppHasArtifact>(MockApiCtx.Object, TxBuild,
				vArtTypeId, rootVar, appVar, memVar, out artVar);
			FinishTx();

			Assert.NotNull(artVar, "ArtifactVar should not be null.");
			Assert.AreEqual("_V3", artVar.Name, "Incorrect ArtifactVar name.");

			string expect = Query
				.Replace("{{NewArtId}}", vNewArtId+"")
				.Replace("{{ArtifactTypeId}}", (long)vArtTypeId+"")
				.Replace("{{HasArtifact}}", typeof(AppHasArtifact).Name);

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
		}

	}

}