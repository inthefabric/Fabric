using Fabric.Api.Modify.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XGetUser : IntegTestBase {

		private long vUserId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo() {
			return new ModifyTasks().GetUser(Context, vUserId);
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