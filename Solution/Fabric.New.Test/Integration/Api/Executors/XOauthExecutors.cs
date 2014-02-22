using System;
using System.Collections.Generic;
using System.Net;
using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Test.Unit.Shared;
using Nancy.Testing;
using NUnit.Framework;
using ServiceStack.Text;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace Fabric.New.Test.Integration.Api.Executors {

	/*================================================================================================*/
	public class XOauthExecutors : XExecutorBase {

		private static readonly Logger Log = Logger.Build<XOauthExecutors>();

		private string vGrantCode;
		private string vToken;


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
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginScope() {
			var query = new Dictionary<string, string>();
			query.Add("response_type", "code");
			query.Add("client_id", (long)SetupAppId.KinPhoGal+"");
			query.Add("redirect_uri", SetupOauth.GrantUrlGalLoc);

			Cookie c = AuthUtil.CreateUserIdCookie((long)SetupUserId.Zach, false).Item1;
			var cookies = new Dictionary<string, string>();
			cookies.Add(c.Name, c.Value);

			BrowserResponse br = Get("oauth/login", query, cookies);
			IDictionary<string, string> result = AssertRedirect(br, SetupOauth.GrantUrlGalLoc);
			Assert.False(result.ContainsKey("error"), "No error should occur.");
			Assert.True(result.ContainsKey("code"), "Missing 'code' redirect parameter.");
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
			BrowserResponse br = Post("oauth/login", new FabOauthLogin());
			FabOauthLogin result = AssertFabObject<FabOauthLogin>(br);
			Assert.Fail(JsonSerializer.SerializeToString(result));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostLogout() {
			BrowserResponse br = Post("oauth/login", new FabOauthLogin());
			FabOauthLogin result = AssertFabObject<FabOauthLogin>(br);
			Assert.Fail(JsonSerializer.SerializeToString(result));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostLogin() {
			BrowserResponse br = Post("oauth/login", new FabOauthLogin());
			FabOauthLogin result = AssertFabObject<FabOauthLogin>(br);
			Assert.Fail(JsonSerializer.SerializeToString(result));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostAllow() {
			BrowserResponse br = Post("oauth/login", new FabOauthLogin());
			FabOauthLogin result = AssertFabObject<FabOauthLogin>(br);
			Assert.Fail(JsonSerializer.SerializeToString(result));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPostDeny() {
			BrowserResponse br = Post("oauth/login", new FabOauthLogin());
			FabOauthLogin result = AssertFabObject<FabOauthLogin>(br);
			Assert.Fail(JsonSerializer.SerializeToString(result));
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