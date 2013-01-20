using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Server.Oauth;
using Fabric.Api.Server.Root;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class RootModule : NancyModule {

		private const string ApiVersion = "1.0.0.10f7771a29e1";
		private const string DbServerUrl = "http://localhost:9001/gremlin";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootModule() {
			Log.ConfigureOnce();

			Get["/(.*)"] = (p => GetRoot(Context));
			Get["/spec"] = (p => GetSpec(Context));

			const string ao = "/oauth/";
			Get[ao+"Logout"] = (p => GetOauth(Context, OauthController.Function.Logout));
			Get[ao+"Login"] = (p => GetLogin(Context, OauthLoginController.Method.Get));
			Post[ao+"Login"] = (p => GetLogin(Context, OauthLoginController.Method.Post));

			const string at = ao+"AccessToken";
			Get[at] = (p => GetOauth(Context, OauthController.Function.Access));
			Get[at+"AuthCode"] = (p => GetOauth(Context, OauthController.Function.AuthCode));
			Get[at+"Refresh"] = (p => GetOauth(Context, OauthController.Function.RefToken));
			Get[at+"ClientCredentials"] = (p => GetOauth(Context,
				OauthController.Function.ClientCred));
			Get[at+"ClientDataProv"] = (p => GetOauth(Context,
				OauthController.Function.ClientDataProv));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Response GetRoot(NancyContext pCtx) {
			var ac = new ApiController(pCtx.Request, NewApiCtx(), new OauthTasks());
			return ac.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetSpec(NancyContext pCtx) {
			var sc = new SpecController(pCtx.Request, NewApiCtx(), new OauthTasks(), ApiVersion);
			return sc.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetOauth(NancyContext pCtx, OauthController.Function pFunc) {
			var oc = new OauthController(pCtx.Request, NewApiCtx(), pFunc);
			return oc.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetLogin(NancyContext pCtx, OauthLoginController.Method pMethod) {
			var olc = new OauthLoginController(pCtx.Request, NewApiCtx(), pMethod);
			return olc.Execute();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiContext NewApiCtx() {
			return new ApiContext(DbServerUrl);
		}

	}

}