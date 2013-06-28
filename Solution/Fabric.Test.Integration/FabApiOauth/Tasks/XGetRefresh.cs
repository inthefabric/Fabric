using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetRefresh : IntegTestBase {

		private string vRefreshToken;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private RefreshResult TestGo() {
			return new GetRefresh(vRefreshToken).Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupOauth.RefreshGalZach, AppGal, UserZach)]
		public void Go(string pRefToken, SetupUsers.AppId pAppId, SetupUsers.UserId pUserId){
			vRefreshToken = pRefToken;

			RefreshResult result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pAppId, result.AppId, "Incorrect AppId.");
			Assert.AreEqual((long)pUserId, result.UserId, "Incorrect UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x")]
		[TestCase("")]
		public void NotFound(string pRefToken) {
			vRefreshToken = pRefToken;
			RefreshResult result = TestGo();
			Assert.Null(result, "Result should be null.");
		}

	}

}