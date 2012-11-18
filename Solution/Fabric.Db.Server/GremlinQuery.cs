using System.Net;
using System.Text;

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
			var wc = new WebClient();
			byte[] resp = wc.UploadData(GremlinPath, "POST", vQueryData);
			return UTF8Encoding.UTF8.GetString(resp);
		}

	}

}