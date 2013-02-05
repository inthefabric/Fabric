using Fabric.Api.Internal.Setups;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public class ServicesModule : NancyModule {

		private const string ApiVersion = "1.0.1.50fef226b57e";
		private const string DbServerUrl = "http://localhost:9001/gremlin";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ServicesModule() {
			Log.ConfigureOnce();

			Get["/"] = (p => GetHome(Context));
			
			Get["/Traversal"] = (p => GetTraversal(Context, TraversalController.Route.Home));
			Get["/Traversal/Root"] = (p => GetTraversal(Context, TraversalController.Route.Root));
			Get["/Traversal/Root/(.*)"] = (p => GetTraversal(Context, TraversalController.Route.Root));

			Get["/Spec"] = (p => GetSpec(Context, SpecController.Route.Home));
			Get["/Spec/Full"] = (p => GetSpec(Context, SpecController.Route.Document));

			const string ao = "/Oauth";
			Get[ao] = (p => GetOauth(Context, OauthController.Route.Home));

			Get[ao+"/Login"] = (p => GetOaLogin(Context));
			Post[ao+"/Login"] = (p => GetOaLogin(Context));
			Get[ao+"/Logout"] = (p => GetOaAcc(Context, OauthAccessController.Route.Logout));

			const string at = ao+"/AccessToken";
			Get[at] = (p => GetOaAcc(Context, OauthAccessController.Route.Access));
			Get[at+"AuthCode"] = (p => GetOaAcc(Context, OauthAccessController.Route.AuthCode));
			Get[at+"Refresh"] = (p => GetOaAcc(Context, OauthAccessController.Route.RefToken));
			Get[at+"ClientCredentials"] = (p => GetOaAcc(Context,
				OauthAccessController.Route.ClientCred));
			Get[at+"ClientDataProv"] = (p => GetOaAcc(Context,
				OauthAccessController.Route.ClientDataProv));

			//Get["/Internal/Setup"] = (p => GetInternalSetup(Context));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Response GetHome(NancyContext pCtx) {
			var ac = new HomeController(pCtx.Request, NewApiCtx(), new OauthTasks());
			return ac.Execute();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static Response GetTraversal(NancyContext pCtx, TraversalController.Route pRoute) {
			var ac = new TraversalController(pCtx.Request, NewApiCtx(), new OauthTasks(), pRoute);
			return ac.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetSpec(NancyContext pCtx, SpecController.Route pFunc) {
			var sc = new SpecController(pCtx.Request, NewApiCtx(), new OauthTasks(), ApiVersion, pFunc);
			return sc.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetOauth(NancyContext pCtx, OauthController.Route pFunc) {
			var sc = new OauthController(pCtx.Request, NewApiCtx(), new OauthTasks(), pFunc);
			return sc.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetOaAcc(NancyContext pCtx, OauthAccessController.Route pFunc) {
			var oc = new OauthAccessController(pCtx.Request, NewApiCtx(), pFunc);
			return oc.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetOaLogin(NancyContext pCtx) {
			var olc = new OauthLoginController(pCtx.Request, NewApiCtx());
			return olc.Execute();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Response GetInternalSetup(NancyContext pCtx) {
			var ac = new SetupController(pCtx.Request, NewApiCtx());
			return ac.Execute();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiContext NewApiCtx() {
			return new ApiContext(DbServerUrl);
		}

	}

}