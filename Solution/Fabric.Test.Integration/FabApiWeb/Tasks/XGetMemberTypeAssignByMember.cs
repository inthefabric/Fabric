using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetMemberTypeAssignByMember : XWebTasks {

		private long vMemberId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private MemberTypeAssign TestGo() {
			return Tasks.GetMemberTypeAssignByMember(ApiCtx, vMemberId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupUsers.MemberId.GalZach, MemberTypeId.Owner)]
		[TestCase(SetupUsers.MemberId.BookMel, MemberTypeId.Member)]
		[TestCase(SetupUsers.MemberId.GalBookDataNone, MemberTypeId.None)]
		public void Found(SetupUsers.MemberId pMemberId, MemberTypeId pMemTypeId) {
			vMemberId = (long)pMemberId;

			MemberTypeAssign result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((byte)pMemTypeId, result.MemberTypeId, "Incorrect MemberTypeId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			vMemberId = 9999;

			MemberTypeAssign result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}