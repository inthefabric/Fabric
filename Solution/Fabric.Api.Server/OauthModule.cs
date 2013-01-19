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

			Get[at] = (p => ExecuteFunc(Context, OauthController.Function.Access));
			Get[at+"AuthCode"] = (p => ExecuteFunc(Context, OauthController.Function.AuthCode));
			Get[at+"Refresh"] = (p => ExecuteFunc(Context, OauthController.Function.RefToken));
			Get[at+"ClientCredentials"] = (p => ExecuteFunc(Context,
				OauthController.Function.ClientCred));
			Get[at+"ClientDataProv"] = (p => ExecuteFunc(Context,
				OauthController.Function.ClientDataProv));

			Get[ao+"Logout"] = (p => ExecuteFunc(Context, OauthController.Function.Logout));

			Get[ao+"Login"] = (p => ExecuteLogin(Context, OauthLoginController.Method.Get));
			Post[ao+"Login"] = (p => ExecuteLogin(Context, OauthLoginController.Method.Post));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Response ExecuteFunc(NancyContext pCtx, OauthController.Function pFunc) {
			var oc = new OauthController(pCtx.Request.Query, NewApiCtx(), pFunc);
			return oc.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response ExecuteLogin(NancyContext pCtx, OauthLoginController.Method pMethod) {
			Request r = pCtx.Request;
			var olc = new OauthLoginController(NewApiCtx(), r.Query, r.Form, r.Cookies, pMethod);
			return olc.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiContext NewApiCtx() {
			return new ApiContext(ApiModule.DbServerUrl);
		}

	}

}