using System.Reflection;
using Fabric.Api.Dto;
using Fabric.Api.Server.Root.Models;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Server.Root.Views {

	/*================================================================================================*/
	public class ApiHtmlView {

		private readonly ApiModel vInfo;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiHtmlView(ApiModel pInfo) {
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
			if ( vInfo.Error != null ) {
				return BuildNodeHtml(vInfo.Error);
			}

			if ( vInfo.DtoList == null ) {
				return "<i>No Results</i>";
			}

			var html = "";
			var i = 0;

			foreach ( DbDto dbDto in vInfo.DtoList ) {
				IFabNode n = ApiDtoUtil.ToDto(dbDto);
				html += (i++ == 0 ? "" : "<br/>");
				html += BuildNodeHtml(n);
			}

			return html;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildNodeHtml(IFabDto pNode) {
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
				if ( pi.Name == "Links" ) { continue; }
				if ( pi.Name == "Functions" ) { continue; }

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

			html += "<h3>Links</h3>";
			html += "<div style='margin-left:20px;'>";

			for ( int i = 0 ; i < vInfo.Resp.Links.Length ; ++i ) {
				FabStepLink sl = vInfo.Resp.Links[i];
				var uri = vInfo.Resp.BaseUri+vInfo.Resp.RequestUri+sl.Uri;
				html += (i == 0 ? "" : "<br/>")+"[ <a href='"+uri+"'>"+
					(sl.IsOut ? "Out" : "In")+" | "+sl.Rel+" | "+sl.Class+"</a> ]";
			}

			html += "</div>";

			////

			html += "<h3>Functions</h3>";
			html += "<div style='margin-left:20px;'>";

			for ( int i = 0 ; i < vInfo.Resp.Functions.Length ; ++i ) {
				string au = vInfo.Resp.Functions[i];
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