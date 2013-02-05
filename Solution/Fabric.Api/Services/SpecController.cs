using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Spec;
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
		private static FabSpec DocDto;
		private static string DocDtoJson;
		private static string ApiVers;

		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks,
							string pApiVers, Route pRoute) : base(pRequest, pApiCtx, pOauthTasks) {
			ApiVers = pApiVers;
			vRoute = pRoute;

			if ( ServiceDto == null ) {
				ServiceDto = FabHome.NewSpecService(true);
				ServiceDtoJson = ServiceDto.ToJson();

				var doc = new SpecDoc();
				DocDto = doc.GetFabSpec();
				DocDto.ApiVersion = ApiVers;
				DocDtoJson = DocDto.ToJson();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			switch ( vRoute ) {
				case Route.Home:
					return NewResponse(new FabRespJsonView(FabResp, ServiceDtoJson));

				case Route.Document:
					return NewResponse(new FabRespJsonView(FabResp, DocDtoJson));
			}

			return null;
		}

	}

}