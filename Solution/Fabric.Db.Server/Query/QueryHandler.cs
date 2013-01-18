using System;
using System.IO;
using System.Text;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Db;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Db.Server.Query {

	/*================================================================================================*/
	public class QueryHandler {

		private readonly string vQuery;
		private readonly Guid vReqId;
		private readonly string vGremlinUri;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public QueryHandler(NancyContext pContext, Guid pReqId, string pGremlinUri) {
			vReqId = pReqId;
			vGremlinUri = pGremlinUri;

			StreamReader sr = new StreamReader(pContext.Request.Body);
			vQuery = sr.ReadToEnd();
			Log.Info(pReqId, "QUERY", vQuery);
		}

		/*--------------------------------------------------------------------------------------------*/
		public QueryHandler(string pQuery, Guid pReqId, string pGremlinUri) {
			vQuery = pQuery;
			vReqId = pReqId;
			vGremlinUri = pGremlinUri;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string GetJson() {
			long t = DateTime.UtcNow.Ticks;
			string json;

			try {
				var q = new GremlinQuery(vGremlinUri, vQuery);
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

			Log.Debug("QueryHandler.GetJson(): "+(DateTime.UtcNow.Ticks-t)/10000+"ms");
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