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
	public class GraphiteTcp : IDisposable {

		private readonly string vPrefix;
		private readonly TcpClient vTcp;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GraphiteTcp(string pHost, int pPort, string pPrefix) {
			vTcp = new TcpClient(pHost, pPort);
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

				string msg = pPath+" "+pNumericValue+" "+pTimeStamp.ToUnixTime()+"\n";
				byte[] bytes = Encoding.UTF8.GetBytes(msg);
				vTcp.GetStream().Write(bytes, 0, bytes.Length);
			}
			catch ( Exception e ) {
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