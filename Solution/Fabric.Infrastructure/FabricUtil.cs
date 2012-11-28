using Weaver;

namespace Fabric.Infrastructure {

	/*================================================================================================*/
	public static class FabricUtil {
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string WeaverQueryToJson(WeaverQuery pQuery) {
			string json = "{\"script\":\""+JsonUnquote(pQuery.Script)+"\",\"params\":{";
			bool first = true;

			foreach ( string key in pQuery.Params.Keys ) {
				json += (first ? "" : ",")+"\""+JsonUnquote(key)+"\":\""+
					JsonUnquote(pQuery.Params[key])+"\"";
				first = false;
			}

			return json+"}}";
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string JsonUnquote(string pText) {
			return pText.Replace("\"", "\\\"");
		}

	}

}