using System;
using System.IO;
using System.Net;
using System.Text;
using Fabric.Infrastructure;
using Nancy;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace Fabric.Db.Server.Gremlin {

	/*================================================================================================*/
	public class GremlinDbQuery {

		private readonly string vQuery;
		private readonly string vGremlinUri;
		private readonly Guid vReqId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GremlinDbQuery(string pQuery, string pGremlinUri) {
			vQuery = pQuery;
			vGremlinUri = pGremlinUri;
			vReqId = Guid.NewGuid();
		}

		/*--------------------------------------------------------------------------------------------*/
		public GremlinDbQuery(NancyContext pContext, string pGremlinUri) :
																this(ReadQuery(pContext), pGremlinUri) {
			Log.Info(vReqId, "QUERY", vQuery);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string ReadQuery(NancyContext pContext) {
			return new StreamReader(pContext.Request.Body).ReadToEnd();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			byte[] bytes = Encoding.UTF8.GetBytes(GetJson());

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
				json = "{\"exception\": \""+FabricUtil.JsonUnquote(ex.GetType().Name)+"\", "+
					"\"message\": \""+FabricUtil.JsonUnquote(ex.Message)+"\"}";
				Log.Error(vReqId, "FAIL", json, ex);
			}

			t = DateTime.UtcNow.Ticks-t;
			json = "{\"serverTicks\": "+t+", "+json.Substring(1);
			//Log.Debug("GremlinDbQuery ("+t/10000+"ms): "+json);
			return json;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string ExecuteQuery() {
			string resp = "";
			long t = DateTime.UtcNow.Ticks;

			try {
				byte[] queryData = Encoding.UTF8.GetBytes(vQuery);
				byte[] respData;

				using ( var wc = new WebClient() ) {
					wc.Headers.Add("Content-Type", "application/json");
					respData = wc.UploadData(vGremlinUri, "POST", queryData);
				}
				
				resp = Encoding.UTF8.GetString(respData);
			}
			catch ( WebException we ) {
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

	}

}