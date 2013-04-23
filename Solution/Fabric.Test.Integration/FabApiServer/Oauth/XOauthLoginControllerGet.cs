using Fabric.Api.Dto.Oauth;
using Fabric.Api.Services;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Nancy;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiServer.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class XOauthLoginControllerGet : XOauthLoginController {

		private string vResponseType;
		private string vClientId;
		private string vRedirectUri;
		private string vSwitchMode;
		private string vState;
		private string vError;

		private OauthLoginController vLoginCtrl;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vResponseType = "code";
			vClientId = (long)AppFab+"";
			vRedirectUri = "http://"+SetupOauth.DomFab1+"/oauth/";
			vSwitchMode = "0";
			vState = FabricUtil.Code32;
			vError = null;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response TestGet() {
			var req = new Request("GET", "test", "test");

			req.Query.Add("response_type", vResponseType);
			req.Query.Add("client_id", vClientId);
			req.Query.Add("redirect_uri", vRedirectUri);
			req.Query.Add("switchMode", vSwitchMode);
			req.Query.Add("state", vState);
			req.Query.Add("error", vError);

			FillRequestCookies(req);

			vLoginCtrl = new OauthLoginController(req, ApiCtx);
			return vLoginCtrl.Execute();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("0")]
		[TestCase("1")]
		public void Unsigned(string pSwitchMode) {
			vSwitchMode = pSwitchMode;

			TestGet();
			FabOauthLogin login = vLoginCtrl.LoginDto;

			Assert.True(login.ShowLoginPage, "Incorrect Login.ShowLoginPage.");
			Assert.AreEqual(int.Parse(vClientId), login.AppId, "Incorrect Login.AppId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null, false)]
		[TestCase("0", false)]
		[TestCase("1", true)]
		public void Signed(string pSwitchMode, bool pShowLoginPage) {
			vSwitchMode = pSwitchMode;
			vLoggedUserId = (long)UserZach;

			TestGet();
			FabOauthLogin login = vLoginCtrl.LoginDto;

			Assert.AreEqual(pShowLoginPage, login.ShowLoginPage, "Incorrect LoginDto.ShowLoginPage.");

			if ( !pShowLoginPage ) {
				Assert.Null(login.ScopeCode, "LoginDto.ScopeCode should be filled.");
			}

			Assert.AreEqual(int.Parse(vClientId), login.AppId, "Incorrect LoginDto.AppId.");
			Assert.AreEqual(vLoggedUserId, login.LoggedUserId, "Incorrect LoginDto.LoggedUserId.");
			Assert.AreEqual("zachkinstner", login.LoggedUserName, "Incorrect LoginDto.LoggedUserName.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("OriginalState")]
		[TestCase("12345")]
		[TestCase("")]
		[TestCase(null)]
		public void AlreadyAllowedScope(string pState) {
			vRedirectUri = SetupOauth.GrantUrlGal;
			vClientId = (long)AppGal+"";
			vLoggedUserId = (long)UserZach;
			if ( pState != "OriginalState" ) { vState = pState; }

			Response result = TestGet();
			CheckRedirectSuccess(result, vRedirectUri, vState);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("invalid_request")]
		[TestCase("")]
		public void Error(string pError) {
			vError = pError;
			TestGet();
		}

	}

}
