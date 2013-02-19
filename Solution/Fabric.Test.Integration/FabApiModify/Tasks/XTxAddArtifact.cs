using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddArtifact : XModifyTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(UserZach, SetupUsers.MemberId.GalZach)]
		public void Success(SetupUsers.UserId pUserId, SetupUsers.MemberId pMemberId) {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<User> nodeVar;
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Artifact> artVar;
			var useUser = new User { UserId = (long)pUserId };
			var useMem = new Member { MemberId = (long)pMemberId };

			TxBuild.GetRoot(out rootVar);
			TxBuild.GetNode(useUser, out nodeVar);
			TxBuild.GetNode(useMem, out memVar);
			Tasks.TxAddArtifact<User, UserHasArtifact>(
				ApiCtx, TxBuild, ArtifactTypeId.User, rootVar, nodeVar, memVar, out artVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddArtifact", TxBuild.Transaction);

			////

			Artifact newArt = GetNode<Artifact>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newArt, "New Artifact was not created.");
			Assert.AreNotEqual(0, newArt.ArtifactId, "Incorrect ArtifactId.");
			Assert.AreNotEqual(0, newArt.Created, "Incorrect Created.");

			NodeConnections conn = GetNodeConnections(newArt);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsArtifact, Root>(false, 0);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, useMem.MemberId);
			conn.AssertRel<UserHasArtifact, User>(false, useUser.UserId);
			conn.AssertRel<ArtifactUsesArtifactType, ArtifactType>(true, (long)ArtifactTypeId.User);

			NewNodeCount = 1;
			NewRelCount = 4;
		}

	}

}