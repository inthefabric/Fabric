using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class OauthModule : NancyModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthModule() {
			Log.ConfigureOnce();

			Get["/api/oauth/AccessToken"] = (p => "Fabric OAuth: AccessToken");
			Get["/api/oauth/AccessTokenAuthCode"] = (p => "Fabric OAuth: AuthCode");
			Get["/api/oauth/AccessTokenRefresh"] = (p => "Fabric OAuth: Refresh");
			Get["/api/oauth/AccessTokenClientCredentials"] = (p => "Fabric OAuth: ClientCredentials");
			Get["/api/oauth/AccessTokenClientDataProv"] = (p => "Fabric OAuth: ClientDataProv");
			Get["/api/oauth/Login"] = (p => "Fabric OAuth: Login");
			Get["/api/oauth/Logout"] = (p => "Fabric OAuth: Logout");
		}

	}

}