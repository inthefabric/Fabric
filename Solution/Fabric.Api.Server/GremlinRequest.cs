using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class GremlinRequest {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GremlinRequest(string pScript, IDictionary<string, string> pParams=null) {
			string param = "";

			if ( pParams != null ) {
				foreach ( string key in pParams.Keys ) {
					param += (param.Length > 0 ? "," : "");
					param += "\""+key+"\":\""+pParams[key]+"\"";
				}
			}

			string query = "{\"script\":"+"\""+pScript.Replace("\"","'")+"\","+
				"\"params\":{"+param.Replace("\"","'")+"}}";
			byte[] queryData = UTF8Encoding.UTF8.GetBytes(query);

			var wc = new WebClient();
			byte[] resp = wc.UploadData("http://localhost:9001/", "POST", queryData);
			ResponseData = UTF8Encoding.UTF8.GetString(resp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string ResponseData { get; private set; }

	}

}