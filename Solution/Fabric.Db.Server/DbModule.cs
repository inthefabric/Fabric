using System;
using System.Collections.Generic;
using System.IO;
using Fabric.Infrastructure;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Db.Server {

	/*================================================================================================*/
	public class DbModule : NancyModule {

		private readonly Guid vRequestId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbModule() {
			Log.ConfigureOnce();

			vRequestId = Guid.NewGuid();
			Log.Info(vRequestId, "REQUEST", "DbModule Request");

			Post["/(.*)"] = SendQuery;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string SendQuery(dynamic pParams) {
			try {
				StreamReader sr = new StreamReader(Context.Request.Body);
				string query = sr.ReadToEnd();

				Log.Info(vRequestId, "QUERY", query);

				var grem = new GremlinQuery(query);
				string result = grem.ExecuteQuery();
				result = FixResult(result);
				Log.Debug(vRequestId, "RESULT", result);
				return result;
			}
			catch ( Exception ex ) {
				Log.Error(vRequestId, "FAIL", ex.Message);
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

}