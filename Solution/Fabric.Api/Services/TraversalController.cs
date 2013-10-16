using System.Linq;
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

		//Fabric: 166.78.102.115
		private static readonly string[] Blacklist = new[] { //TODO: remove once robots.txt kicks in
			"66.249.73.200", //GoogleBot
			"66.249.64.8", //GoogleBot
			"198.143.187.114", //BlexBot
			"180.76.5.196", //Baidu
		};

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
			string incomingIp = NancyReq.UserHostAddress;

			if ( Blacklist.Any(ip => (incomingIp == ip)) ) {
				Log.Info(GetType().Name+" blocked "+incomingIp+".");
				return null;
			}

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

			switch ( vRoute ) {
				case Route.Root:
					apiUri = apiUri.Substring(TravRootUriLength);
					break;

				case Route.ActiveApp:
				case Route.ActiveUser:
				case Route.ActiveMember:
					apiUri = apiUri.Substring(TravUriLength);
					break;
			}

			var tb = new TraversalBuilder(ApiCtx, FabResp, apiUri);
			TraversalModel mod = tb.BuildModel();
			HttpStatusCode stat = NancyUtil.ToNancyStatus(mod.HttpStatus);

			return (NancyUtil.ShouldReturnHtml(NancyReq) ?
				NancyUtil.BuildHtmlResponse(stat, new TraversalHtmlView(mod).GetContent()) :
				NancyUtil.BuildJsonResponse(stat, new TraversalJsonView(mod).GetContent())
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string BuildGraphiteKey() {
			string path = NancyReq.Path.ToLower().Substring(1);
			string[] segs = path.Split('/');
			string key = NancyReq.Method+"-"+segs[0];

			if ( segs.Length > 1 ) {
				key += "-"+segs[1];

				if ( segs.Length > 2 ) {
					key += "-"+segs[2].Split('(')[0].Split('?')[0];
				}
			}

			return "req."+key;
		}

	}

}