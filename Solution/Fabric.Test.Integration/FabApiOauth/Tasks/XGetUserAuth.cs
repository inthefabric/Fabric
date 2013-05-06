using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetUserAuth : IntegTestBase {

		private string vUsername;
		private string vPassword;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo() {
			return new GetUserAuth(vUsername, vPassword).Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("zachkinstner", "asdfasdf", UserZach)]
		[TestCase("ZaChKiNsTnEr", "asdfasdf", UserZach)]
		[TestCase("zachkinstner", "asdfasdf2", null)]
		public void Go(string pUsername, string pPassword, SetupUsers.UserId? pExpectId) {
			vUsername = pUsername;
			vPassword = pPassword;

			User result = TestGo();

			if ( pExpectId != null ) {
				Assert.NotNull(result, "Result should be filled.");
				Assert.AreEqual((long)pExpectId, result.ArtifactId, "Incorrect UserId.");
			}
			else {
				Assert.Null(result, "Result should be null.");
			}
		}

	}

}