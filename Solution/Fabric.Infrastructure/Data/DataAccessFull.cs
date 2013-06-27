using Fabric.Infrastructure.Api;
using RexConnectClient.Core;
using Weaver.Exec.RexConnect;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public class DataAccessFull : DataAccess {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Build(WeaverRequest pRequest, IApiContext pApiCtx) {
			vApiCtx = pApiCtx;
			vReq = pRequest;
			vRexConnCtx = new RexConnContext(vReq, pApiCtx.RexConnUrl, pApiCtx.RexConnPort);
		}

	}

}