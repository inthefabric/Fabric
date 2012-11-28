using System.IO;
using System.Net;
using System.Text;
using Fabric.Infrastructure;

namespace Fabric.Db.Server {

	/*================================================================================================*/
	public class GremlinQuery {

		public const string GremlinPath = 
			"http://localhost:7474/db/data/ext/GremlinPlugin/graphdb/execute_script";

		private readonly byte[] vQueryData;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GremlinQuery(string pQuery) {
			vQueryData = UTF8Encoding.UTF8.GetBytes(pQuery);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string ExecuteQuery() {
			string result;

			try {
				var wc = new WebClient();
				byte[] resp = wc.UploadData(GremlinPath, "POST", vQueryData);
				result = UTF8Encoding.UTF8.GetString(resp);
			}
			catch ( WebException we ) {
				Log.Debug(we+"");
				Stream s = we.Response.GetResponseStream();

				if ( s != null ) {
					var sr = new StreamReader(s);
					result = sr.ReadToEnd();
					Log.Debug(result);
					return result;
				}

				return "{\"exception\":\""+we.ToString().Replace("\"", "'")+"\"}";
			}

			return result;
		}

	}

}