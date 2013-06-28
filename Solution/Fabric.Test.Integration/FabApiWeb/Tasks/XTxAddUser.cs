using System;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddUser : XWebTasks {

		//Check for duplicate username occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("NewUser", "MyPassword")]
		public void Success(string pName, string pPassword) {
			IWeaverVarAlias<Email> emailVar;
			IWeaverVarAlias<User> userVar;
			var useEmail = new Email { EmailId = (long)SetupUsers.EmailId.Zach_AEI };
			Action<IWeaverVarAlias<Member>> setMemVar;

			TxBuild.GetVertex(useEmail, out emailVar);
			Tasks.TxAddUser(ApiCtx, TxBuild, pName, pPassword, emailVar, out userVar, out setMemVar);

			var mem = new Member { MemberId = (long)SetupUsers.MemberId.FabFabData };
			IWeaverVarAlias<Member> memVar;
			TxBuild.GetVertex(mem, out memVar);
			setMemVar(memVar);

			FinishTx();

			ApiCtx.ExecuteForTest(TxBuild.Transaction);

			////

			User newUser = GetVertex<User>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newUser, "New User was not created.");
			Assert.AreNotEqual(0, newUser.ArtifactId, "Incorrect UserId.");
			Assert.AreEqual(pName, newUser.Name, "Incorrect Name.");
			Assert.AreEqual(FabricUtil.HashPassword(pPassword), newUser.Password,
				"Incorrect Password.");

			VertexConnections conn = GetVertexConnections(newUser);
			conn.AssertEdgeCount(1, 1);
			conn.AssertEdge<UserUsesEmail, Email>(true, useEmail.EmailId);
			conn.AssertEdge<MemberCreatesArtifact, Member>(false, mem.MemberId);

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}

	}

}