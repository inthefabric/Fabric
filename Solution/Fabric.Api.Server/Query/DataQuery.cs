using System;
using System.Text;
using Fabric.Api.Server.Util;
using Nancy;

namespace Fabric.Api.Server.Query {

	/*================================================================================================*/
	public class DataQuery {

		private readonly NancyContext vContext;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataQuery(NancyContext pContext) {
			vContext = pContext;
		}

		/*--------------------------------------------------------------------------------------------*/
		public dynamic GetResponse() {
			try {
				string q = vContext.Request.Path.Substring(1).Replace('/', '.');
				var req = new GremlinRequest(q);
				var data = Encoding.UTF8.GetBytes(req.ResponseData);

				return new Response {
					ContentType = "application/json",
					StatusCode = HttpStatusCode.OK,
					Contents = (s => s.Write(data, 0, data.Length))
				};
			}
			catch ( Exception ex ) {
				return "error: "+ex.Message;
			}
		}

	}

}