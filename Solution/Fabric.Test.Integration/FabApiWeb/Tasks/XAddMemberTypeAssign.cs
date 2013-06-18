using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XAddMemberTypeAssign : XWebTasks {

		private long vAssigningMemberId;
		private long vMemberId;
		private byte vMemberTypeId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private MemberTypeAssign TestGo() {
			return Tasks.AddMemberTypeAssign(ApiCtx, vAssigningMemberId, vMemberId, vMemberTypeId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupUsers.MemberId.BookZach, SetupUsers.MemberId.BookMel,
			MemberTypeId.Admin, SetupUsers.MemberTypeAssignId.BookMelBySystem)]
		public void Added(SetupUsers.MemberId pAssigningMemberId, SetupUsers.MemberId pMemberId,
								MemberTypeId pMemTypeId, SetupUsers.MemberTypeAssignId pReplaceMtaId) {
			vAssigningMemberId = (long)pAssigningMemberId;
			vMemberId = (long)pMemberId;
			vMemberTypeId = (byte)pMemTypeId;

			MemberTypeAssign result = TestGo();

			Assert.NotNull(result, "Result should not be null.");
			
			////

			MemberTypeAssign movedMta = GetVertex<MemberTypeAssign>((long)pReplaceMtaId);
			Assert.NotNull(movedMta, "Moved MemberTypeAssign was deleted.");
			
			VertexConnections conn = GetVertexConnections(movedMta);
			conn.AssertEdge<MemberHasHistoricMemberTypeAssign, Member>(false, vMemberId);

			////

			MemberTypeAssign newMta = GetVertex<MemberTypeAssign>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			Assert.AreNotEqual(0, newMta.MemberTypeAssignId, "Incorrect MemberTypeAssignId.");

			conn = GetVertexConnections(newMta);
			conn.AssertEdgeCount(2, 0);
			conn.AssertEdge<MemberCreatesMemberTypeAssign, Member>(false, vAssigningMemberId);
			conn.AssertEdge<MemberHasMemberTypeAssign, Member>(false, vMemberId);

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}

	}

}