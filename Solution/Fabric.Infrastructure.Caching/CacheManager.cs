using Fabric.Infrastructure.Api;

namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public class CacheManager : ICacheManager { //TEST: CacheManager and related classes


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IMemCache Memory {
			get { return MemCache.Instance; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IClassDiskCache UniqueClasses {
			get { return ClassDiskCache.Instance; }
		}

	}

}