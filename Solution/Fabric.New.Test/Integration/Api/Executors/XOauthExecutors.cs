using System;
using System.Collections.Generic;
using System.Configuration;
using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using RexConnectClient.Core.Cache;
using ServiceStack.Text;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;

namespace Fabric.New.Test.Integration.Api.Executors {

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

			var dataCtx = new DataContext(
				ConfigurationManager.AppSettings["Dev_NodeIp1"],
				int.Parse(ConfigurationManager.AppSettings["Dev_RexConnPort"]),
				new RexConnCacheProvider()
			);

			var acc = new DataAccess();
			acc.Build(dataCtx);
			acc.SetLoggingHook((a, b, c) => Log.Debug(a+" / "+b+" / "+c));
			acc.AddQuery(q);
			acc.Execute("Test-UpdateGrantExpiration");
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
		public void Login() {
			BrowserResponse br = Get("oauth/login");
			FabOauthLogin result = AssertFabObject<FabOauthLogin>(br);
			Assert.Fail(JsonSerializer.SerializeToString(result));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginPost() {
			BrowserResponse br = Post("oauth/login", new FabOauthLogin());
			FabOauthLogin result = AssertFabObject<FabOauthLogin>(br);
			Assert.Fail(JsonSerializer.SerializeToString(result));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Logout() {
			BrowserResponse br = Get("oauth/logout");
			FabOauthLogin result = AssertFabObject<FabOauthLogin>(br);
			Assert.Fail(JsonSerializer.SerializeToString(result));
		}

	}

}