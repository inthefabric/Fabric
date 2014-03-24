using RexConnectClient.Core.Cache;

namespace Fabric.Infrastructure.Cache {

	/*================================================================================================*/
	public interface ICacheManager {

		IMemCache Memory { get; }
		IRexConnCacheProvider RexConn { get; }

	}

}