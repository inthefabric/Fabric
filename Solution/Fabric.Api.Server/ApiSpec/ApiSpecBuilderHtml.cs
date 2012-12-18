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

			foreach ( SpecDto dto in pDoc.DtoList ) {
				html += BuildDtoHtml(dto, pDoc)+"<br/><br/>";
			}

			return html;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string BuildDtoHtml(SpecDto pDto, SpecDoc pDoc) {
			string html = "<hr><h3><a name='"+pDto.Name+"' />"+pDto.Name+"</h3>";
			
			if ( !string.IsNullOrWhiteSpace(pDto.Extends) ) {
				html +=  "Extends "+BuildDtoLink(pDto.Extends)+"<br/><br/>";
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
						(many ? "List[" : "")+BuildDtoLink(sl.ToDto)+(many ? "]" : "")+"<br/>";
				html += "</div>";
			}

			html += "<br/><b>Incoming Links</b><br/>";

			foreach ( SpecLink sl in pDto.LinkList ) {
				if ( sl.IsOutgoing ) { continue; }
				bool many = (sl.ToDtoConn.IndexOf("OrMore") != -1);

				html += "<div style='margin-left:20px'>";
				html += sl.Name+" : "+
					(many ? "List[" : "")+BuildDtoLink(sl.FromDto)+(many ? "]" : "")+"<br/>";
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
					(pLevel > 0 ? "(from "+BuildDtoLink(pDto.Name)+") " : "")+
						sp.Description+"</span><br/><br/></div>";
			}

			return html;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string BuildDtoLink(string pDtoName) {
			return "<a href='#"+pDtoName+"'>"+pDtoName+"</a>";
		}

	}

}