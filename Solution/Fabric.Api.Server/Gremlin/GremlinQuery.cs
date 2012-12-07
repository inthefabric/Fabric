using System;
using System.Text;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api.Server.Gremlin {

	/*================================================================================================*/
	public class GremlinQuery {

		private readonly NancyContext vContext;
		private readonly string vQuery;
		private bool vUseHtml;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GremlinQuery(NancyContext pContext) {
			vContext = pContext;
			vQuery = vContext.Request.Path.Substring(9).Replace('/', '.'); //remove "/gremlin/"
			CheckRequestAccept();
		}

		/*--------------------------------------------------------------------------------------------*/
		public GremlinQuery(NancyContext pContext, string pQuery) {
			vContext = pContext;
			vQuery = pQuery;
			CheckRequestAccept();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void CheckRequestAccept() {
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
				var req = new GremlinRequest(vQuery);
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
			Log.Debug("REQ: "+pReq.Dto+" / "+pReq.DtoList);

			if ( pReq.Dto != null ) {
				html += BuildHtmlResult(pReq.Dto);
			}
			else if ( pReq.DtoList != null ) {
				foreach ( var r in pReq.DtoList ) {
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
		private string BuildHtmlResult(DbDto pResult) {
			var html = "<p><b>"+pResult.Item+" ["+pResult.Class+"]</b><br/>";

			if ( pResult.Id != null ) {
				html += "* Id: "+BuildHtmlLink(pResult.Id, pResult.Item)+"<br/>";
			}

			if ( pResult.FromNodeId != null ) {
				html += "* FromNodeId: "+BuildHtmlLink(pResult.FromNodeId)+"<br/>";
			}

			if ( pResult.ToNodeId != null ) {
				html += "* ToNodeId: "+BuildHtmlLink(pResult.ToNodeId)+"<br/>";
			}

			if ( pResult.Message != null ) { html += "* Message: "+pResult.Message+"<br/>"; }
			if ( pResult.Exception != null ) { html += "* Exception: "+pResult.Exception+"<br/>"; }

			if ( pResult.Data != null ) {
				html += "* Data: ";

				foreach ( string key in pResult.Data.Keys ) {
					html += "<br/>&nbsp&nbsp * "+key+": "+pResult.Data[key];
				}
			}

			if ( pResult.Id != null ) {
				string idUrl = BuildHtmlUrl(pResult.Id, pResult.Item);
				html += (pResult.Data == null ? "" : "<br/>");
				html += "* Actions: [";

				switch ( pResult.Item ) {
					case DbDto.ItemType.Node:
						html += 
							"<a href='"+idUrl+"/outE'>outE</a> | "+
							"<a href='"+idUrl+"/inE'>inE</a> | "+
							"<a href='"+idUrl+"/bothE'>bothE</a> | "+
							"<a href='"+idUrl+"/out'>out</a> | "+
							"<a href='"+idUrl+"/in'>in</a> | "+
							"<a href='"+idUrl+"/both'>both</a>";
						break;

					case DbDto.ItemType.Rel:
						html += 
							"<a href='"+idUrl+"/outV'>outV</a> | "+
							"<a href='"+idUrl+"/inV'>inV</a> | "+
							"<a href='"+idUrl+"/bothV'>bothV</a>";
						break;
				}

				html += "]<br/>";
			}

			html += "</p>";
			return html;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string BuildHtmlLink(long? pId, DbDto.ItemType pType=DbDto.ItemType.Node) {
			return "<a href='"+BuildHtmlUrl(pId, pType)+"'>"+pId+"</a>";
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildHtmlUrl(long? pId, DbDto.ItemType pType=DbDto.ItemType.Node) {
			string type = (pType == DbDto.ItemType.Node ? "v" : "e");
			return "/g/"+type+"("+pId+")";
		}

	}

}