using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddApp : XModifyTasks {

		//NOTE: check for duplicate app name occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("NewApp", UserZach, SetupUsers.EmailId.Zach_AEI)]
		[TestCase("Mel's New App", UserMel, SetupUsers.EmailId.MKin_Gmail)]
		public void Success(string pName, SetupUsers.UserId pCreatorUserId,
																	SetupUsers.EmailId pExpectEmailId) {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<App> appVar;

			TxBuild.GetRoot(out rootVar);
			Tasks.TxAddApp(Context, TxBuild, pName, rootVar, (long)pCreatorUserId, out appVar);
			FinishTx();

			Context.DbData("TEST.TxAddApp", TxBuild.Transaction);

			////

			App newApp = GetNode<App>(Context.SharpflakeIds[0]);
			Assert.NotNull(newApp, "New App was not created.");

			NodeConnections conn = GetNodeConnections(newApp);
			conn.AssertRelCount(1, 1);
			conn.AssertRel<RootContainsApp, Root>(false, 0);
			conn.AssertRel<AppUsesEmail, Email>(true, (long)pExpectEmailId);

			NewNodeCount = 1;
			NewRelCount = 2;
		}

	}

}