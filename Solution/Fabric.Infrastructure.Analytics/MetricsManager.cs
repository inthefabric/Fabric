using Graphite;

namespace Fabric.Infrastructure.Analytics {
	
	/*================================================================================================*/
	public class MetricsManager {

		private readonly GraphiteUdpClient vGraphite;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MetricsManager(string pHost, int pPort, string pPrefix) {
			vGraphite = new GraphiteUdpClient(pHost, pPort, pPrefix);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Record(string pPath, int pValue) {
			vGraphite.Send(pPath, pValue);
		}

	}

}