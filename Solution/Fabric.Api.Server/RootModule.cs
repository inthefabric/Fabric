using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Server.Oauth;
using Fabric.Api.Server.Root;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class RootModule : NancyModule {

		public const string ApiVersion = "1.0.0.10f7771a29e1";
		public const string DbServerUrl = "http://localhost:9001/gremlin";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootModule() {
			Log.ConfigureOnce();

			Get["/(.*)"] = (p => GetRoot(Context));

			////

			/*Get["/setup"] = (p => new SetupRoutine(Context).GetResponse());
			Get["/graph/json"] = (p => new GraphJson(Context).GetResponse());
			Get["/graph"] = (p => new GraphView(this).GetResponse());
			Get["/tables/browse/(.*)"] = (p => new TableBrowser(this).GetResponse());*/

			////
			
			/*Get["/spec"] = (p => new ApiSpecBuilder(Context).GetResponse());
			Get["/spec/apiresponse"] = (p => new ApiSpecBuilder(Context, "res").GetResponse());
			Get["/spec/dtolist/{name}"] = (p => new ApiSpecBuilder(Context, "dto").GetResponse());
			Get["/spec/functionlist/{name}"] = (p => new ApiSpecBuilder(Context, "fun").GetResponse());*/

			////

			const string ao = "/api/oauth/";
			const string at = ao+"AccessToken";

			Get[at] = (p => GetOauth(Context, OauthController.Function.Access));
			Get[at+"AuthCode"] = (p => GetOauth(Context, OauthController.Function.AuthCode));
			Get[at+"Refresh"] = (p => GetOauth(Context, OauthController.Function.RefToken));
			Get[at+"ClientCredentials"] = (p => GetOauth(Context,
				OauthController.Function.ClientCred));
			Get[at+"ClientDataProv"] = (p => GetOauth(Context,
				OauthController.Function.ClientDataProv));

			Get[ao+"Logout"] = (p => GetOauth(Context, OauthController.Function.Logout));

			Get[ao+"Login"] = (p => GetLogin(Context, OauthLoginController.Method.Get));
			Post[ao+"Login"] = (p => GetLogin(Context, OauthLoginController.Method.Post));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Response GetRoot(NancyContext pContext) {
			var aq = new ApiController(pContext.Request, NewApiCtx(), new OauthTasks());
			return aq.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetOauth(NancyContext pCtx, OauthController.Function pFunc) {
			var oc = new OauthController(pCtx.Request, NewApiCtx(), pFunc);
			return oc.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetLogin(NancyContext pCtx, OauthLoginController.Method pMethod) {
			Request r = pCtx.Request;
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