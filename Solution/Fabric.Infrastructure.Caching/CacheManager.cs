using Fabric.Infrastructure.Api;

namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public class CacheManager : ICacheManager { //TEST: CacheManager and related classes

		public IMemCache Memory { get; private set; }
		public IClassDiskCache UniqueClasses { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CacheManager(bool pForTesting=false) {
			Memory = new MemCache();
			UniqueClasses = new ClassDiskCache(pForTesting);
		}

	}

}