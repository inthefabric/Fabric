using System;
using System.Text;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api.Server.Query {

	/*================================================================================================*/
	public class DataQuery {

		private readonly NancyContext vContext;
		private readonly bool vUseHtml;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataQuery(NancyContext pContext) {
			vContext = pContext;

			foreach ( var a in vContext.Request.Headers.Accept ) {
				if ( a.Item1 != "text/html" ) { continue; }
				//if ( a.Item1 != "application/xml" ) { continue; }
				vUseHtml = true;
				break;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			try {
				string q = vContext.Request.Path.Substring(1).Replace('/', '.');
				var req = new GremlinRequest(q);
				Log.Debug("RESP: "+req.ResponseString);

				return (vUseHtml ? BuildHtml(req) : BuildJson(req));
			}
			catch ( Exception ex ) {
				return "error: "+ex.Message;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildJson(GremlinRequest pReq) {
			return new Response {
				ContentType = "application/json",
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(pReq.ResponseBytes, 0, pReq.ResponseBytes.Length))
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response BuildHtml(GremlinRequest pReq) {
			var html = "";
			Log.Debug("REQ: "+pReq.Result+" / "+pReq.ResultList);

			if ( pReq.Result != null ) {
				html += BuildHtmlResult(pReq.Result);
			}
			else if ( pReq.ResultList != null ) {
				foreach ( var r in pReq.ResultList ) {
					html += BuildHtmlResult(r);
				}
			}
			else {
				html += "<p>"+pReq.ResponseString+"</p>";
			}

			var data = Encoding.UTF8.GetBytes(html);

			return new Response {
				ContentType = "text/html",
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(data, 0, data.Length))
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildHtmlResult(DbResult pResult) {
			var html = "<p><b>"+pResult.Self+"</b></p>";
			return html;
		}

	}

}