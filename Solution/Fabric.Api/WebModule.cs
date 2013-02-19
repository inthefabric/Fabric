using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public class WebModule : BaseModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WebModule() {
			const string web = "/Web";
			const string apps = web+"/Apps";
			const string users = web+"/Users";

			Post[apps] = (p => Spec(Context, WebController.Route.Apps));
			Post[users] = (p => Spec(Context, WebController.Route.Users));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response Spec(NancyContext pCtx, WebController.Route pRoute) {
			var sc = new WebController(pCtx.Request, NewApiCtx(), new OauthTasks(), pRoute);
			return sc.Execute();
		}

	}

}