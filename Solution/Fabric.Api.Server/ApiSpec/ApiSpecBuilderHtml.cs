using Fabric.Api.Spec;

namespace Fabric.Api.Server.ApiSpec {

	/*================================================================================================*/
	public class ApiSpecBuilderHtml {

		private readonly SpecDoc vDoc;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiSpecBuilderHtml(SpecDoc pDoc) {
			vDoc = pDoc;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string BuildHtml(SpecDoc pDoc) {
			string html = "<h2>Fabric Api Specification ("+pDoc.ApiVersion+")</h2><br/><br/>";
			html += BuildDtoHtml(pDoc.ApiResponse, pDoc)+"<br/><br/>";
			html += BuildDtoHtml(pDoc.ApiError, pDoc)+"<br/><br/>";

			foreach ( SpecDto dto in pDoc.DtoList ) {
				html += BuildDtoHtml(dto, pDoc)+"<br/><br/>";
			}

			foreach ( SpecFunc func in pDoc.FunctionList ) {
				html += BuildFuncHtml(func, pDoc)+"<br/><br/>";
			}

			return html;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string BuildDtoHtml(SpecDto pDto, SpecDoc pDoc) {
			string html = "<hr><h3><a name='"+pDto.Name+"' />"+pDto.Name+"</h3>";
			
			if ( !string.IsNullOrWhiteSpace(pDto.Extends) ) {
				html +=  "Extends "+BuildAnchorLink(pDto.Extends)+"<br/><br/>";
			}

			html += "<b>Description</b><br/>";
			html += "<span style='color:#777;'>"+pDto.Description+"</span><br/><br/>";

			html += "<b>Properties</b><br/>";
			html += BuildDtoPropHtml(pDto, pDoc, 0);

			html += "<b>Outgoing Links</b><br/>";

			foreach ( SpecLink sl in pDto.LinkList ) {
				if ( !sl.IsOutgoing ) { continue; }
				bool many = (sl.FromDtoConn.IndexOf("OrMore") != -1);

				html += "<div style='margin-left:20px'>";
				html += sl.Name+" : "+
						(many ? "List[" : "")+BuildAnchorLink(sl.ToDto)+(many ? "]" : "")+"<br/>";
				html += "</div>";
			}

			html += "<br/><b>Incoming Links</b><br/>";

			foreach ( SpecLink sl in pDto.LinkList ) {
				if ( sl.IsOutgoing ) { continue; }
				bool many = (sl.ToDtoConn.IndexOf("OrMore") != -1);

				html += "<div style='margin-left:20px'>";
				html += sl.Name+" : "+
					(many ? "List[" : "")+BuildAnchorLink(sl.FromDto)+(many ? "]" : "")+"<br/>";
				html += "</div>";
			}

			html += "<br/><b>Functions</b><br/>";

			foreach ( string funcName in pDto.FunctionList ) {
				html += "<div style='margin-left:20px'>";
				html += BuildAnchorLink(funcName)+"<br/>";
				html += "</div>";
			}
			
			return html;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static string BuildDtoPropHtml(SpecDto pDto, SpecDoc pDoc, int pLevel) {
			string html = "";

			if ( !string.IsNullOrWhiteSpace(pDto.Extends) ) {
				html += BuildDtoPropHtml(pDoc.GetSpecDto(pDto.Extends), pDoc, pLevel+1);
			}

			foreach ( SpecProperty sp in pDto.PropertyList ) {
				html += "<div style='margin-left:20px'>"+sp.Name+" : "+sp.Type+"<br/>"+
					"<span style='color:#777;'>"+
					(pLevel > 0 ? "(from "+BuildAnchorLink(pDto.Name)+") " : "")+
						sp.Description+"</span><br/><br/></div>";
			}

			return html;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string BuildFuncHtml(SpecFunc pFunc, SpecDoc pDoc) {
			string html = "<hr><h3><a name='"+pFunc.Name+"' />Function: "+pFunc.Name+"</h3>";

			html += "<b>Description</b><br/>";
			html += "<span style='color:#777;'>"+pFunc.Description+"</span><br/><br/>";

			html += "<b>Parameters</b><br/>";
			html += BuildFuncParamHtml(pFunc, pDoc);

			return html;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string BuildFuncParamHtml(SpecFunc pFunc, SpecDoc pDoc) {
			string html = "";

			foreach ( SpecFuncParam fp in pFunc.ParameterList ) {
				html += "<div style='margin-left:20px'>"+fp.Name+" : "+fp.Type+" { ";
				html += (fp.Min == null ? "" : "Min="+fp.Min+" ");
				html += (fp.Max == null ? "" : "Max="+fp.Max+" ");
				html += "}<br/><span style='color:#777;'>"+fp.Description+"</span>";
				html += "<br/><br/></div>";
			}

			return html;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string BuildAnchorLink(string pDtoName) {
			return "<a href='#"+pDtoName+"'>"+pDtoName+"</a>";
		}

	}

}