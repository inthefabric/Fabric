using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddDataProvMember : XModifyTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserPenny)] //already has a membership, but still a valid test
		public void Success(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId) {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<App> appVar;
			IWeaverVarAlias<Member> memVar;
			var useApp = new App { AppId = (long)pAppId };

			TxBuild.GetRoot(out rootVar);
			TxBuild.GetNode(useApp, out appVar);
			Tasks.TxAddDataProvMember(ApiCtx, TxBuild, rootVar, appVar, (long)pUserId, out memVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddDataProvMember", TxBuild.Transaction);

			////

			Member newMember = GetNode<Member>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newMember, "New Member was not created.");
			Assert.AreNotEqual(0, newMember.MemberId, "Incorrect MemberId.");

			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			Assert.AreNotEqual(0, newMta.MemberTypeAssignId, "Incorrect MemberTypeAssignId.");

			NodeConnections conn = GetNodeConnections(newMember);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsMember, Root>(false, 0);
			conn.AssertRel<UserDefinesMember, User>(false, (long)pUserId);
			conn.AssertRel<AppDefinesMember, App>(false, useApp.AppId);
			conn.AssertRel<MemberHasMemberTypeAssign, MemberTypeAssign>(
				true, newMta.MemberTypeAssignId);

			conn = GetNodeConnections(newMta);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsMemberTypeAssign, Root>(false, 0);
			conn.AssertRel<MemberCreatesMemberTypeAssign, Member>(false, (long)MemberId.FabFabData);
			conn.AssertRel<MemberHasMemberTypeAssign, Member>(false, newMember.MemberId);
			conn.AssertRel<MemberTypeAssignUsesMemberType, MemberType>(
				true, (long)MemberTypeId.DataProvider);

			NewNodeCount = 2;
			NewRelCount = 7;
		}

	}

}