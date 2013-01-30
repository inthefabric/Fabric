using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddMember : XModifyTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(UserPenny)] //already has a membership, but still a valid test
		public void Success(SetupUsers.UserId pUserId) {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<User> userVar;
			IWeaverVarAlias<Member> memVar;
			var useUser = new User { UserId = (long)pUserId };

			TxBuild.GetRoot(out rootVar);
			TxBuild.GetNode(useUser, out userVar);
			Tasks.TxAddMember(Context, TxBuild, rootVar, userVar, out memVar);
			FinishTx();

			Context.DbData("TEST.TxAddMember", TxBuild.Transaction);

			////

			Member newMember = GetNode<Member>(Context.SharpflakeIds[0]);
			Assert.NotNull(newMember, "New Member was not created.");

			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(Context.SharpflakeIds[1]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");

			NodeConnections conn = GetNodeConnections(newMember);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsMember, Root>(false, 0);
			conn.AssertRel<UserDefinesMember, User>(false, useUser.UserId);
			conn.AssertRel<AppDefinesMember, App>(false, (long)AppId.FabricSystem);
			conn.AssertRel<MemberHasMemberTypeAssign, MemberTypeAssign>(
				true, newMta.MemberTypeAssignId);

			conn = GetNodeConnections(newMta);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsMemberTypeAssign, Root>(false, 0);
			conn.AssertRel<MemberCreatesMemberTypeAssign, Member>(false, (long)MemberId.FabFabData);
			conn.AssertRel<MemberHasMemberTypeAssign, Member>(false, newMember.MemberId);
			conn.AssertRel<MemberTypeAssignUsesMemberType, MemberType>(true, (long)MemberTypeId.Member);

			NewNodeCount = 2;
			NewRelCount = 7;
		}

	}

}