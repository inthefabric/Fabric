using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Fabric.Api.Objects.Oauth;
using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Query;
using Fabric.Infrastructure.Util;
using Fabric.Test.Unit.Shared;
using Nancy.Cookies;
using Nancy.Testing;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace Fabric.Test.Integration.Api.Executors {

	/*================================================================================================*/
	public class XOauthExecutors : XExecutorBase {

		private static readonly Logger Log = Logger.Build<XOauthExecutors>();

		private string vGrantCode;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void UpdateGrant() {
			base.TestSetUp();

			vGrantCode = SetupOauth.GrantGalZach;

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.OauthGrantCode, vGrantCode)
					.SideEffect(
						new WeaverStatementSetProperty<Member>(x => x.OauthGrantExpires,
							DateTime.UtcNow.AddMinutes(10).Ticks)
					)
				.ToQuery();

			ExecuteTestQuery(q, "UpdateGrantExpiration");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IDictionary<string, string> BuildRequestAuthCookies(SetupUserId pUserId) {
			Cookie c = AuthUtil.CreateUserIdCookie((long)pUserId, false).Item1;

			var cookies = new Dictionary<string, string>();
			cookies.Add(c.Name, c.Value);
			return cookies;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void At() {
			UpdateGrant();

			var query = new Dictionary<string, string>();
			query.Add("grant_type", "authorization_code");
			query.Add("code", vGrantCode);
			query.Add("client_secret", SetupUsers.KinPhoGalSecret);
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			BrowserResponse br = Get("oauth/accessToken", query);
			FabOauthAccess result = AssertFabObject<FabOauthAccess>(br);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect TokenType.");

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AtFail() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("oauth/accessToken");
			Assert.AreEqual(HttpStatusCode.Forbidden, br.StatusCode, "Incorrect StatusCode.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Atac() {
			UpdateGrant();

			var query = new Dictionary<string, string>();
			query.Add("code", vGrantCode);
			query.Add("client_secret", SetupUsers.KinPhoGalSecret);
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			BrowserResponse br = Get("oauth/accessTokenAuthCode", query);
			FabOauthAccess result = AssertFabObject<FabOauthAccess>(br);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect TokenType.");

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Atr() {
			var query = new Dictionary<string, string>();
			query.Add("refresh_token", SetupOauth.RefreshGalZach);
			query.Add("client_secret", SetupUsers.KinPhoGalSecret);
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			BrowserResponse br = Get("oauth/accessTokenRefresh", query);
			FabOauthAccess result = AssertFabObject<FabOauthAccess>(br);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect TokenType.");

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Atcc() {
			var query = new Dictionary<string, string>();
			query.Add("client_id", (long)SetupAppId.KinPhoGal+"");
			query.Add("client_secret", SetupUsers.KinPhoGalSecret);
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			BrowserResponse br = Get("oauth/accessTokenClientCredentials", query);
			FabOauthAccess result = AssertFabObject<FabOauthAccess>(br);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect TokenType.");

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginIncomingError() {
			IsReadOnlyTest = true;

			var query = new Dictionary<string, string>();
			query.Add("error", "test");

			BrowserResponse br = Get("oauth/login", query);
			AssertBody(br);

			Assert.AreEqual(HttpStatusCode.OK, br.StatusCode, "Incorrect StatusCode.");
			TestUtil.AssertContains("Body", br.Body.AsString(), "<html>");
			TestUtil.AssertContains("Body", br.Body.AsString(), "Sorry! There was an issue");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPage() {
			IsReadOnlyTest = true;

			var query = new Dictionary<string, string>();
			query.Add("response_type", "code");
			query.Add("client_id", (long)SetupAppId.KinPhoGal+"");
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			BrowserResponse br = Get("oauth/login", query);
			AssertBody(br);

			Assert.AreEqual(HttpStatusCode.OK, br.StatusCode, "Incorrect StatusCode.");
			TestUtil.AssertContains("Body", br.Body.AsString(), "<html>");
			TestUtil.AssertContains("Body", br.Body.AsString(), "Username");
			TestUtil.AssertContains("Body", br.Body.AsString(), "Password");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginCode() {
			var query = new Dictionary<string, string>();
			query.Add("response_type", "code");
			query.Add("client_id", (long)SetupAppId.KinPhoGal+"");
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			IDictionary<string, string> reqCookies = BuildRequestAuthCookies(SetupUserId.Zach);

			BrowserResponse br = Get("oauth/login", query, reqCookies);
			IDictionary<string, string> result = AssertRedirect(br, SetupOauth.GrantUrlGalLoc);

			Assert.False(result.ContainsKey("error"), "No error should occur.");
			Assert.True(result.ContainsKey("code"), "Missing 'code' redirect parameter.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginScope() {
			var query = new Dictionary<string, string>();
			query.Add("response_type", "code");
			query.Add("client_id", (long)SetupAppId.Bookmarker+"");
			query.Add("redirect_uri", SetupOauth.GrantUrlBook);

			IDictionary<string, string> reqCookies = BuildRequestAuthCookies(SetupUserId.Ellie);

			BrowserResponse br = Get("oauth/login", query, reqCookies);
			AssertBody(br);

			Assert.AreEqual(HttpStatusCode.OK, br.StatusCode, "Incorrect StatusCode.");
			TestUtil.AssertContains("Body", br.Body.AsString(), "<html>");
			TestUtil.AssertContains("Body", br.Body.AsString(), "allow");
			TestUtil.AssertContains("Body", br.Body.AsString(), "deny");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginFail() {
			IsReadOnlyTest = true;

			var query = new Dictionary<string, string>();
			query.Add("response_type", "code");
			query.Add("client_id", "abcd");
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			BrowserResponse br = Get("oauth/login", query);
			IDictionary<string, string> result = AssertRedirect(br, SetupOauth.GrantUrlGalLoc);

			Assert.True(result.ContainsKey("error"), "An error should occur.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostCancel() {
			IsReadOnlyTest = true;

			var form = new Dictionary<string, string>();
			form.Add("cancel", "1");

			var query = new Dictionary<string, string>();
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			BrowserResponse br = Post("oauth/login", form, query);
			IDictionary<string, string> result = AssertRedirect(br, SetupOauth.GrantUrlGalLoc);

			Assert.True(result.ContainsKey("error"), "An error should occur.");
			Assert.AreEqual("access_denied", result["error"], "Incorrect Error.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostLogout() {
			IsReadOnlyTest = true;

			var form = new Dictionary<string, string>();
			form.Add("logout", "1");

			BrowserResponse br = Post("oauth/login", form);
			IDictionary<string, string> result = AssertRedirect(br, "oauth/login");

			Assert.False(result.ContainsKey("error"), "An error should occur.");

			INancyCookie[] cookies = br.Cookies.ToArray();
			Assert.AreEqual(1, cookies.Length, "Incorrect Cookies length.");

			INancyCookie c = cookies[0];
			Assert.AreEqual("FabricUserAuth", c.Name, "Incorrect cookie Name.");
			Assert.AreEqual("", c.Value, "Incorrect cookie Value.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostLoginComplete() {
			IsReadOnlyTest = true;

			var form = new Dictionary<string, string>();
			form.Add("login", "1");
			form.Add("Username", "zachkinstner");
			form.Add("Password", "asdfasdf");
			form.Add("RememberMe", "1");

			var query = new Dictionary<string, string>();
			query.Add("client_id", (long)SetupAppId.KinPhoGal+"");
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			BrowserResponse br = Post("oauth/login", form, query);
			IDictionary<string, string> result = AssertRedirect(br, SetupOauth.GrantUrlGalLoc);

			Assert.True(result.ContainsKey("code"), "Redirect should include a code.");
			Assert.AreEqual(32, result["code"].Length, "Incorrect code.");

			INancyCookie[] cookies = br.Cookies.ToArray();
			Assert.AreEqual(1, cookies.Length, "Incorrect Cookies length.");

			INancyCookie c = cookies[0];
			Assert.AreEqual("FabricUserAuth", c.Name, "Incorrect cookie Name.");
			Assert.AreNotEqual(null, c.Value, "Incorrect cookie Value.");
			Assert.AreNotEqual("", c.Value, "Incorrect cookie Value.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostLoginInvalidCredentials() {
			IsReadOnlyTest = true;

			var form = new Dictionary<string, string>();
			form.Add("login", "1");
			form.Add("Username", "zachkinstner");
			form.Add("Password", "BAD PASSWORD");
			form.Add("RememberMe", "1");

			var query = new Dictionary<string, string>();
			query.Add("client_id", (long)SetupAppId.KinPhoGal+"");
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			BrowserResponse br = Post("oauth/login", form, query);
			AssertBody(br);

			Assert.AreEqual(HttpStatusCode.OK, br.StatusCode, "Incorrect StatusCode.");
			TestUtil.AssertContains("Body", br.Body.AsString(), "<html>");
			TestUtil.AssertContains("Body", br.Body.AsString(), "Username");
			TestUtil.AssertContains("Body", br.Body.AsString(), "Password");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostLoginNoScope() {
			IsReadOnlyTest = true;

			var form = new Dictionary<string, string>();
			form.Add("login", "1");
			form.Add("Username", "EllieJoy");
			form.Add("Password", "iLOVEdaddy");
			form.Add("RememberMe", "1");

			var query = new Dictionary<string, string>();
			query.Add("client_id", (long)SetupAppId.Bookmarker+"");
			query.Add("redirect_uri", SetupOauth.GrantUrlBook);

			BrowserResponse br = Post("oauth/login", form, query);
			AssertBody(br);

			Assert.AreEqual(HttpStatusCode.OK, br.StatusCode, "Incorrect StatusCode.");
			TestUtil.AssertContains("Body", br.Body.AsString(), "<html>");
			TestUtil.AssertContains("Body", br.Body.AsString(), "allow");
			TestUtil.AssertContains("Body", br.Body.AsString(), "deny");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostAllow() {
			var form = new Dictionary<string, string>();
			form.Add("allow", "1");

			var query = new Dictionary<string, string>();
			query.Add("client_id", (long)SetupAppId.KinPhoGal+"");
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			IDictionary<string, string> reqCookies = BuildRequestAuthCookies(SetupUserId.Zach);

			BrowserResponse br = Post("oauth/login", form, query, reqCookies);
			IDictionary<string, string> result = AssertRedirect(br, SetupOauth.GrantUrlGalLoc);

			Assert.True(result.ContainsKey("code"), "Redirect should include a code.");
			Assert.AreEqual(32, result["code"].Length, "Incorrect code.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostDeny() {
			var form = new Dictionary<string, string>();
			form.Add("deny", "1");

			var query = new Dictionary<string, string>();
			query.Add("client_id", (long)SetupAppId.KinPhoGal+"");
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			IDictionary<string, string> reqCookies = BuildRequestAuthCookies(SetupUserId.Zach);

			BrowserResponse br = Post("oauth/login", form, query, reqCookies);
			IDictionary<string, string> result = AssertRedirect(br, SetupOauth.GrantUrlGalLoc);

			Assert.True(result.ContainsKey("error"), "An error should occur.");
			Assert.AreEqual("access_denied", result["error"], "Incorrect Error.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Logout() {
			var query = new Dictionary<string, string>();
			query.Add("access_token", SetupOauth.TokenGalZach);

			BrowserResponse br = Get("oauth/logout", query);
			FabOauthLogout result = AssertFabObject<FabOauthLogout>(br);
			Assert.AreEqual(1, result.Success, "Incorrect Success.");
		}

	}

}