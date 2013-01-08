using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Fabric.Api.Server.Util {

	/*================================================================================================*/
	public class GremlinRequestAsync {

		private readonly ReqState vState;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GremlinRequestAsync(string pScript, IDictionary<string, string> pParams=null) {
			string param = "";

			if ( pParams != null ) {
				foreach ( string key in pParams.Keys ) {
					param += (param.Length > 0 ? "," : "");
					param += "\""+key+"\":\""+pParams[key]+"\"";
				}
			}

			string query = "{\"script\":"+"\""+pScript.Replace("\"", "'")+"\","+
				"\"params\":{"+param.Replace("\"", "'")+"}}";

			byte[] queryData = Encoding.UTF8.GetBytes(query);
			int queryDataLen = queryData.Length;

			////
			
			var req = (HttpWebRequest)WebRequest.Create("http://localhost:9001/");
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";
			req.ContentLength = queryDataLen;
			req.KeepAlive = true;

			Stream s = req.GetRequestStream();
			s.Write(queryData, 0, queryDataLen);
			s.Close();

			vState = new ReqState(req);
			req.BeginGetResponse(OnResponse, vState);

			////

			long now = DateTime.Now.Ticks;

			while ( !vState.IsComplete && vState.ErrorMsg == null ) {
				Thread.Sleep(50);
				if ( DateTime.Now.Ticks-now <= 5*10000000 ) { continue; } //5 seconds
				req.Abort();
				throw new Exception("Database request timed out.");
			}

			if ( vState.ErrorMsg != null ) {
				throw new Exception("ERROR: "+vState.ErrorMsg);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool IsComplete { get { return vState.IsComplete; } }
		public string ResponseData { get { return vState.ResponseData; } }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void OnResponse(IAsyncResult pAsyncResult) {
			ReqState state = (ReqState)pAsyncResult.AsyncState;

			try {
				HttpWebRequest req = state.Req;
				state.Resp = (HttpWebResponse)req.EndGetResponse(pAsyncResult);

				Stream stream = state.Resp.GetResponseStream();
				state.StreamResp = stream;
				stream.BeginRead(state.BufferRead, 0, ReqState.BufferSize, OnReadComplete, state);
			}
			catch ( Exception e ) {
				state.ErrorMsg = "OnResponse Exception: "+e;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void OnReadComplete(IAsyncResult pAsyncResult) {
			ReqState state = (ReqState)pAsyncResult.AsyncState;

			try {
				Stream s = state.StreamResp;
				int read = s.EndRead(pAsyncResult);
				Console.Write("ReadComp="+read+"&");

				if ( read > 0 ) {
					state.ReqData.Append(Encoding.ASCII.GetString(state.BufferRead, 0, read));
					s.BeginRead(state.BufferRead, 0, ReqState.BufferSize, OnReadComplete, state);
					return;
				}

				Console.Write("Len="+state.ReqData.Length+"&");

				if ( state.ReqData.Length > 1 ) {
					state.ResponseData = state.ReqData.ToString();
				}

				Console.Write("Data="+state.ResponseData+"&");

				s.Close();
				state.IsComplete = true;
			}
			catch ( Exception e ) {
				state.ErrorMsg = "OnReadComplete Exception: "+e;
			}
		}
	}


	/*================================================================================================*/
	public class ReqState {

		public const int BufferSize = 1024;

		public HttpWebRequest Req { get; private set; }

		public StringBuilder ReqData { get; set; }
		public byte[] BufferRead { get; set; }
		public HttpWebResponse Resp { get; set; }
		public Stream StreamResp { get; set; }
		public String ResponseData { get; set; }
		public bool IsComplete { get; set; }
		public GremlinRequestAsync GremReq { get; set; }
		public string ErrorMsg { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ReqState(HttpWebRequest pReq) {
			Req = pReq;

			BufferRead = new byte[BufferSize];
			ReqData = new StringBuilder("");
			StreamResp = null;
		}

	}

}