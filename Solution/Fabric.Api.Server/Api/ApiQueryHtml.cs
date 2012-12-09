using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Fabric.Api.Dto;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api.Server.Api {

	/*================================================================================================*/
	public class ApiQueryHtml {

		private readonly GremlinRequest vRequest;
		private readonly Type vDtoType;
		private readonly FabResponse vResp;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiQueryHtml(GremlinRequest pRequest, Type pDtoType, FabResponse pResponse) {
			vRequest = pRequest;
			vDtoType = pDtoType;
			vResp = pResponse;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Response BuildResponse() {
			string dataHtml = BuildTypedHtml();
			vResp.Complete();
			string wrapHtml = BuildWrapHtml(dataHtml);
			byte[] bytes = UTF8Encoding.UTF8.GetBytes(wrapHtml);

			return new Response {
				ContentType = "text/html",
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildTypedHtml() {
			if ( vRequest == null ) { return "{}"; }
			var html = "";

			if ( vRequest.DtoList != null ) {
				var idMap = new HashSet<long>();

				foreach ( DbDto dbDto in vRequest.DtoList ) {
					if ( dbDto.Id != null ) {
						if ( idMap.Contains((long)dbDto.Id) ) {
							++vResp.RemovedDups;
							continue;
						}

						idMap.Add((long)dbDto.Id);
					}

					FabNode n = (FabNode)Activator.CreateInstance(vDtoType);
					n.Fill(dbDto);

					html += (vResp.Count == 0 ? "" : "<br/>");
					html += BuildNodeHtml(n);

					++vResp.Count;
				}

				return html;
			}

			if ( vRequest.Dto != null ) {
				FabNode n = (FabNode)Activator.CreateInstance(vDtoType);
				n.Fill(vRequest.Dto);
				++vResp.Count;
				return BuildNodeHtml(n);
			}

			return "Text: "+vRequest.ResponseString;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildNodeHtml(FabNode pNode) {
			PropertyInfo[] props = pNode.GetType().GetProperties();
			string html = "";

			foreach ( PropertyInfo pi in props ) {
				html += "<b>"+pi.Name+":</b> ";
				var val = pi.GetValue(pNode, null);

				if ( pi.Name == "NodeUri" ) {
					var uri = vResp.BaseUri+vResp.RequestUri+val;
					html += "<a href='"+uri+"'>"+val+"</a>";
				}
				else {
					html += val;
				}

				html += "<br/>";
			}

			return html;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildWrapHtml(string pDataHtml) {
			PropertyInfo[] props = vResp.GetType().GetProperties();
			string html = "";

			html += "<h3>Response</h3>";
			html += "<div style='margin-left:20px;'>";

			foreach ( PropertyInfo pi in props ) {
				if ( pi.Name == "Data" ) { continue; }
				if ( pi.Name == "AvailableUris" ) { continue; }

				html += "<b>"+pi.Name+":</b> ";
				var val = pi.GetValue(vResp, null);

				switch ( pi.Name ) {
					case "BaseUri":
						html += "<a href='"+vResp.BaseUri+"'>"+val+"</a>";
						break;

					case "RequestUri":
						var uri = vResp.BaseUri+vResp.RequestUri;
						html += "<a href='"+uri+"'>"+val+"</a>";
						break;

					default:
						html += val;
						break;
				}

				html += "<br/>";
			}

			html += "</div>";

			////

			html += "<h3>Available URIs</h3>";
			html += "<div style='margin-left:20px;'>";

			for ( int i = 0 ; i < vResp.AvailableUris.Length ; ++i ) {
				string au = vResp.AvailableUris[i];
				var uri = vResp.BaseUri+vResp.RequestUri+au;
				html += (i == 0 ? "" : "<br/>")+"<a href='"+uri+"'>"+au+"</a>";
			}

			html += "</div>";

			////

			html += "<h3>Data</h3>";
			html += "<div style='margin-left:20px;'>"+pDataHtml+"</div>";

			return html;
		}

	}

}