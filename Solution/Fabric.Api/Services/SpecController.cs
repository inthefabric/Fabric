using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Spec;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class SpecController : FabResponseController {

		public enum Route {
			Home,
			Document
		}

		private static FabService ServiceDto;
		private static string ServiceDtoJson;

		private readonly string vApiVers;
		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks,
							string pApiVers, Route pRoute) : base(pRequest, pApiCtx, pOauthTasks) {
			vApiVers = pApiVers;
			vRoute = pRoute;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			if ( ServiceDto == null ) {
				ServiceDto = FabHome.NewSpecService(true);
				ServiceDtoJson = ServiceDto.ToJson();
			}

			switch ( vRoute ) {
				case Route.Home:
					return NewResponse(new FabRespJsonView(FabResp, ServiceDtoJson));

				case Route.Document:
					var getDoc = new GetDocument(vApiVers);
					return NewResponse(new FabRespJsonView(FabResp, getDoc.Go(ApiCtx)));
			}

			return null;
		}

	}

}