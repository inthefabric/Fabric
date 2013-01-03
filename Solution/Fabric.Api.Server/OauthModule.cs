using Fabric.Api.Server.Oauth;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class OauthModule : NancyModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthModule() {
			Log.ConfigureOnce();
			const string ao = "/api/oauth/";

			Get[ao+"AccessToken"] = (p => "Fabric OAuth: AccessToken");
			Get[ao+"AccessTokenAuthCode"] = (p => NewFunc(Context).OauthAccessAuthCode.ToResponse());
			Get[ao+"AccessTokenRefresh"] = (p => "Fabric OAuth: Refresh");
			Get[ao+"AccessTokenClientCredentials"] = 
				(p => NewFunc(Context).OauthAccessClientCred.ToResponse());
			Get[ao+"AccessTokenClientDataProv"] = (p => "Fabric OAuth: ClientDataProv");
			Get[ao+"Login"] = (p => "Fabric OAuth: Login");
			Get[ao+"Logout"] = (p => NewFunc(Context).Logout.ToResponse());
		}

		/*--------------------------------------------------------------------------------------------*/
		public OauthFuncs NewFunc(NancyContext pContext) {
			return new OauthFuncs(Context.Request.Query);
		}

	}

}