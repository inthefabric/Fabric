using System;
using System.Collections.Specialized;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Server.Oauth;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Fabric.Test.Util;
using Nancy;
using Nancy.Cookies;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiServer.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class XOauthLoginControllerPost : XOauthLoginController {

		private string vResponseType;
		private string vClientId;
		private string vRedirectUri;
		private string vSwitchMode;
		private string vState;

		private string vLoginAction;
		private string vCancelAction;
		private string vAllowAction;
		private string vDenyAction;
		private string vLogoutAction;

		private string vUsername;
		private string vPassword;
		private string vRememberMe;

		private OauthLoginController vLoginCtrl;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vResponseType = "code";
			vClientId = (uint)SetupUsers.AppId.FabSys+"";
			vRedirectUri = "http://"+SetupOauth.DomFab1+"/oauth/";
			vSwitchMode = "0";
			vState = FabricUtil.Code32;

			vLoggedUserId = 0;

			vLoginAction = null;
			vCancelAction = null;
			vAllowAction = null;
			vDenyAction = null;
			vLogoutAction = null;

			vUsername = null;
			vPassword = null;
			vRememberMe = null;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response TestPost() {
			var req = new Request("POST", "test", "test");

			req.Query.Add("response_type", vResponseType);
			req.Query.Add("client_id", vClientId);
			req.Query.Add("redirect_uri", vRedirectUri);
			req.Query.Add("switchMode", vSwitchMode);
			req.Query.Add("state", vState);

			req.Form.Add("CancelAction", vCancelAction);
			req.Form.Add("LogoutAction", vLogoutAction);
			req.Form.Add("LoginAction", vLoginAction);
			req.Form.Add("AllowAction", vAllowAction);
			req.Form.Add("DenyAction", vDenyAction);
			req.Form.Add("Username", vUsername);
			req.Form.Add("Password", vPassword);
			req.Form.Add("RememberMe", vRememberMe);

			FillRequestCookies(req);

			vLoginCtrl = new OauthLoginController(req, vApiCtx, OauthLoginController.Method.Post);
			return vLoginCtrl.Execute();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void CheckRedirectToRequest(Response pResult, string pRedirUri) {
			Assert.NotNull(pResult, "Result should be filled.");
			string loc = pResult.Headers["Location"];
			Assert.AreEqual(pRedirUri, loc, "Incorrect Header 'Location'.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckRedirectSuccess(Response pResult) {
			CheckRedirectSuccess(pResult, vRedirectUri, vState);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckScopeResult(OauthLoginController pController) {
			Assert.False(pController.LoginDto.ShowLoginPage, "Incorrect LoginDto.ShowLoginPage.");
			Assert.Null(pController.LoginDto.ScopeCode, "LoginDto.ScopeCode should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckError(Response pResult, GrantErrors pErr, GrantErrorDescs pDesc) {
			Assert.NotNull(pResult, "Result should be filled.");
			string loc = pResult.Headers["Location"];
			Assert.NotNull(loc, "Header 'Location' should be filled.");

			int qIndex = loc.IndexOf("?");
			Assert.Greater(qIndex, 0, "Redirect should have a querystring.");
			Assert.Less(qIndex, loc.Length-1, "Redirect should have a querystring.");

			string uri = loc.Substring(0, qIndex);
			Assert.AreEqual(vRedirectUri, uri, "Incorrect RedirectUri.");

			NameValueCollection q = TestUtil.BuildQuery(loc.Substring(qIndex+1));
			string desc = OauthGrantCore.ErrDescStrings[(int)pDesc];
			desc = desc.Replace(' ', '+');

			Assert.AreEqual(pErr.ToString(), q["error"], "Incorrect Error.");
			Assert.AreEqual(desc, q["error_description"], "Incorrect Error Description.");
			Assert.AreEqual(vState, q["state"], "Incorrect State.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckAuthCookie(Response pResult, bool pIsLoggedIn, DateTime pExpires) {
			Assert.NotNull(pResult, "Result should be filled.");

			INancyCookie cook = pResult.Cookies[0];

			if ( pIsLoggedIn ) {
				Assert.Less(1, cook.Value.Length, "Incorrect Value.");
			}
			else {
				Assert.AreEqual(string.Empty, cook.Value, "Incorrect Value.");
			}

			Assert.Greater(cook.Expires, pExpires.AddSeconds(-30), "Expires too soon.");
			Assert.LessOrEqual(cook.Expires, pExpires.AddSeconds(30), "Expires too late.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase(UserZach)]
		public void Cancel(SetupUsers.UserId? pLoggedUserId) {
			vCancelAction = "Cancel";
			vLoggedUserId = (pLoggedUserId == null ? 0 : (long)pLoggedUserId);

			Response result = TestPost();
			CheckError(result, GrantErrors.access_denied, GrantErrorDescs.LoginCancel);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Logout() {
			vLogoutAction = "Logout";
			vLoggedUserId = (long)UserZach;

			Response result = TestPost();
			CheckAuthCookie(result, false, DateTime.UtcNow.AddDays(-1));
			CheckRedirectToRequest(result, vRedirectUri);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null, "0")]
		[TestCase(null, "1")]
		[TestCase(UserMel, "0")]
		[TestCase(UserMel, "1")]
		public void LoginSuccess(SetupUsers.UserId? pLoggedUserId, string pSwitchMode) {
			vLoginAction = "Login";
			vUsername = "zachkinstner";
			vPassword = "asdfasdf";
			vLoggedUserId = (pLoggedUserId == null ? 0 : (long)pLoggedUserId);
			vSwitchMode = pSwitchMode;

			Response result = TestPost();
			CheckAuthCookie(result, true, DateTime.UtcNow.AddMinutes(20));
			CheckScopeResult(vLoginCtrl);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void LoginRemember(bool pRememberMe) {
			vLoginAction = "Login";
			vUsername = "zachkinstner";
			vPassword = "asdfasdf";
			vRememberMe = (pRememberMe ? "1" : "0");

			var exp = (pRememberMe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddMinutes(20));

			Response result = TestPost();
			CheckAuthCookie(result, true, exp);
			CheckScopeResult(vLoginCtrl);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("zach", "asdf")]
		[TestCase("", "")]
		public void LoginFailure(string pUsername, string pPassword) {
			vLoginAction = "Login";
			vUsername = pUsername;
			vPassword = pPassword;

			TestPost();
			FabOauthLogin login = vLoginCtrl.LoginDto;

			Assert.True(login.ShowLoginPage, "Incorrect LoginDto.ShowLoginPage.");
			Assert.AreEqual(int.Parse(vClientId), login.AppId, "Incorrect LoginDto.AppId.");
			Assert.AreEqual(0, login.LoggedUserId, "Incorrect LoginDto.LoggedUserId.");
			Assert.Null(login.LoggedUserName, "LoginDto.LoggedUserName should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("OriginalState")]
		[TestCase("1234")]
		[TestCase("")]
		[TestCase(null)]
		public void LoginScope(string pState) {
			vLoginAction = "Login";
			vClientId = (long)AppGal+"";
			vUsername = "zachkinstner";
			vPassword = "asdfasdf";
			if ( pState != "OriginalState" ) { vState = pState; }

			Response result = TestPost();
			CheckAuthCookie(result, true, DateTime.UtcNow.AddMinutes(20));
			CheckRedirectSuccess(result);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void PerformAllow() {
			vAllowAction = "Allow";
			vLoggedUserId = (long)UserZach;

			Response result = TestPost();
			CheckRedirectSuccess(result);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void PerformDeny() {
			vDenyAction = "Deny";
			vLoggedUserId = (long)UserZach;

			Response result = TestPost();
			CheckError(result, GrantErrors.access_denied, GrantErrorDescs.AccessDeny);
		}

	}

}
