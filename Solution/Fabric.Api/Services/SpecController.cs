using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Spec;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services.Views;
using Fabric.Api.Spec;
using Fabric.Api.Util;
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
		private static FabSpec DocDto;
		private static string ApiVers;

		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks,
							string pApiVers, Route pRoute) : base(pRequest, pApiCtx, pOauthTasks) {
			ApiVers = pApiVers;
			vRoute = pRoute;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			FabResp.StartEvent();
			FabResp.HttpStatus = (int)HttpStatusCode.OK;

			string json = "";

			switch ( vRoute ) {
				case Route.Home:
					json = GetServiceJson();
					break;

				case Route.Document:
					json = GetDocJson();
					break;
			}


			ExecuteOauthLookup();
			return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, json);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string GetServiceJson() {
			if ( ServiceDto == null ) {
				ServiceDto = FabServices.NewSpecService(true);
			}

			return new HomeJsonView(FabResp, ServiceDto.ToJson()).GetContent();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetDocJson() {
			if ( DocDto == null ) {
				var doc = new SpecDoc();
				DocDto = doc.GetFabSpec();
				DocDto.ApiVersion = ApiVers;
			}

			return new HomeJsonView(FabResp, DocDto.ToJson()).GetContent();
		}

	}

}