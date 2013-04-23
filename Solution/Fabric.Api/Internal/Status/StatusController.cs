using Fabric.Api.Common;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Internal.Status {

	/*================================================================================================*/
	public class StatusController : Controller {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public StatusController(Request pRequest, IApiContext pApiCtx) : base(pRequest, pApiCtx) {
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildResponse() {
			return 
				"<h3>Status</h3>"+
				"<ul>"+
					"<li>Nothing to show right now.</li>"+
				"</ul>";
		}

	}

}