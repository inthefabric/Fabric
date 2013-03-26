using Fabric.Api.Common;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Internal.Status {

	/*================================================================================================*/
	public class StatusController : Controller {

		public enum Route {
			ClassNameCache
		}

		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public StatusController(Request pRequest, IApiContext pApiCtx, Route pRoute) :
																			base(pRequest, pApiCtx) {
			vRoute = pRoute;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildResponse() {
			switch ( vRoute ) {
				case Route.ClassNameCache:
					return "Load index: "+ApiCtx.ClassNameCache.GetLoadIndex()+
						" (complete = "+ApiCtx.ClassNameCache.IsLoadComplete()+")";
			}

			return "Unknown route: "+vRoute;
		}

	}

}