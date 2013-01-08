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

			Get[aoAt] = (p => NewFunc.Access.ToResponse());
			Get[aoAt+"AuthCode"] = (p => NewFunc.AccessAuthCode.ToResponse());
			Get[aoAt+"Refresh"] = (p => NewFunc.AccessRefToken.ToResponse());
			Get[aoAt+"ClientCredentials"] = (p => NewFunc.AccessClientCred.ToResponse());
			Get[aoAt+"ClientDataProv"] = (p => NewFunc.AccessClientDataProv.ToResponse());

			Get[ao+"Logout"] = (p => NewFunc.Logout.ToResponse());

			Get[ao+"Login"] = (p => NewLogin.LoginGet());
			Post[ao+"Login"] = (p => NewLogin.LoginPost());
		}

		/*--------------------------------------------------------------------------------------------*/
		protected IOauthFuncs NewFunc {
			get {
				return new OauthFuncs(Context.Request.Query);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected IOauthLoginFuncs NewLogin {
			get {
				return new OauthLoginFuncs(Context.Request.Query, Context.Request.Form);
			}
		}

	}

}