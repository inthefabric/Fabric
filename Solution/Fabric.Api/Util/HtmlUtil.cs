namespace Fabric.Api.Util {

	/*================================================================================================*/
	public static class HtmlUtil {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string Wrap(string pTag, string pContent) {
			return "<"+pTag+">"+pContent+"</"+pTag+">";
		}
		
		/*--------------------------------------------------------------------------------------------* /
		private string BuildHtmlLink(long? pId, DbDto.ItemType pType=DbDto.ItemType.Vertex) {
			return "<a href='"+BuildHtmlUrl(pId, pType)+"'>"+pId+"</a>";
		}

		/*--------------------------------------------------------------------------------------------* /
		private string BuildHtmlUrl(long? pId, DbDto.ItemType pType=DbDto.ItemType.Vertex) {
			string type = (pType == DbDto.ItemType.Vertex ? "v" : "e");
			return "/g/"+type+"("+pId+")";
		}*/

	}

}