using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify {

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
				Context, TxBuild, ArtifactTypeId.User, rootVar, nodeVar, memVar, out artVar);
			FinishTx();

			Context.DbData("TEST.TxAddArtifact", TxBuild.Transaction);

			////

			Artifact newArt = GetNode<Artifact>(Context.SharpflakeIds[0]);
			Assert.NotNull(newArt, "New Artifact was not created.");

			NodeConnections conn = GetNodeConnections(newArt);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsArtifact, Root>(false, 0);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, useMem.MemberId);
			conn.AssertRel<UserHasArtifact, User>(false, useUser.UserId);
			conn.AssertRel<ArtifactUsesArtifactType, ArtifactType>(true, (long)ArtifactTypeId.User);
		}

	}

}