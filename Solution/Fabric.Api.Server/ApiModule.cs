using System;
using Fabric.Api.Server.Util;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class ApiModule : NancyModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiModule() {
			Get["/(.*)"] = GremlinRequest;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GremlinRequest(dynamic pParams) {
			try {
				string query = (string)pParams["1"];
				query = query.Replace('/', '.');

				string result = "";

				/*foreach ( var key in pParams ) {
					result += key+": "+pParams[key]+"\n";
				}

				long id = Sharpflake.GetId(Sharpflake.SequenceKey.Factor);
				result += "TestID: "+id+" ... "+Convert.ToString(id, 2)+"\n";
				 result += "----\n";
				 */

				//var gremReq = new GremlinRequestAsync(query);
				var gremReq = new GremlinRequest(query);
				result += gremReq.ResponseData;
				return result;
			}
			catch ( Exception ex ) {
				return "error: "+ex.Message;
			}
		}
	}

}