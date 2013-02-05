using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public class TraversalModule : BaseModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalModule() {
			const string trav = FabHome.TravUri;
			const string root = trav+FabHome.TravRootUri;

			Get[trav] = (p => Trav(Context, TraversalController.Route.Home));
			Get[root] = (p => Trav(Context, TraversalController.Route.Root));
			Get[root+"/(.*)"] = (p => Trav(Context, TraversalController.Route.Root));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response Trav(NancyContext pCtx, TraversalController.Route pRoute) {
			var ac = new TraversalController(pCtx.Request, NewApiCtx(), new OauthTasks(), pRoute);
			return ac.Execute();
		}

	}

}