using System;
using System.IO;
using System.Text;
using Fabric.Infrastructure;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Db.Server.Query {

	/*================================================================================================*/
	public class QueryHandler {

		private readonly string vQuery;
		private readonly Guid vReqId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public QueryHandler(NancyContext pContext, Guid pReqId) {
			vReqId = pReqId;

			StreamReader sr = new StreamReader(pContext.Request.Body);
			vQuery = sr.ReadToEnd();
			Log.Info(pReqId, "QUERY", vQuery);
		}

		/*--------------------------------------------------------------------------------------------*/
		public QueryHandler(string pQuery, Guid pReqId) {
			vReqId = pReqId;
			vQuery = pQuery;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string GetJson() {
			long t = DateTime.UtcNow.Ticks;
			string json;

			try {
				var q = new GremlinQuery(vQuery);
				q.Execute();
				json = JsonSerializer.SerializeToString(q.Result);
			}
			catch ( Exception ex ) {
				var err = new DbDto {
					Item = DbDto.ItemType.Error,
					Exception = ex+""
				};

				json = JsonSerializer.SerializeToString(err);
				Log.Error(vReqId, "FAIL", json, ex);
			}

			Log.Debug("GetJson: "+(DateTime.UtcNow.Ticks-t)/10000.0+"ms");
			return json;
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			byte[] bytes = Encoding.UTF8.GetBytes(GetJson());

			return new Response {
				ContentType = "application/json",
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

	}

}