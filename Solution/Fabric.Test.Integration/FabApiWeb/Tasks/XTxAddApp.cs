using System;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddApp : XWebTasks {

		//Check for duplicate app name occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("NewApp", UserZach, SetupUsers.EmailId.Zach_AEI)]
		[TestCase("Mel's New App", UserMel, SetupUsers.EmailId.MKin_Gmail)]
		public void Success(string pName, SetupUsers.UserId pCreatorUserId,
																	SetupUsers.EmailId pExpectEmailId) {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<App> appVar;
			Action<IWeaverVarAlias<Member>> setMemVar;

			TxBuild.GetRoot(out rootVar);
			Tasks.TxAddApp(ApiCtx, TxBuild, pName, rootVar, (long)pCreatorUserId,
				out appVar, out setMemVar);

			var mem = new Member { MemberId = (long)SetupUsers.MemberId.FabFabData };
			IWeaverVarAlias<Member> memVar;
			TxBuild.GetNode(mem, out memVar);
			setMemVar(memVar);

			FinishTx();

			ApiCtx.DbData("TEST.TxAddApp", TxBuild.Transaction);

			////

			App newApp = GetNode<App>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newApp, "New App was not created.");
			Assert.AreNotEqual(0, newApp.AppId, "Incorrect AppId.");
			Assert.AreEqual(pName, newApp.Name, "Incorrect Name.");
			Assert.AreEqual(32, newApp.Secret.Length, "Incorrect Secret length.");

			NodeConnections conn = GetNodeConnections(newApp);
			conn.AssertRelCount(2, 1);
			conn.AssertRel<RootContainsApp, Root>(false, 0);
			conn.AssertRel<AppUsesEmail, Email>(true, (long)pExpectEmailId);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, mem.MemberId);

			NewNodeCount = 1;
			NewRelCount = 3;
		}

	}

}