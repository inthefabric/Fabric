using System;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class ApiModule : NancyModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiModule() {
			Get["/(.*)"] =  GremlinRequest;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GremlinRequest(dynamic pParams) {
			try {
				string query = (string)pParams["1"];
				query = query.Replace('/', '.');
				string result = "";

				foreach ( var key in pParams ) {
					result += key+": "+pParams[key]+"\n";
				}

				//var gremReq = new GremlinRequestAsync(query);
				var gremReq = new GremlinRequest(query);
				result += "----\n"+gremReq.ResponseData;
				return result;
			}
			catch ( Exception ex ) {
				return "error: "+ex.Message;
			}
		}
	}

}