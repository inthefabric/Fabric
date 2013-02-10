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
			const string app = trav+FabHome.TravAppUri;
			const string user = trav+FabHome.TravUserUri;
			const string mem = trav+FabHome.TravMemberUri;

			Get[trav] = (p => Trav(Context, TraversalController.Route.Home));
			Get[root] = (p => Trav(Context, TraversalController.Route.Root));
			Get[root+"/(.*)"] = (p => Trav(Context, TraversalController.Route.Root));
			Get[app] = (p => Trav(Context, TraversalController.Route.CurrApp));
			Get[user] = (p => Trav(Context, TraversalController.Route.CurrUser));
			Get[mem] = (p => Trav(Context, TraversalController.Route.CurrMember));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response Trav(NancyContext pCtx, TraversalController.Route pRoute) {
			var ac = new TraversalController(pCtx.Request, NewApiCtx(), new OauthTasks(), pRoute);
			return ac.Execute();
		}

	}

}