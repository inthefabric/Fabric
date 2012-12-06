using System.Collections.Generic;
using System.Net;
using System.Text;
using Fabric.Infrastructure;
using ServiceStack.Text;
using Weaver;

namespace Fabric.Api.Server.Util {

	/*================================================================================================*/
	public class GremlinRequest {

		public string Script { get; private set; }
		public IDictionary<string, string> Params { get; private set; }
		public string Query { get; private set; }

		public byte[] ResponseBytes { get; private set; }
		public string ResponseString { get; private set; }
		public DbDto Dto { get; private set; }
		public List<DbDto> DtoList { get; private set; }


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

			Query = "{\"script\":\""+FabricUtil.JsonUnquote(pScript)+"\""+
				(param.Length > 0 ? ",\"params\":{"+param+"}" : "")+"}";

			byte[] queryData = UTF8Encoding.UTF8.GetBytes(Query);

			var wc = new WebClient();
			ResponseBytes = wc.UploadData("http://localhost:9001/", "POST", queryData);
			ResponseString = UTF8Encoding.UTF8.GetString(ResponseBytes);

			////
			
			char first = ResponseString[0];

			if ( first == '[' && ResponseString[1] == '{' ) {
				DtoList = JsonSerializer.DeserializeFromString<List<DbDto>>(ResponseString);
			}
			else if ( first == '{' ) {
				Dto = JsonSerializer.DeserializeFromString<DbDto>(ResponseString);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public GremlinRequest(WeaverQuery pQuery) : this(pQuery.Script, pQuery.Params) {}

	}

}