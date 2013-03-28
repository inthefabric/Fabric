using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services.Views;
using Fabric.Api.Traversal;
using Fabric.Api.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class TraversalController : FabResponseController {

		public enum Route {
			Home,
			Root,
			ActiveApp,
			ActiveUser,
			ActiveMember
		}

		private static FabService ServiceDto;
		private static string ServiceDtoJson;
		private static int TravUriLength;
		private static int TravRootUriLength;

		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks,
												Route pRoute) : base(pRequest, pApiCtx, pOauthTasks) {
			vRoute = pRoute;

			if ( ServiceDto == null ) {
				ServiceDto = FabHome.NewTraversalService(true);
				ServiceDtoJson = ServiceDto.ToJson();
				TravUriLength = FabHome.TravUri.Length;
				TravRootUriLength = TravUriLength+FabHome.TravRootUri.Length;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			switch ( vRoute ) {
				case Route.Home: 
					return BuildHomeResponse();
					
				case Route.Root: 
				case Route.ActiveApp:
				case Route.ActiveUser:
				case Route.ActiveMember:
					return BuildRootResponse();
			}

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildHomeResponse() {
			return NewFabJsonResponse(ServiceDtoJson);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildRootResponse() {
			string apiUri = NancyReq.Path;
			bool startAtRoot = true;

			switch ( vRoute ) {
				case Route.Root:
					apiUri = apiUri.Substring(TravRootUriLength);
					break;

				case Route.ActiveApp:
				case Route.ActiveUser:
				case Route.ActiveMember:
					apiUri = apiUri.Substring(TravUriLength);
					startAtRoot = false;
					break;
			}

			var tb = new TraversalBuilder(ApiCtx, FabResp, apiUri, startAtRoot);
			TraversalModel mod = tb.BuildModel();
			HttpStatusCode stat = NancyUtil.ToNancyStatus(mod.HttpStatus);

			return (NancyUtil.ShouldReturnHtml(NancyReq) ?
				NancyUtil.BuildHtmlResponse(stat, new TraversalHtmlView(mod).GetContent()) :
				NancyUtil.BuildJsonResponse(stat, new TraversalJsonView(mod).GetContent())
			);
		}

	}

}