using System.Reflection;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Services.Views {

	/*================================================================================================*/
	public class TraversalHtmlView : IView {

		private readonly TraversalModel vInfo;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalHtmlView(TraversalModel pInfo) {
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
			if ( vInfo.Resp.Error != null ) {
				return BuildVertexHtml(vInfo.Resp.Error);
			}

			if ( vInfo.DtoList == null ) {
				return "<i>No Results</i>";
			}

			var html = "";
			var i = 0;

			foreach ( DbDto dbDto in vInfo.DtoList ) {
				IFabVertex n = ApiDtoUtil.ToDto(dbDto);
				html += (i++ == 0 ? "" : "<br/>");
				html += BuildVertexHtml(n);
			}

			return html;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildVertexHtml(IFabObject pVertex) {
			PropertyInfo[] props = pVertex.GetType().GetProperties();
			string html = "";

			foreach ( PropertyInfo pi in props ) {
				html += "<b>"+pi.Name+":</b> ";
				var val = pi.GetValue(pVertex, null);

				if ( val == null ) {
					html += "<span style='color:gray;'>null</span><br/>";
					continue;
				}

				if ( typeof(FabObject).IsAssignableFrom(pi.PropertyType) ) {
					html += "<div style='margin-left:25px; padding-left:5px; "+
						"border-left:1px solid gray'>"+BuildVertexHtml((IFabObject)val)+"</div>";
					continue;
				}

				if ( pi.Name == "Uri" ) {
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

			string uri = vInfo.Resp.BaseUri+FabHome.TravUri+FabHome.TravRootUri;
			html += "<a href='"+uri+"'>&lt; Reset</a>";

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
						uri = vInfo.Resp.BaseUri+vInfo.Resp.RequestUri;
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
				uri = vInfo.Resp.BaseUri+vInfo.Resp.RequestUri+sl.Uri;
				html += (i == 0 ? "" : "<br/>")+"[ <a href='"+uri+"'>"+
					(sl.IsOut ? "Out" : "In")+" | "+sl.Rel+" | "+sl.Class+"</a> ]";
			}

			html += "</div>";

			////

			html += "<h3>Functions</h3>";
			html += "<div style='margin-left:20px;'>";

			for ( int i = 0 ; i < vInfo.Resp.Functions.Length ; ++i ) {
				string au = vInfo.Resp.Functions[i];
				uri = vInfo.Resp.BaseUri+vInfo.Resp.RequestUri+au;
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