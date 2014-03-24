using RexConnectClient.Core.Cache;

namespace Fabric.New.Infrastructure.Data {

	/*================================================================================================*/
	public interface IDataContext {

		string RexConnUrl { get; }
		int RexConnPort { get; }
		IRexConnCacheProvider RexConnCacheProv { get; }
		string ResumeSessionId { get; }
		bool SetCommandIds { get; }
		bool OmitCommandTimers { get; }

	}

}