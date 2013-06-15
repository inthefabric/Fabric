using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class TChangeUserPassword : TBaseWebFunc {

		private long vUserId;
		private string vOldPass;
		private string vNewPass;

		private User vResultUserId;
		private User vResultUser;
		private SuccessResult vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vUserId = 126264;
			vOldPass = "myoldPassword";
			vNewPass = "N3wB3tt3rPa55w0rd";

			vResultUserId = new User();
			vResultUserId.Password = FabricUtil.HashPassword(vOldPass);

			vResultUser = new User();

			MockApiCtx.Setup(x => x.DbNodeById<User>(vUserId)).Returns(vResultUserId);

			MockTasks
				.Setup(x => x.UpdateUserPassword(MockApiCtx.Object, vUserId, vNewPass))
				.Returns(vResultUser);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new ChangeUserPassword(MockTasks.Object, vUserId, vOldPass, vNewPass);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Log.Debug("PASS: "+vOldPass+" / "+vNewPass);
			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.True(vResult.Success, "Incorrect Result.Success.");

			MockValidator.Verify(x => x.ArtifactId(vUserId, ChangeUserPassword.UserIdParam),
				Times.Once());
			MockValidator.Verify(x => x.UserPassword(vNewPass, ChangeUserPassword.NewPasswordParam),
				Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Failure() {
			MockTasks
				.Setup(x => x.UpdateUserPassword(MockApiCtx.Object, vUserId, vNewPass))
				.Returns((User)null);

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.False(vResult.Success, "Incorrect Result.Success.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrUserNotFound() {
			MockApiCtx.Setup(x => x.DbNodeById<User>(vUserId)).Returns((User)null);
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrIncorrectOldPassword() {
			vResultUserId.Password = "incorrect";
			TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
		}

	}

}