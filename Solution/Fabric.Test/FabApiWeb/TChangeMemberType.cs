using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class TChangeMemberType : TBaseWebFunc {

		private long vAppId;
		private long vAssigningMemberId;
		private long vMemberId;
		private byte vMemberTypeId;

		private Member vResultMember;
		private MemberTypeAssign vResultMta;
		private Member vResultAssigningMember;
		private MemberTypeAssign vResultAssigningMta;
		private MemberTypeAssign vResultNewMta;
		private SuccessResult vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 126264;
			vAssigningMemberId = 23467;
			vMemberId = 272475;
			vMemberTypeId = 4;

			vResultAssigningMember = new Member();
			vResultMta = new MemberTypeAssign { MemberTypeId = (byte)MemberTypeId.Member };
			vResultMember = new Member();
			vResultAssigningMta = new MemberTypeAssign { MemberTypeId = (byte)MemberTypeId.Admin };
			vResultNewMta = new MemberTypeAssign();

			MockTasks
				.Setup(x => x.GetMemberOfApp(MockApiCtx.Object, vAppId, vMemberId))
				.Returns(vResultMember);

			MockTasks
				.Setup(x => x.GetMemberTypeAssignByMember(MockApiCtx.Object, vMemberId))
				.Returns(vResultMta);

			MockTasks
				.Setup(x => x.GetMemberOfApp(MockApiCtx.Object, vAppId, vAssigningMemberId))
				.Returns(vResultAssigningMember);

			MockTasks
				.Setup(x => x.GetMemberTypeAssignByMember(MockApiCtx.Object, vAssigningMemberId))
				.Returns(vResultAssigningMta);

			MockTasks
				.Setup(x => x.AddMemberTypeAssign(MockApiCtx.Object,
					vAssigningMemberId, vMemberId, vMemberTypeId))
				.Returns(vResultNewMta);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new ChangeMemberType(
				MockTasks.Object, vAppId, vAssigningMemberId, vMemberId, vMemberTypeId);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.True(vResult.Success, "Incorrect Result.Success.");

			MockValidator.Verify(x => x.AppId(vAppId,
				ChangeMemberType.AppIdParam), Times.Once());
			MockValidator.Verify(x => x.MemberId(vAssigningMemberId,
				ChangeMemberType.AssigningMemberIdParam), Times.Once());
			MockValidator.Verify(x => x.MemberId(vMemberId,
				ChangeMemberType.MemberIdParam), Times.Once());
			MockValidator.Verify(x => x.MemberTypeAssignMemberTypeId(vMemberTypeId,
				ChangeMemberType.MemberTypeIdParam), Times.Once());

			MockMemCache.Verify(x => x.RemoveMember(vMemberId), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Failure() {
			MockTasks
				.Setup(x => x.AddMemberTypeAssign(MockApiCtx.Object,
					vAssigningMemberId, vMemberId, vMemberTypeId))
				.Returns((MemberTypeAssign)null);

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.False(vResult.Success, "Incorrect Result.Success.");

			MockMemCache.Verify(x => x.RemoveMember(vMemberId), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMemberNotFound() {
			MockTasks
				.Setup(x => x.GetMemberOfApp(MockApiCtx.Object, vAppId, vMemberId))
				.Returns((Member)null);

			FabNotFoundFault f = TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
			Assert.AreNotEqual(-1, f.Criteria.IndexOf("&"+ChangeMemberType.MemberIdParam),
				"Incorrect Fault.Criteria.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMemberIsDataProv() {
			vResultMta.MemberTypeId = (byte)MemberTypeId.DataProvider;

			FabPreventedFault f = TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
			Assert.AreEqual(FabFault.Code.ActionNotPermitted, f.ErrCode,
				"Incorrect Fault.ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAssigningMemberNotFound() {
			MockTasks
				.Setup(x => x.GetMemberOfApp(MockApiCtx.Object, vAppId, vAssigningMemberId))
				.Returns((Member)null);

			FabNotFoundFault f = TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
			Assert.AreNotEqual(-1, f.Criteria.IndexOf("&"+ChangeMemberType.AssigningMemberIdParam),
				"Incorrect Fault.Criteria.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(MemberTypeId.None)]
		[TestCase(MemberTypeId.Invite)]
		[TestCase(MemberTypeId.Member)]
		[TestCase(MemberTypeId.Request)]
		public void ErrAssigningMemberIsNotAllowed(MemberTypeId pMemTypeId) {
			vResultAssigningMta.MemberTypeId = (byte)pMemTypeId;

			FabPreventedFault f = TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
			Assert.AreEqual(FabFault.Code.ActionNotPermitted, f.ErrCode,
				"Incorrect Fault.ErrCode.");
		}

	}

}