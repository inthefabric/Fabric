using RexConnectClient.Core.Cache;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public class DataContext : IDataContext {

		public string RexConnUrl { get; private set; }
		public int RexConnPort { get; private set; }
		public IRexConnCacheProvider RexConnCacheProv { get; private set; }
		public string ResumeSessionId { get; private set; }
		public bool SetCommandIds { get; private set; }
		public bool OmitCommandTimers { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataContext(string pRexConnUrl, int pRexConnPort, IRexConnCacheProvider pRexConnCache,
							string pSessionId=null, bool pSetCmdIds=false, bool pOmitCmdTimers=true) {
			RexConnUrl = pRexConnUrl;
			RexConnPort = pRexConnPort;
			RexConnCacheProv = pRexConnCache;
			ResumeSessionId = pSessionId;
			SetCommandIds = pSetCmdIds;
			OmitCommandTimers = pOmitCmdTimers;
		}

	}

}