using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetScope : IntegTestBase {

		private long vAppId;
		private long vUserId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private ScopeResult TestGo() {
			return new GetScope(vAppId, vUserId).Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserZach, SetupOauth.OauthScopeId.GalZach)]
		[TestCase(AppBook, UserMel, SetupOauth.OauthScopeId.BookMel)]
		[TestCase(AppFab, UserFab, SetupOauth.OauthScopeId.FabFabData)]
		public void Go(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId,
															SetupOauth.OauthScopeId pExpectScopeId) {
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;

			ScopeResult result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pExpectScopeId, result.ScopeId, "Incorrect ScopeId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserFab)]
		[TestCase(AppFab, UserZach)]
		public void NotFound(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId) {
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;

			ScopeResult result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}