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
			string html = "<h2>Fabric Api Specification ("+pDoc.ApiVersion+")</h2><hr/>";
			html += BuildDtoHtml(pDoc.ApiResponse, pDoc)+"<br/><hr/>";

			foreach ( SpecDto dto in pDoc.DtoList ) {
				html += BuildDtoHtml(dto, pDoc)+"<br/>";
			}

			html += "<hr/>";

			foreach ( SpecFunc func in pDoc.FunctionList ) {
				html += BuildFuncHtml(func, pDoc)+"<br/>";
			}

			return html;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string BuildDtoHtml(SpecDto pDto, SpecDoc pDoc) {
			string html = "<h3><a name='"+pDto.Name+"' />"+pDto.Name+"</h3>";
			
			if ( !string.IsNullOrWhiteSpace(pDto.Extends) ) {
				html +=  "Extends "+BuildDtoLink(pDto.Extends)+"<br/><br/>";
			}

			html += "<b>Description</b><br/>";
			html += "<span style='color:#777;'>"+pDto.Description.Replace("\n", "<br/>")+
				"</span><br/><br/>";

			html += "<b>Properties</b><br/>";
			html += BuildDtoPropHtml(pDto, pDoc, 0);

			html += "<b>Outgoing Links</b><br/>";

			foreach ( SpecDtoLink sl in pDto.LinkList ) {
				if ( !sl.IsOutgoing ) { continue; }
				bool many = (sl.FromDtoConn.IndexOf("OrMore") != -1);

				html += "<div style='margin-left:20px'>";
				html += sl.Name+" : "+
						(many ? "List[" : "")+BuildDtoLink(sl.ToDto)+(many ? "]" : "")+"<br/>";
				html += "</div>";
			}

			html += "<br/><b>Incoming Links</b><br/>";

			foreach ( SpecDtoLink sl in pDto.LinkList ) {
				if ( sl.IsOutgoing ) { continue; }
				bool many = (sl.ToDtoConn.IndexOf("OrMore") != -1);

				html += "<div style='margin-left:20px'>";
				html += sl.Name+" : "+
					(many ? "List[" : "")+BuildDtoLink(sl.FromDto)+(many ? "]" : "")+"<br/>";
				html += "</div>";
			}

			html += "<br/><b>Functions</b><br/>";

			foreach ( string funcName in pDto.FunctionList ) {
				html += "<div style='margin-left:20px'>";
				html += BuildFuncLink(funcName)+"<br/>";
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

			foreach ( SpecDtoProp sp in pDto.PropertyList ) {
				html += "<div style='margin-left:20px'>"+sp.Name+" : "+sp.Type+"<br/>"+
					"<span style='color:#777;'>"+
					(pLevel > 0 ? "(from "+BuildDtoLink(pDto.Name)+") " : "")+
						sp.Description+"</span><br/><br/></div>";
			}

			return html;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string BuildFuncHtml(SpecFunc pFunc, SpecDoc pDoc) {
			string html = "<h3><a name='"+pFunc.Name+"' />Function: "+pFunc.Name+"</h3>";

			html += "<b>Return Type</b><br/>";
			html += (pFunc.ReturnType == null ? "Variable, based on previous step(s)." : 
				BuildDtoLink(pFunc.ReturnType.Name))+"<br/><br/>";

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
				html += "<div style='margin-left:20px'>"+
					(fp.DisplayName ?? fp.Name)+" : "+fp.Type+" { ";
				html += "IsRequired="+fp.IsRequired+", ";
				html += "UsesQueryString="+fp.UsesQueryString+", ";
				html += (fp.Max == null ? "" : "Max="+fp.Max+", ");
				html += (fp.Min == null ? "" : "Min="+fp.Min+", ");
				html += (fp.Max == null ? "" : "Max="+fp.Max+", ");
				html += "}<br/><span style='color:#777;'>"+fp.Description+"</span>";
				html += "<br/><br/></div>";
			}

			return html;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string BuildDtoLink(string pName) {
			return "<a href='/apispec/dtolist/"+pName+"'>"+pName+"</a>";
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string BuildFuncLink(string pName) {
			return "<a href='/apispec/functionlist/"+pName+"'>"+pName+"</a>";
		}

	}

}