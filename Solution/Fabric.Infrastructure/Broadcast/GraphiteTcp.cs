using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using GoogleAnalyticsTracker;

namespace Fabric.Infrastructure.Broadcast {

	// This class was adapted from:
	//  - https://github.com/ragnard/Graphite.NET
	//  - https://github.com/ragnard/Graphite.NET/blob/master/Graphite/GraphiteUdpClient.cs
	// This was necessary to support sending more than just integer values.

	/*================================================================================================*/
	public class GraphiteTcp : IDisposable { //TEST: GraphiteTcp

		private static readonly Logger Log = Logger.Build<GraphiteTcp>();

		private readonly string vPrefix;
		private readonly string vHost;
		private readonly int vPort;
		private TcpClient vTcp;
		private string vMsg;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GraphiteTcp(string pHost, int pPort, string pPrefix) {
			vHost = pHost;
			vPort = pPort;
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
			if ( !string.IsNullOrWhiteSpace(vPrefix) ) {
				pPath = vPrefix+"."+pPath;
			}

			vMsg = pPath+" "+pNumericValue+" "+pTimeStamp.ToUnixTime()+"\n";
			ThreadPool.QueueUserWorkItem(SendAndForget);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SendAndForget(object pState) {
			try {
				if ( vTcp == null ) {
					vTcp = new TcpClient(vHost, vPort);
				}
				
				byte[] bytes = Encoding.UTF8.GetBytes(vMsg);
				vTcp.GetStream().Write(bytes, 0, bytes.Length);
			}
			catch ( Exception e ) {
				if ( vTcp != null && vTcp.Connected ) {
					vTcp.Close();
				}
				
				vTcp = null;
				Log.Error("GraphiteUdp Exception: "+e.Message, e);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Dispose() {
			if ( vTcp != null ) {
				vTcp.Close();
			}

			GC.SuppressFinalize(this);
		}

	}

}