using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class OauthController : FabResponseController {

		public enum Route {
			Home
		}

		private static FabService ServiceDto;
		private static string ServiceDtoJson;

		private readonly Route vRoute;
		


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthController(Request pRequest, IApiContext pApiCtx, IOauthTasks pTasks,
													Route pRoute) : base(pRequest, pApiCtx, pTasks) {
			vRoute = pRoute;

			if ( ServiceDto == null ) {
				ServiceDto = FabHome.NewOauthService(true);
				ServiceDtoJson = ServiceDto.ToJson();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			switch ( vRoute ) {
				case Route.Home:
					return NewFabJsonResponse(ServiceDtoJson);
			}

			return null;
		}

	}

}