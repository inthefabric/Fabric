using Fabric.New.Infrastructure.Broadcast;
using RexConnectClient.Core.Cache;

namespace Fabric.New.Infrastructure.Cache {

	/*================================================================================================*/
	public class CacheManager : ICacheManager { //TEST: CacheManager and related classes

		public IMemCache Memory { get; private set; }
		public IRexConnCacheProvider RexConn { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CacheManager(IMetricsManager pMetrics, bool pForTesting=false) {
			Memory = new MemCache(pMetrics);
			RexConn = new RexConnCacheProvider();

			pMetrics.Gauge("cache.rc.keys", CountRexConnKeys);
		}

		/*--------------------------------------------------------------------------------------------*/
		private long CountRexConnKeys() {
			long n = 0;

			foreach ( string key in RexConn.GetCacheKeys() ) {
				string[] parts = key.Split(':');
				n += RexConn.GetCache(parts[0], int.Parse(parts[1])).GetKeyCount();
			}

			return n;
		}
	}

}