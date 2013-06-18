using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Query;

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

			TxBuild.GetVertex(useApp, out appVar);
			Tasks.TxAddDataProvMember(ApiCtx, TxBuild, appVar, (long)pUserId, out memVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddDataProvMember", TxBuild.Transaction);

			////

			Member newMember = GetVertex<Member>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newMember, "New Member was not created.");
			Assert.AreNotEqual(0, newMember.MemberId, "Incorrect MemberId.");

			MemberTypeAssign newMta = GetVertex<MemberTypeAssign>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			Assert.AreNotEqual(0, newMta.MemberTypeAssignId, "Incorrect MemberTypeAssignId.");

			VertexConnections conn = GetVertexConnections(newMember);
			conn.AssertEdgeCount(2, 1);
			conn.AssertEdge<UserDefinesMember, User>(false, (long)pUserId);
			conn.AssertEdge<AppDefinesMember, App>(false, useApp.ArtifactId);
			conn.AssertEdge<MemberHasMemberTypeAssign, MemberTypeAssign>(
				true, newMta.MemberTypeAssignId);

			conn = GetVertexConnections(newMta);
			conn.AssertEdgeCount(2, 0);
			conn.AssertEdge<MemberCreatesMemberTypeAssign, Member>(false, (long)MemberId.FabFabData);
			conn.AssertEdge<MemberHasMemberTypeAssign, Member>(false, newMember.MemberId);

			NewVertexCount = 2;
			NewEdgeCount = 4;
		}

	}

}