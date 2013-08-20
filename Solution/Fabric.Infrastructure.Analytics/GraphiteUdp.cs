using System;
using System.Net.Sockets;
using System.Text;
using ServiceStack.Text;

namespace Fabric.Infrastructure.Analytics {

	// This class was adapted from:
	//  - https://github.com/ragnard/Graphite.NET
	//  - https://github.com/ragnard/Graphite.NET/blob/master/Graphite/GraphiteUdpClient.cs
	// This was necessary to support sending more than just integer values.

	/*================================================================================================*/
	public class GraphiteUdp : IDisposable {

		private readonly string vPrefix;
		private readonly UdpClient vUdp;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GraphiteUdp(string pHost, int pPort, string pPrefix) {
			vUdp = new UdpClient(pHost, pPort);
			vPrefix = pPrefix;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Send(string pPath, long pValue) {
			Send(pPath, pValue, DateTime.UtcNow);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Send(string pPath, double pValue) {
			Send(pPath, pValue, DateTime.UtcNow);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Send(string pPath, float pValue) {
			Send(pPath, pValue, DateTime.UtcNow);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void Send(string pPath, long pValue, DateTime pTimeStamp) {
			Send(pPath, pValue+"", pTimeStamp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Send(string pPath, double pValue, DateTime pTimeStamp) {
			Send(pPath, pValue+"", pTimeStamp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Send(string pPath, float pValue, DateTime pTimeStamp) {
			Send(pPath, pValue+"", pTimeStamp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Send(string pPath, string pNumericValue, DateTime pTimeStamp) {
			try {
				if ( !string.IsNullOrWhiteSpace(vPrefix) ) {
					pPath = vPrefix+"."+pPath;
				}

				string msg = pPath+" "+pNumericValue+" "+pTimeStamp.ToUnixTime();
				byte[] bytes = Encoding.UTF8.GetBytes(msg);
				vUdp.Send(bytes, bytes.Length);
			}
			catch ( Exception ) { }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Dispose() {
			if ( vUdp != null ) {
				vUdp.Close();
			}

			GC.SuppressFinalize(this);
		}

	}

}