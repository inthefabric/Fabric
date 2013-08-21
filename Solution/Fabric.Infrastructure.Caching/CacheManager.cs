using Fabric.Infrastructure.Api;

namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public class CacheManager : ICacheManager { //TEST: CacheManager and related classes

		public IMemCache Memory { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CacheManager(IMetricsManager pMetrics, bool pForTesting=false) {
			Memory = new MemCache(pMetrics);
		}

	}

}