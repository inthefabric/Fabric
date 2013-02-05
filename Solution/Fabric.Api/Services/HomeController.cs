using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class HomeController : FabResponseController {

		private static FabServices Dto;
		private static string DtoJson;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public HomeController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks) : 
																base(pRequest, pApiCtx, pOauthTasks) {
			if ( Dto == null ) {
				Dto = new FabServices();
				DtoJson = Dto.ToJson();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			return NewResponse(new FabRespJsonView(FabResp, DtoJson));
		}

	}

}