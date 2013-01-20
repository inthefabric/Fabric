using Fabric.Api.Dto.Spec;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Server.Common;
using Fabric.Api.Server.Root.Views;
using Fabric.Api.Server.Util;
using Fabric.Api.Spec;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.Root {

	/*================================================================================================*/
	public class SpecController : FabResponseController {

		private static SpecDoc Doc;
		private static FabSpec Dto;
		private static string ResponseJson;
		private static string ApiVers;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks,
											string pApiVers) : base(pRequest, pApiCtx, pOauthTasks) {
			ApiVers = pApiVers;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			FabResp.StartEvent();
			FabResp.HttpStatus = (int)HttpStatusCode.OK;

			if ( Doc == null ) {
				Doc = new SpecDoc();

				Dto = Doc.GetFabSpec();
				Dto.ApiVersion = ApiVers;

				ResponseJson = new SpecJsonView(FabResp, Dto.ToJson()).GetContent();
			}

			ExecuteOauthLookup();
			return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, ResponseJson);
		}

	}

}