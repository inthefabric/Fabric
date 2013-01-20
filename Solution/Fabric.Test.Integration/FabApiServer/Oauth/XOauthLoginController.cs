﻿using System.Collections.Specialized;
using Fabric.Api.Server.Util;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using Nancy;
using Nancy.Cookies;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiServer.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public abstract class XOauthLoginController : IntegTestBase {

		protected long vLoggedUserId;
		protected TestApiContext vApiCtx;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vLoggedUserId = 0;
			vApiCtx = new TestApiContext();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void FillRequestCookies(Request pReq) {
			if ( vLoggedUserId <= 0 ) {
				return;
			}

			NancyCookie c = NancyUtil.NewUserCookieForTesting(vLoggedUserId);
			pReq.Cookies.Add(c.Name, c.Value);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void CheckRedirectSuccess(Response pResp, string pRedirectUri, string pState) {
			Assert.NotNull(pResp, "Result should be filled.");
			Assert.True(pResp.Headers.ContainsKey("Location"), "Header 'Location' is missing.");
			string loc = pResp.Headers["Location"];
			Assert.NotNull(loc, "Header 'Location' should be filled.");

			int qIndex = loc.IndexOf("?");
			Assert.Greater(qIndex, 0, "Redirect should have a querystring.");
			Assert.Less(qIndex, loc.Length-1, "Redirect should have a querystring.");

			string uri = loc.Substring(0, qIndex);
			Assert.AreEqual(pRedirectUri, uri, "Incorrect RedirectUri.");

			NameValueCollection q = TestUtil.BuildQuery(loc.Substring(qIndex+1));

			Assert.NotNull(q["code"], "Missing Code.");
			Assert.AreEqual(32, q["code"].Length, "Incorrect Code.");
			Assert.AreEqual(pState ?? "", q["state"], "Incorrect State.");
		}

	}

}