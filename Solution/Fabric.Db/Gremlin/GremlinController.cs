using System;
using System.IO;
using System.Net;
using System.Text;
using Fabric.Infrastructure;
using Nancy;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace Fabric.Db.Gremlin {

	/*================================================================================================*/
	public class GremlinController {

		private readonly Guid vContextId;
		private readonly string vQuery;
		private readonly string vGremlinUri;
		private readonly string vData;

		private long vTicks;
		private string vResult;
		private Exception vUnhandledException;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GremlinController(Guid pContextId, string pQuery, string pGremlinUri) {
			vContextId = pContextId;
			vQuery = vData = pQuery;
			vGremlinUri = pGremlinUri;
		}

		/*--------------------------------------------------------------------------------------------*/
		public GremlinController(Request pRequest, string pGremlinUri) {
			vGremlinUri = pGremlinUri;

			vData = new StreamReader(pRequest.Body).ReadToEnd();
			int curlyI = vData.IndexOf("{");

			switch ( curlyI ) {
				case 36:
					vContextId = new Guid(vData.Substring(0, curlyI));
					break;

				case 0:
					vContextId = new Guid();
					break;

				default:
					return;
			}

			vQuery = vData.Substring(curlyI);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			byte[] bytes = Encoding.UTF8.GetBytes(GetJson());

			LogAction();

			return new Response {
				ContentType = "application/json",
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetJson() {
			long t = DateTime.UtcNow.Ticks;
			string json;

			try {
				json = ExecuteQuery();
			}
			catch ( Exception ex ) {
				vUnhandledException = ex;

				json = "{\"exception\": \""+FabricUtil.JsonUnquote(ex.GetType().Name)+"\", "+
					"\"message\": \""+FabricUtil.JsonUnquote(ex.Message)+"\"}";
			}

			vTicks = DateTime.UtcNow.Ticks-t;
			json = "{\"serverTime\": "+vTicks/10000+", "+json.Substring(1);
			return json;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string ExecuteQuery() {
			if ( vQuery == null ) {
				throw new Exception("Invalid request data: "+vData);
			}

			string resp;

			try {
				byte[] queryData = Encoding.UTF8.GetBytes(vQuery);
				byte[] respData;

				using ( var wc = new WebClient() ) {
					wc.Headers.Add("Content-Type", "application/json");
					respData = wc.UploadData(vGremlinUri, "POST", queryData);
				}
				
				resp = Encoding.UTF8.GetString(respData);
				vResult = resp;
			}
			catch ( WebException we ) {
				vUnhandledException = we;
				Stream s = (we.Response == null ? null : we.Response.GetResponseStream());

				if ( s == null ) {
					throw;
				}

				var sr = new StreamReader(s);
				resp = sr.ReadToEnd();
				Log.Error(resp);
			}

			return resp;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void LogAction() {
			//DBv1: 
			//	TotalMs, QueryMs, Timestamp, Query

			const string name = "DBv1";
			const string x = " | ";
			const string qt = "\"queryTime\":";

			int qti = vResult.LastIndexOf(qt);
			string queryMs = "";

			if ( qti != -1 ) {
				int si = qti+qt.Length;
				int ei = vResult.IndexOf('}', si);
				int ei2 = vResult.IndexOf(',', si);
				if ( ei2 != -1 && ei2 < ei ) { ei = ei2; }
				queryMs = vResult.Substring(si, ei-si);
			}

			string v1 =
				vTicks/10000 +x+
				queryMs +x+
				DateTime.UtcNow.Ticks +x+
				vQuery;

			if ( vUnhandledException == null ) {
				Log.Info(vContextId, name, v1);
			}
			else {
				Log.Error(vContextId, name, v1, vUnhandledException);
			}
		}

	}

}