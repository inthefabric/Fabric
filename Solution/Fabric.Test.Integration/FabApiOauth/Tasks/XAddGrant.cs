using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
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

		//TEST: AddGrant's Add scenario


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserZach, SetupOauth.OauthGrantId.GalZach)]
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		private int CountTokens() {
			IWeaverQuery q = WeaverTasks.BeginPath<Root>(x => x.RootId, 0).BaseNode
				.ContainsOauthAccessList.ToOauthAccess
					.Has(x => x.Token, WeaverFuncHasOp.EqualTo, "")
					.Count()
				.End();

			IApiDataAccess data = Context.DbData("TEST.CountTokens", q);
			return int.Parse(data.Result.Text);
		}*/

	}

}