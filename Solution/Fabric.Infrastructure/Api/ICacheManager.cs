using RexConnectClient.Core.Cache;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface ICacheManager {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IMemCache Memory { get; }
		IRexConnCacheProvider RexConn { get; }

	}

}