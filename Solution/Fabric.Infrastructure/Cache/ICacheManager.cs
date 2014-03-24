using RexConnectClient.Core.Cache;

namespace Fabric.New.Infrastructure.Cache {

	/*================================================================================================*/
	public interface ICacheManager {

		IMemCache Memory { get; }
		IRexConnCacheProvider RexConn { get; }

	}

}