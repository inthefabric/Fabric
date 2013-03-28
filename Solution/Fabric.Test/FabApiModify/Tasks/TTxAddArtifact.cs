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
				typeof(Artifact).Name+"Id:_TP0,"+
				"IsPrivate:_TP1,"+
				"Created:_TP2"+
			"]);"+
			"g.addEdge(_V0,_V3,_TP3);"+
			"g.V('"+typeof(ArtifactType).Name+"Id',_TP4)[0].each{_V4=g.v(it)};"+
			"g.addEdge(_V3,_V4,_TP5);"+
			"g.addEdge(_V2,_V3,_TP6);"+
			"g.addEdge(_V1,_V3,_TP7);";

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
				.Replace("{{ArtifactTypeId}}", (long)vArtTypeId+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewArtId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", false);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", 0);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", typeof(RootContainsArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", (long)vArtTypeId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", typeof(ArtifactUsesArtifactType).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", typeof(MemberCreatesArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", typeof(UserHasArtifact).Name);
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
				.Replace("{{ArtifactTypeId}}", (long)vArtTypeId+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewArtId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", false);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", 0);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", typeof(RootContainsArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", (long)vArtTypeId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", typeof(ArtifactUsesArtifactType).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", typeof(MemberCreatesArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", typeof(AppHasArtifact).Name);
		}

	}

}