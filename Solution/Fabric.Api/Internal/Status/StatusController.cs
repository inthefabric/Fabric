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
				"<h3>ClassNameCache</h3>"+
				"<ul>"+
					"<li>Load Complete: "+ApiCtx.ClassNameCache.IsLoadComplete()+"</li>"+
					"<li>Load Index: "+ApiCtx.ClassNameCache.GetLoadIndex()+"</li>"+
					"<li>Key Count: "+ApiCtx.ClassNameCache.GetKeyCount()+"</li>"+
				"</ul>";
		}

	}

}