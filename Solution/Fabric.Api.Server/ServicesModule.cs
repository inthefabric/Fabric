using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Server.Services;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class ServicesModule : NancyModule {

		private const string ApiVersion = "1.0.0.10f7771a29e1";
		private const string DbServerUrl = "http://localhost:9001/gremlin";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ServicesModule() {
			Log.ConfigureOnce();

			Get["/Root(.*)"] = (p => GetTraversal(Context));
			Get["/Spec"] = (p => GetSpec(Context));

			const string ao = "/Oauth";
			Get[ao] = (p => GetLogin(Context, OauthLoginController.Method.Get));
			Post[ao] = (p => GetLogin(Context, OauthLoginController.Method.Post));
			Get[ao+"/Logout"] = (p => GetOauth(Context, OauthController.Function.Logout));

			const string at = ao+"/AccessToken";
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
		private static Response GetTraversal(NancyContext pCtx) {
			var ac = new TraversalController(pCtx.Request, NewApiCtx(), new OauthTasks());
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