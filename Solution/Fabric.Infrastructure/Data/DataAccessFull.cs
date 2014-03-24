using RexConnectClient.Core;
using Weaver.Exec.RexConnect;

namespace Fabric.New.Infrastructure.Data {

	/*================================================================================================*/
	public class DataAccessFull : DataAccess { //TEST: DataAccessFull


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Build(WeaverRequest pRequest, IDataContext pDataCtx) {
			vDataCtx = pDataCtx;
			vReq = pRequest;
			vRexConnCtx = new RexConnContext(vReq, vDataCtx.RexConnUrl, vDataCtx.RexConnPort);
		}

	}

}