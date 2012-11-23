using Weaver;

namespace Fabric.Infrastructure {

	/*================================================================================================*/
	public static class FabricUtil {
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string WeaverQueryToJson(WeaverQuery pQuery) {
			string json = "{\"script\":\""+pQuery.Script+"\",\"params\":{";

			foreach ( string key in pQuery.Params.Keys ) {
				json += "\""+key+"\":\""+pQuery.Params[key]+"\"";
			}

			return json+"}}";
		}

	}

}