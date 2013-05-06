using Fabric.Domain;
using Fabric.Infrastructure;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XUpdateUserPassword : XWebTasks {

		private long vUserId;
		private string vPassword;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vUserId = (long)UserZach;
			vPassword = "MyNewPassword!";
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo() {
			return Tasks.UpdateUserPassword(ApiCtx, vUserId, vPassword);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Updated() {
			string expectPass = FabricUtil.HashPassword(vPassword);

			User oldUser = GetNode<User>(vUserId);
			Assert.NotNull(oldUser, "Target User is missing.");
			Assert.AreNotEqual(expectPass, oldUser.Password, "Target User.Password is incorrect.");

			User result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vUserId, result.ArtifactId, "Incorrect UserId.");
			Assert.AreEqual(expectPass, result.Password, "Incorrect Password.");

			User upUser = GetNode<User>(vUserId);
			Assert.AreEqual(expectPass, upUser.Password, "Target User.Password not updated.");
		}

	}

}