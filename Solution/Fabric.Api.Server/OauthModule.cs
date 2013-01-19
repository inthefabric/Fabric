using Fabric.Api.Server.Oauth;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class OauthModule : NancyModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthModule() {
			Log.ConfigureOnce();

			const string ao = "/api/oauth/";
			const string at = ao+"AccessToken";

			Get[at] = (p => ExecuteFunc(Context, OauthFuncs.Function.Access));
			Get[at+"AuthCode"] = (p => ExecuteFunc(Context, OauthFuncs.Function.AuthCode));
			Get[at+"Refresh"] = (p => ExecuteFunc(Context, OauthFuncs.Function.RefToken));
			Get[at+"ClientCredentials"] = (p => ExecuteFunc(Context, OauthFuncs.Function.ClientCred));
			Get[at+"ClientDataProv"] = (p => ExecuteFunc(Context, OauthFuncs.Function.ClientDataProv));

			Get[ao+"Logout"] = (p => ExecuteFunc(Context, OauthFuncs.Function.Logout));

			Get[ao+"Login"] = (p => NewLogin().LoginGet());
			Post[ao+"Login"] = (p => NewLogin().LoginPost());
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response ExecuteFunc(NancyContext pContext, OauthFuncs.Function pFunc) {
			var funcs = new OauthFuncs(pContext.Request.Query);
			return funcs.Execute(pFunc);
		}

		/*--------------------------------------------------------------------------------------------*/
		private IOauthLoginFuncs NewLogin() {
			return new OauthLoginFuncs(new ApiContext(ApiModule.DbServerUrl), Context.Request.Query, 
				Context.Request.Form, Context.Request.Cookies);
		}

	}

}