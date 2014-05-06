using Fabric.Infrastructure.Cache;
using RexConnectClient.Core.Cache;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public class DataAccessFactory : IDataAccessFactory { //TEST: DataAccessFactory

		private readonly string[] vUrls;
		private readonly int vPort;
		private readonly IRexConnCacheProvider vCache;
		private int vUrlIndex;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataAccessFactory(string[] pUrls, int pPort, ICacheManager pCache) {
			vUrls = pUrls;
			vPort = pPort;
			vCache = pCache.RexConn;
			vUrlIndex = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess Create(string pResumeSessionId=null, 
											bool pSetCommandIds=false, bool pOmitCommandTimers=true) {
			string url = vUrls[(vUrlIndex++)%vUrls.Length];
			var dc = new DataContext(url, vPort, vCache, pResumeSessionId, 
				pSetCommandIds, pOmitCommandTimers);

			var da = new DataAccess();
			da.Build(dc);
			return da;
		}

	}

}