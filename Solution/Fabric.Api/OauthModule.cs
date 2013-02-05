using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public class OauthModule : BaseModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthModule() {
			const string oauth = FabServices.OauthUri;
			const string at = oauth+FabServices.OauthAccessTokenUri;
			const string atac = oauth+FabServices.OauthAccessTokenAuthCodeUri;
			const string atr = oauth+FabServices.OauthAccessTokenRefreshUri;
			const string atcc = oauth+FabServices.OauthAccessTokenClientCredentialsUri;
			const string atcdp = oauth+FabServices.OauthAccessTokenClientDataProvUri;
			const string login = oauth+FabServices.OauthLoginUri;
			const string logout = oauth+FabServices.OauthLogoutUri;

			Get[oauth] = (p => Oauth(Context, OauthController.Route.Home));

			Get[login] = (p => Login(Context));
			Post[login] = (p => Login(Context));
			Get[logout] = (p => Acc(Context, OauthAccessController.Route.Logout));
			
			Get[at] = (p => Acc(Context, OauthAccessController.Route.Access));
			Get[atac] = (p => Acc(Context, OauthAccessController.Route.AuthCode));
			Get[atr] = (p => Acc(Context, OauthAccessController.Route.RefToken));
			Get[atcc] = (p => Acc(Context, OauthAccessController.Route.ClientCred));
			Get[atcdp] = (p => Acc(Context, OauthAccessController.Route.ClientDataProv));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Response Oauth(NancyContext pCtx, OauthController.Route pRoute) {
			var sc = new OauthController(pCtx.Request, NewApiCtx(), new OauthTasks(), pRoute);
			return sc.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response Acc(NancyContext pCtx, OauthAccessController.Route pRoute) {
			var oc = new OauthAccessController(pCtx.Request, NewApiCtx(), pRoute);
			return oc.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response Login(NancyContext pCtx) {
			var olc = new OauthLoginController(pCtx.Request, NewApiCtx());
			return olc.Execute();
		}

	}

}