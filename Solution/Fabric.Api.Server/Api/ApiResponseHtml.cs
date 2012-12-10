using System;
using System.Reflection;
using Fabric.Api.Dto;
using Fabric.Infrastructure;

namespace Fabric.Api.Server.Api {

	/*================================================================================================*/
	public class ApiResponseHtml {

		private readonly ApiQueryInfo vInfo;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiResponseHtml(ApiQueryInfo pInfo) {
			vInfo = pInfo;
		}


		/*--------------------------------------------------------------------------------------------*/
		public string GetContent() {
			string dataHtml = BuildTypedHtml();
			vInfo.Resp.DataLen = dataHtml.Length;
			
			string wrap = BuildWrapHtml(dataHtml);
			vInfo.Resp.Complete(); //last possible moment
			return wrap.Replace("{TotalMs}", vInfo.Resp.TotalMs+"");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string BuildTypedHtml() {
			if ( vInfo.DtoList == null ) {
				return (vInfo.NonDtoText ?? "");
			}

			var html = "";
			var i = 0;

			if ( vInfo.IsSingleDto ) {
				FabNode n = (FabNode)Activator.CreateInstance(vInfo.DtoType);
				n.Fill(vInfo.DtoList[0]);
				return BuildNodeHtml(n);
			}

			foreach ( DbDto dto in vInfo.DtoList ) {
				FabNode n = (FabNode)Activator.CreateInstance(vInfo.DtoType);
				n.Fill(dto);

				html += (i++ == 0 ? "" : "<br/>");
				html += BuildNodeHtml(n);
			}

			return html;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildNodeHtml(FabNode pNode) {
			PropertyInfo[] props = pNode.GetType().GetProperties();
			string html = "";

			foreach ( PropertyInfo pi in props ) {
				html += "<b>"+pi.Name+":</b> ";
				var val = pi.GetValue(pNode, null);

				if ( pi.Name == "NodeUri" ) {
					var uri = vInfo.Resp.BaseUri+vInfo.Resp.RequestUri+val;
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
			PropertyInfo[] props = vInfo.Resp.GetType().GetProperties();
			string html = "";

			html += "<h3>Response</h3>";
			html += "<div style='margin-left:20px;'>";

			foreach ( PropertyInfo pi in props ) {
				if ( pi.Name == "Data" ) { continue; }
				if ( pi.Name == "AvailableUris" ) { continue; }

				html += "<b>"+pi.Name+":</b> ";
				var val = pi.GetValue(vInfo.Resp, null);

				switch ( pi.Name ) {
					case "BaseUri":
						html += "<a href='"+vInfo.Resp.BaseUri+"'>"+val+"</a>";
						break;

					case "RequestUri":
						var uri = vInfo.Resp.BaseUri+vInfo.Resp.RequestUri;
						html += "<a href='"+uri+"'>"+val+"</a>";
						break;

					case "TotalMs":
						html += "{TotalMs}";
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

			for ( int i = 0 ; i < vInfo.Resp.AvailableUris.Length ; ++i ) {
				string au = vInfo.Resp.AvailableUris[i];
				var uri = vInfo.Resp.BaseUri+vInfo.Resp.RequestUri+au;
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