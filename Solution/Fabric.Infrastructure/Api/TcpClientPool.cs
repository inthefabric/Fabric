using System;
using System.Collections.Generic;
using System.Threading;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class TcpClientPool {

		public static int IdleSeconds = 30;
		public static int MaxPoolSize = 10;

		private readonly static Dictionary<string, TcpClientPool> TcpPoolMap = 
			new Dictionary<string, TcpClientPool>();

		private readonly string vHost;
		private readonly int vPort;
		private readonly int vIdleSec;
		private readonly int vMaxSize;
		private readonly Semaphore vSema;
		private readonly Queue<TimedTcpClient> vClients;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static TcpClientPool GetPool(string pHostname, int pPort) {
			string key = pHostname+":"+pPort;

			lock ( TcpPoolMap ) {
				if ( !TcpPoolMap.ContainsKey(key) ) {
					TcpPoolMap.Add(key, new TcpClientPool(pHostname, pPort, IdleSeconds, MaxPoolSize));
				}
			}

			return TcpPoolMap[key];
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TcpClientPool(string pHost, int pPort, int pIdleSeconds, int pMaxSize) {
			vHost = pHost;
			vPort = pPort;
			vIdleSec = pIdleSeconds;
			vMaxSize = pMaxSize;

			vSema = new Semaphore(Math.Min(2, vMaxSize), vMaxSize, "TcpClientPool");
			vClients = new Queue<TimedTcpClient>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public TimedTcpClient TakeClient() {
			vSema.WaitOne();
			TimedTcpClient tc = null;

			lock ( vClients ) {
				while ( vClients.Count > 0 ) {
					tc = vClients.Dequeue();

					if ( tc.IsAvailable() ) {
						break;
					}

					tc.Close();
					tc = null;
					Log.Debug("Closed TCP Client. Pool count: "+vClients.Count);
				}
			}

			if ( tc == null ) {
				tc = new TimedTcpClient(vHost, vPort, vIdleSec);
				Log.Debug("Created TCP Client");
			}

			vSema.Release();
			return tc;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ReturnClient(TimedTcpClient pClient) {
			if ( pClient == null ) {
				return;
			}

			lock ( vClients ) {
				if ( pClient.Connected ) {
					vClients.Enqueue(pClient);
					return;
				}
			}

			pClient.Close();
		}

	}

}