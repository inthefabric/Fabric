using System;
using System.Collections.Generic;
using System.IO;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Db.Server {

	/*================================================================================================*/
	public class DbModule : NancyModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbModule() {
			Post["/(.*)"] = SendQuery;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string SendQuery(dynamic pParams) {
			try {
				StreamReader sr = new StreamReader(Context.Request.Body);
				string query = sr.ReadToEnd();

				var grem = new GremlinQuery(query);
				var result = grem.ExecuteQuery();
				result = FixResult(result);
				return result;
			}
			catch ( Exception ex ) {
				return "{\"Error\":\""+ex.Message.Replace('"', '\'')+"\"}";
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public string FixResult(string pResult) {
			string json;
			char first = pResult[0];

			if ( first == '[' && pResult[2] == '{' ) {
				List<DbResult> objList = JsonSerializer.DeserializeFromString<List<DbResult>>(pResult);
				json = JsonSerializer.SerializeToString(objList);
			}
			else if ( first == '{' ) {
				DbResult obj = JsonSerializer.DeserializeFromString<DbResult>(pResult);
				json = JsonSerializer.SerializeToString(obj);
			}
			else {
				json = pResult;
			}

			return json
				.Replace("http://localhost:7474/db/data/", "")
				.Replace("\":\"node/", "\":\"n/")
				.Replace("\":\"relationship/", "\":\"r/");
		}

	}

	/*================================================================================================*/
	public class DbResult {

		public string Self { get; set; }
		public string Start { get; set; }
		public string Type { get; set; }
		public string End { get; set; }
		public Dictionary<string, string> Data { get; set; }

		//TODO: add additional properties as needed

	}

}