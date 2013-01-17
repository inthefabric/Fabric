using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XAddScope : IntegTestBase {

		private long vAppId;
		private long vUserId;
		private bool vAllow;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = -1;
			vUserId = -1;
			vAllow = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthScope TestGo() {
			return new AddScope(vAppId, vUserId, vAllow).Go(Context);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserZach, true, SetupOauth.OauthScopeId.GalZach)]
		[TestCase(AppBook, UserMel, false, SetupOauth.OauthScopeId.BookMel)]
		[TestCase(AppBook, UserBook, false, SetupOauth.OauthScopeId.BookBookData)]
		[TestCase(AppBook, UserPenny, true, SetupOauth.OauthScopeId.BookPennyNo)]
		public void GoUpdate(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId, bool pAllow,
															SetupOauth.OauthScopeId pUpdateScopeId) {
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;
			vAllow = pAllow;

			OauthScope origOs = GetNode<OauthScope>((long)pUpdateScopeId);
			Assert.NotNull(origOs, "Target OauthScope is missing.");

			////

			OauthScope result = TestGo();
			
			Assert.NotNull(result, "Result should not be null.");
			Assert.AreEqual((long)pUpdateScopeId, result.OauthScopeId,"Incorrect Result.OauthScopeId.");

			OauthScope updateOs = GetNode<OauthScope>((long)pUpdateScopeId);
			Assert.NotNull(updateOs, "Target OauthScope was deleted.");
			Assert.AreEqual(vAllow, updateOs.Allow, "Target OauthScope.Allow was not updated.");
			Assert.AreNotEqual(origOs.Created, updateOs.Created,
				"Target OauthScope.Created was not updated.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserEllie, true)]
		[TestCase(AppBook, UserBook, false)]
		public void GoAdd(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId, bool pAllow) {
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;
			vAllow = pAllow;

			OauthScope result = TestGo();
			Assert.NotNull(result, "Result should not be null.");
			Assert.AreEqual(vAllow, result.Allow, "Incorrect Result.Allow.");

			OauthScope newOs = GetNode<OauthScope>(result.OauthScopeId);
			Assert.NotNull(newOs, "New OauthScope was not created.");

			NodeConnections conn = GetNodeConnections(newOs);
			conn.AssertRelCount(1, 2);
			conn.AssertRel<RootContainsOauthScope, Root>(false, 0);
			conn.AssertRel<OauthScopeUsesApp, App>(true, vAppId);
			conn.AssertRel<OauthScopeUsesUser, User>(true, vUserId);
		}

	}

}