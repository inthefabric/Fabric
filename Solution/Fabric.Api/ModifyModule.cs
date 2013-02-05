using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public class ModifyModule : BaseModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ModifyModule() {
			const string mod = FabHome.ModUri;
			const string apps = mod+FabHome.ModAppsUri;

			Get[mod] = (p => Spec(Context, ModifyController.Route.Home));
			Post[apps] = (p => Spec(Context, ModifyController.Route.Apps));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response Spec(NancyContext pCtx, ModifyController.Route pRoute) {
			var sc = new ModifyController(pCtx.Request, NewApiCtx(), new OauthTasks(), pRoute);
			return sc.Execute();
		}

	}

}