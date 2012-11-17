using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Fabric.Api.Worker {

	/*================================================================================================*/
	public class Worker {

		public static ManualResetEvent CompleteEvent = new ManualResetEvent(false);

		public const int BufferSize = 1024;
		public const int DefaultTimeout = 120000;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void Main(string[] pArgs) {
			//Console.Write("status=200&error=0&data=#\n{}");
			//return;

			int n = pArgs.Length;

			string method = pArgs[0];
			string path = pArgs[1];
			string query = (n > 2 ? pArgs[2] : null);
			string formData = (n > 3 ? pArgs[3] : null);
			const string gremlin = "{\"script\":\"g.V;\"}";

			var req = (HttpWebRequest)WebRequest.Create("http://localhost:9001/");
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";

			byte[] data = UTF8Encoding.UTF8.GetBytes(gremlin);
			int len = data.Length;
			req.ContentLength = len;

			Stream reqStream = req.GetRequestStream();
			reqStream.Write(data, 0, len);
			reqStream.Close();

			var reqState = new RequestState();
			reqState.Req = req;

			IAsyncResult result = req.BeginGetResponse(RespCallback, reqState);

			ThreadPool.RegisterWaitForSingleObject(
				result.AsyncWaitHandle, TimeoutCallback, req, DefaultTimeout, true);
			CompleteEvent.WaitOne();

			reqState.Resp.Close();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void RespCallback(IAsyncResult pAsyncResult) {
			try {
				RequestState reqState = (RequestState)pAsyncResult.AsyncState;
				HttpWebRequest req = reqState.Req;
				reqState.Resp = (HttpWebResponse)req.EndGetResponse(pAsyncResult);

				Stream stream = reqState.Resp.GetResponseStream();
				reqState.StreamResp = stream;
				stream.BeginRead(reqState.BufferRead, 0, BufferSize, ReadCallback, reqState);
				return;
			}
			catch ( WebException e ) {
				Console.WriteLine("\nRespCallback Exception raised!");
				Console.WriteLine("\n - Message:{0}", e.Message);
				Console.WriteLine("\n - Status:{0}", e.Status);
			}

			CompleteEvent.Set();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void ReadCallback(IAsyncResult pAsyncResult) {
			try {
				RequestState reqState = (RequestState)pAsyncResult.AsyncState;
				Stream stream = reqState.StreamResp;
				int read = stream.EndRead(pAsyncResult);

				if ( read > 0 ) {
					reqState.ReqData.Append(Encoding.ASCII.GetString(reqState.BufferRead, 0, read));
					stream.BeginRead(reqState.BufferRead, 0, BufferSize, ReadCallback, reqState);
					return;
				}

				string data = "";

				if ( reqState.ReqData.Length>1 ) {
					data += reqState.ReqData.ToString();
				}

				Console.Write("status=200&error=0&data=#\n");
				Console.Write(data);
				stream.Close();

			}
			catch ( WebException e ) {
				Console.WriteLine("\nReadCallBack Exception raised!");
				Console.WriteLine("\nMessage:{0}", e.Message);
				Console.WriteLine("\nStatus:{0}", e.Status);
			}

			CompleteEvent.Set();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void TimeoutCallback(object pState, bool pTimedOut) {
			if ( !pTimedOut ) { return; }
			HttpWebRequest request = (pState as HttpWebRequest);
			if ( request == null ) { return; }
			request.Abort();
		}

	}


	/*================================================================================================*/
	public class RequestState {

		public const int BufferSize = 1024;

		public StringBuilder ReqData { get; set; }
		public byte[] BufferRead { get; set; }
		public HttpWebRequest Req { get; set; }
		public HttpWebResponse Resp { get; set; }
		public Stream StreamResp { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RequestState() {
			BufferRead = new byte[BufferSize];
			ReqData = new StringBuilder("");
			Req = null;
			StreamResp = null;
		}

	}

}