using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services.Views;
using Fabric.Api.Util;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class HomeController : FabResponseController {

		private static FabServices Dto;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public HomeController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks) : 
																base(pRequest, pApiCtx, pOauthTasks) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			FabResp.StartEvent();
			FabResp.HttpStatus = (int)HttpStatusCode.OK;

			if ( Dto == null ) {
				Dto = new FabServices();
			}

			string json = new HomeJsonView(FabResp, Dto.ToJson()).GetContent();

			ExecuteOauthLookup();
			return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, json);
		}

	}

}