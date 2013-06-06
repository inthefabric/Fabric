using System;
using System.Net.Sockets;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class TimedTcpClient : TcpClient {

		private DateTime vUpdated;
		private readonly int vIdleSecs;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TimedTcpClient(string pHostname, int pPort, int pIdleSeconds) : base(pHostname, pPort) {
			vIdleSecs = pIdleSeconds;
			vUpdated = DateTime.UtcNow;
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool IsAvailable() {
			if ( !Connected ) {
				return false;
			}

			var up = DateTime.UtcNow;

			if ( (up.Ticks-vUpdated.Ticks)/10000000 > vIdleSecs ) {
				Client.Disconnect(false);
				return false;
			}

			vUpdated = up;
			return true;
		}

	}

}