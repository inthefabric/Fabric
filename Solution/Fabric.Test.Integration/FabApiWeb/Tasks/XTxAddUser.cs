using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddUser : XWebTasks {

		//Check for duplicate username occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("NewUser", "MyPassword")]
		public void Success(string pName, string pPassword) {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Email> emailVar;
			IWeaverVarAlias<User> userVar;
			var useEmail = new Email { EmailId = (long)SetupUsers.EmailId.Zach_AEI };

			TxBuild.GetRoot(out rootVar);
			TxBuild.GetNode(useEmail, out emailVar);
			Tasks.TxAddUser(ApiCtx, TxBuild, pName, pPassword, rootVar, emailVar, out userVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddUser", TxBuild.Transaction);

			////

			User newUser = GetNode<User>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newUser, "New User was not created.");
			Assert.AreNotEqual(0, newUser.UserId, "Incorrect UserId.");
			Assert.AreEqual(pName, newUser.Name, "Incorrect Name.");
			Assert.AreEqual(FabricUtil.HashPassword(pPassword), newUser.Password,
				"Incorrect Password.");

			NodeConnections conn = GetNodeConnections(newUser);
			conn.AssertRelCount(1, 1);
			conn.AssertRel<RootContainsUser, Root>(false, 0);
			conn.AssertRel<UserUsesEmail, Email>(true, useEmail.EmailId);

			NewNodeCount = 1;
			NewRelCount = 2;
		}

	}

}