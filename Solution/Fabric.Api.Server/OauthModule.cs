using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class OauthModule : NancyModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthModule() {
			Log.ConfigureOnce();

			Get["/api/oauth/access_token"] = (p => "Fabric OAuth: access_token");
			Get["/api/oauth/access_token_auth_code"] = (p => "Fabric OAuth: /access_token_auth_code");
			Get["/api/oauth/access_token_refresh"] = (p => "Fabric OAuth: access_token_refresh");
			Get["/api/oauth/access_token_client_credentials"] = 
				(p => "Fabric OAuth: access_token_client_credentials");
			Get["/api/oauth/access_token_client_dataprov"] =
				(p => "Fabric OAuth: access_token_client_dataprov");
		}

	}

}