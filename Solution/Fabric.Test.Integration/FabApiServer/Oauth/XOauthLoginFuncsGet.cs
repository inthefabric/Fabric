using Fabric.Api.Dto.Oauth;
using Fabric.Api.Server.Oauth;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Nancy;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiServer.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class XOauthLoginFuncsGet : XOauthLoginFuncs {

		private string vResponseType;
		private string vClientId;
		private string vRedirectUri;
		private string vSwitchMode;
		private string vState;
		private string vError;

		private OauthLoginFuncs vLoginFuncs;


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
			var query = new DynamicDictionary();
			query.Add("response_type", vResponseType);
			query.Add("client_id", vClientId);
			query.Add("redirect_uri", vRedirectUri);
			query.Add("switchMode", vSwitchMode);
			query.Add("state", vState);
			query.Add("error", vError);

			var form = new DynamicDictionary();

			vLoginFuncs = new OauthLoginFuncs(vApiCtx, query, form, GetRequestCookies());
			return vLoginFuncs.LoginGet();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("0")]
		[TestCase("1")]
		public virtual void Unsigned(string pSwitchMode) {
			vSwitchMode = pSwitchMode;

			TestGet();
			FabOauthLogin login = vLoginFuncs.LoginDto;

			Assert.True(login.ShowLoginPage, "Incorrect Login.ShowLoginPage.");
			Assert.AreEqual(int.Parse(vClientId), login.AppId, "Incorrect Login.AppId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null, false)]
		[TestCase("0", false)]
		[TestCase("1", true)]
		public virtual void Signed(string pSwitchMode, bool pShowLoginPage) {
			vSwitchMode = pSwitchMode;
			vLoggedUserId = (long)UserZach;

			TestGet();
			FabOauthLogin login = vLoginFuncs.LoginDto;

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
		public virtual void AlreadyAllowedScope(string pState) {
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
		public virtual void Error(string pError) {
			vError = pError;
			TestGet();
		}

	}

}
