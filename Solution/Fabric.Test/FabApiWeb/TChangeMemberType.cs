using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
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
		private long vMemberTypeId;

		private Member vResultAssigningMember;
		private Member vResultMember;
		private MemberTypeAssign vResultMta;
		private SuccessResult vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 126264;
			vAssigningMemberId = 23467;
			vMemberId = 272475;
			vMemberTypeId = 4;

			vResultAssigningMember = new Member();
			vResultMember = new Member();
			vResultMta = new MemberTypeAssign();

			MockTasks
				.Setup(x => x.GetMemberOfApp(MockApiCtx.Object, vAppId, vMemberId))
				.Returns(vResultMember);

			MockTasks
				.Setup(x => x.GetMemberOfApp(MockApiCtx.Object, vAppId, vAssigningMemberId))
				.Returns(vResultAssigningMember);

			MockTasks
				.Setup(x => x.AddMemberTypeAssign(MockApiCtx.Object,
					vAssigningMemberId, vMemberId, vMemberTypeId))
				.Returns(vResultMta);
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
			MockValidator.Verify(x => x.MemberTypeId(vMemberTypeId,
				ChangeMemberType.MemberTypeIdParam), Times.Once());
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
		public void ErrAssigningMemberNotFound() {
			MockTasks
				.Setup(x => x.GetMemberOfApp(MockApiCtx.Object, vAppId, vAssigningMemberId))
				.Returns((Member)null);

			FabNotFoundFault f = TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
			Assert.AreNotEqual(-1, f.Criteria.IndexOf("&"+ChangeMemberType.AssigningMemberIdParam),
				"Incorrect Fault.Criteria.");
		}

	}

}