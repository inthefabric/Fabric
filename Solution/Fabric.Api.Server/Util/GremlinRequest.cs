using System.Collections.Generic;
using System.Net;
using System.Text;
using Fabric.Infrastructure;
using ServiceStack.Text;
using Weaver;

namespace Fabric.Api.Server.Util {

	/*================================================================================================*/
	public class GremlinRequest {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GremlinRequest(string pScript, IDictionary<string, string> pParams=null) {
			Script = pScript;
			Params = pParams;

			string param = "";

			if ( pParams != null ) {
				foreach ( string key in pParams.Keys ) {
					param += (param.Length > 0 ? "," : "");
					param += "\""+FabricUtil.JsonUnquote(key)+"\":\""+
						FabricUtil.JsonUnquote(pParams[key])+"\"";
				}
			}

			string query = "{\"script\":\""+FabricUtil.JsonUnquote(pScript)+"\""+
				(param.Length > 0 ? ",\"params\":{"+param+"}" : "")+"}";

			byte[] queryData = UTF8Encoding.UTF8.GetBytes(query);

			var wc = new WebClient();
			ResponseBytes = wc.UploadData("http://localhost:9001/", "POST", queryData);
			ResponseString = UTF8Encoding.UTF8.GetString(ResponseBytes);

			////
			
			char first = ResponseString[0];

			if ( first == '[' && ResponseString[1] == '{' ) {
				ResultList = JsonSerializer.DeserializeFromString<List<DbResult>>(ResponseString);
			}
			else if ( first == '{' ) {
				Result = JsonSerializer.DeserializeFromString<DbResult>(ResponseString);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public GremlinRequest(WeaverQuery pQuery) : this(pQuery.Script, pQuery.Params) {}

		/*--------------------------------------------------------------------------------------------*/
		public string Script { get; private set; }
		public IDictionary<string,string> Params { get; private set; }
		public byte[] ResponseBytes { get; private set; }
		public string ResponseString { get; private set; }
		public DbResult Result { get; private set; }
		public List<DbResult> ResultList { get; private set; }

	}

}