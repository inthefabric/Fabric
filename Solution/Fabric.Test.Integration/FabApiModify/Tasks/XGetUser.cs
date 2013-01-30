using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetUser : XModifyTasks {

		private long vUserId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo() {
			return Tasks.GetUser(ApiCtx, vUserId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(UserZach)]
		[TestCase(UserMel)]
		public void Found(SetupUsers.UserId pUserId) {
			vUserId = (long)pUserId;

			User result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vUserId, result.UserId, "Incorrect UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(999)]
		public void NotFound(long pUserId) {
			vUserId = pUserId;

			User result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}