using System;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddApp : XWebTasks {

		//Check for duplicate app name occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("NewApp", UserZach, SetupUsers.EmailId.Zach_AEI)]
		[TestCase("Mel's New App", UserMel, SetupUsers.EmailId.MKin_Gmail)]
		[TestCase("Epic Fail", UserGal, SetupUsers.EmailId.PhoApp_ZK)]
		public void Success(string pName, SetupUsers.UserId pCreatorUserId,
																	SetupUsers.EmailId pExpectEmailId) {
			IWeaverVarAlias<App> appVar;
			Action<IWeaverVarAlias<Member>> setMemVar;

			Tasks.TxAddApp(ApiCtx, TxBuild, pName, (long)pCreatorUserId, out appVar, out setMemVar);

			var mem = new Member { MemberId = (long)SetupUsers.MemberId.FabFabData };
			IWeaverVarAlias<Member> memVar;
			TxBuild.GetVertex(mem, out memVar);
			setMemVar(memVar);

			FinishTx();

			ApiCtx.ExecuteForTest(TxBuild.Transaction);

			////

			App newApp = GetVertex<App>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newApp, "New App was not created.");
			Assert.AreNotEqual(0, newApp.ArtifactId, "Incorrect AppId.");
			Assert.AreEqual(pName, newApp.Name, "Incorrect Name.");
			Assert.AreEqual(32, newApp.Secret.Length, "Incorrect Secret length.");

			VertexConnections conn = GetVertexConnections(newApp);
			conn.AssertEdgeCount(1, 1);
			conn.AssertEdge<AppUsesEmail, Email>(true, (long)pExpectEmailId);
			conn.AssertEdge<MemberCreatesArtifact, Member>(false, mem.MemberId);

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}

	}

}