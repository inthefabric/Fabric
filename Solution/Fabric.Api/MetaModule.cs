using Fabric.Api.Dto;
using Fabric.Api.Services;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public class MetaModule : BaseModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MetaModule() {
			const string meta = FabHome.MetaUri;
			const string spec = meta+FabHome.MetaSpecUri;
			const string vers = meta+FabHome.MetaVersionUri;
			const string time = meta+FabHome.MetaTimeUri;

			Get[meta] = (p => Meta(Context, MetaController.Route.Home));
			Get[spec] = (p => Meta(Context, MetaController.Route.Spec));
			Get[vers] = (p => Meta(Context, MetaController.Route.Version));
			Get[time] = (p => Meta(Context, MetaController.Route.Time));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response Meta(NancyContext pCtx, MetaController.Route pRoute) {
			var mc = new MetaController(pCtx.Request, NewApiCtx(), Version, pRoute);
			return mc.Execute();
		}

	}

}