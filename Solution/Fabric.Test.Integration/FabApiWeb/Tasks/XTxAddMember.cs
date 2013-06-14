using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddMember : XWebTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(UserPenny)] //already has a membership, but still a valid test
		public void Success(SetupUsers.UserId pUserId) {
			IWeaverVarAlias<User> userVar;
			IWeaverVarAlias<Member> memVar;
			var useUser = new User { ArtifactId = (long)pUserId };

			TxBuild.GetNode(useUser, out userVar);
			Tasks.TxAddMember(ApiCtx, TxBuild, userVar, out memVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddMember", TxBuild.Transaction);

			////

			Member newMember = GetNode<Member>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newMember, "New Member was not created.");
			Assert.AreNotEqual(0, newMember.MemberId, "Incorrect MemberId.");

			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			Assert.AreNotEqual(0, newMta.MemberTypeAssignId, "Incorrect MemberTypeAssignId.");

			NodeConnections conn = GetNodeConnections(newMember);
			conn.AssertRelCount(2, 1);
			conn.AssertRel<UserDefinesMember, User>(false, useUser.ArtifactId);
			conn.AssertRel<AppDefinesMember, App>(false, (long)AppId.FabricSystem);
			conn.AssertRel<MemberHasMemberTypeAssign, MemberTypeAssign>(
				true, newMta.MemberTypeAssignId);

			conn = GetNodeConnections(newMta);
			conn.AssertRelCount(2, 0);
			conn.AssertRel<MemberCreatesMemberTypeAssign, Member>(false, (long)MemberId.FabFabData);
			conn.AssertRel<MemberHasMemberTypeAssign, Member>(false, newMember.MemberId);

			NewNodeCount = 2;
			NewRelCount = 4;
		}

	}

}