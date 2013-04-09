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

			MemberTypeAssign movedMta = GetNode<MemberTypeAssign>((long)pReplaceMtaId);
			Assert.NotNull(movedMta, "Moved MemberTypeAssign was deleted.");
			
			NodeConnections conn = GetNodeConnections(movedMta);
			conn.AssertRel<MemberHasHistoricMemberTypeAssign, Member>(false, vMemberId);

			////

			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			Assert.AreNotEqual(0, newMta.MemberTypeAssignId, "Incorrect MemberTypeAssignId.");

			conn = GetNodeConnections(newMta);
			conn.AssertRelCount(2, 0);
			conn.AssertRel<MemberCreatesMemberTypeAssign, Member>(false, vAssigningMemberId);
			conn.AssertRel<MemberHasMemberTypeAssign, Member>(false, vMemberId);

			NewNodeCount = 1;
			NewRelCount = 2;
		}

	}

}