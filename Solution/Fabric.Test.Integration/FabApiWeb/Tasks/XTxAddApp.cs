using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using Fabric.Test.Integration.FabApiModify.Tasks;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddApp : XModifyTasks {

		//Check for duplicate app name occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("NewApp", UserZach, SetupUsers.EmailId.Zach_AEI)]
		[TestCase("Mel's New App", UserMel, SetupUsers.EmailId.MKin_Gmail)]
		public void Success(string pName, SetupUsers.UserId pCreatorUserId,
																	SetupUsers.EmailId pExpectEmailId) {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<App> appVar;

			TxBuild.GetRoot(out rootVar);
			Tasks.TxAddApp(ApiCtx, TxBuild, pName, rootVar, (long)pCreatorUserId, out appVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddApp", TxBuild.Transaction);

			////

			App newApp = GetNode<App>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newApp, "New App was not created.");
			Assert.AreNotEqual(0, newApp.AppId, "Incorrect AppId.");
			Assert.AreEqual(pName, newApp.Name, "Incorrect Name.");
			Assert.AreEqual(32, newApp.Secret.Length, "Incorrect Secret length.");

			NodeConnections conn = GetNodeConnections(newApp);
			conn.AssertRelCount(1, 1);
			conn.AssertRel<RootContainsApp, Root>(false, 0);
			conn.AssertRel<AppUsesEmail, Email>(true, (long)pExpectEmailId);

			NewNodeCount = 1;
			NewRelCount = 2;
		}

	}

}