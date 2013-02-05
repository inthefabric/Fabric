using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public class SpecModule : BaseModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecModule() {
			const string spec = FabServices.SpecUri;
			const string full = spec+FabServices.SpecDocUri;

			Get[spec] = (p => Spec(Context, SpecController.Route.Home));
			Get[full] = (p => Spec(Context, SpecController.Route.Document));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response Spec(NancyContext pCtx, SpecController.Route pRoute) {
			var sc = new SpecController(pCtx.Request, NewApiCtx(), new OauthTasks(), ApiVersion,pRoute);
			return sc.Execute();
		}

	}

}