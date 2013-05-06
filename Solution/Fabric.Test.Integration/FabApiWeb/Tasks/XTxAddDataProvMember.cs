using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddDataProvMember : XWebTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserPenny)] //already has a membership, but still a valid test
		public void Success(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId) {
			IWeaverVarAlias<App> appVar;
			IWeaverVarAlias<Member> memVar;
			var useApp = new App { ArtifactId = (long)pAppId };

			TxBuild.GetNode(useApp, out appVar);
			Tasks.TxAddDataProvMember(ApiCtx, TxBuild, appVar, (long)pUserId, out memVar);
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
			conn.AssertRelCount(2, 1);
			conn.AssertRel<UserDefinesMember, User>(false, (long)pUserId);
			conn.AssertRel<AppDefinesMember, App>(false, useApp.ArtifactId);
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