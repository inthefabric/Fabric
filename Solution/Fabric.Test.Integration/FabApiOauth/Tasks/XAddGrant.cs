using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XAddGrant : IntegTestBase {

		private long vAppId;
		private long vUserId;
		private string vRedirUri;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = -1;
			vUserId = -1;
			vRedirUri = "http://www.test.com/oauth";
		}

		/*--------------------------------------------------------------------------------------------*/
		private string TestGo() {
			return new AddGrant(vAppId, vUserId, vRedirUri).Go(Context);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserZach, SetupOauth.OauthGrantId.GalZach)]
		[TestCase(AppBook, UserMel, SetupOauth.OauthGrantId.BookMel)]
		[TestCase(AppBook, UserEllie, SetupOauth.OauthGrantId.BookElliePast)]
		public void GoUpdate(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId,
															SetupOauth.OauthGrantId pUpdateGrantId) {
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;

			OauthGrant origOg = GetNode<OauthGrant>((long)pUpdateGrantId);
			Assert.NotNull(origOg, "Target OauthGrant is missing.");

			////

			string result = TestGo();

			Assert.AreNotEqual(origOg.Code, result, "Incorrect result.");

			OauthGrant updateOg = GetNode<OauthGrant>((long)pUpdateGrantId);
			Assert.NotNull(updateOg, "Target OauthGrant was deleted.");
			Assert.AreNotEqual(origOg.RedirectUri, updateOg.RedirectUri,
				"Target OauthGrant.RedirectUri was not updated.");
			Assert.AreNotEqual(origOg.Expires, updateOg.Expires,
				"Target OauthGrant.Expires was not updated.");
			Assert.AreNotEqual(origOg.Code, updateOg.Code, "Target OauthGrant.Code was not updated.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserEllie)]
		[TestCase(AppBook, UserBook)]
		public void GoAdd(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId) {
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;

			string result = TestGo();
			Assert.NotNull(result, "Result should not be null.");

			OauthGrant newOg = GetNodeByProp<OauthGrant>(x => x.Code, "'"+result+"'");
			Assert.NotNull(newOg, "New OauthGrant was not created.");

			NodeConnections conn = GetNodeConnections(newOg);
			conn.AssertRelCount(false, 1);
			conn.AssertRel<RootContainsOauthGrant, Root>(false);
			conn.AssertRelCount(true, 2);
			conn.AssertRel<OauthGrantUsesApp, App>(true);
			conn.AssertRel<OauthGrantUsesUser, User>(true);
		}

	}

}