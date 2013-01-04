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
			const string aoAt = ao+"AccessToken";

			Get[aoAt] = (p => "Fabric OAuth: AccessToken");

			Get[aoAt+"AuthCode"] = (p => NewFunc(Context).AccessAuthCode.ToResponse());
			Get[aoAt+"Refresh"] = (p => NewFunc(Context).AccessRefToken.ToResponse());
			Get[aoAt+"ClientCredentials"] = (p => NewFunc(Context).AccessClientCred.ToResponse());
			Get[aoAt+"ClientDataProv"] = (p => NewFunc(Context).AccessClientDataProv.ToResponse());

			Get[ao+"Login"] = (p => "Fabric OAuth: Login");
			Get[ao+"Logout"] = (p => NewFunc(Context).Logout.ToResponse());
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthFuncs NewFunc(NancyContext pContext) {
			return new OauthFuncs(Context.Request.Query);
		}

	}

}