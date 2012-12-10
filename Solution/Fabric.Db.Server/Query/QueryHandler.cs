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
		public Response GetResponse() {
			string json;

			try {
				var q = new GremlinQuery(vQuery);
				q.Execute();

				if ( q.ResultDtoList != null ) {
					json = JsonSerializer.SerializeToString(q.ResultDtoList);
				}
				else {
					json = JsonSerializer.SerializeToString(q.ResultDto);
				}
			}
			catch ( Exception ex ) {
				var err = new DbDto {
					Item = DbDto.ItemType.Error,
					Exception = ex+""
				};

				json = JsonSerializer.SerializeToString(err);
				Log.Error(vReqId, "FAIL", json);
			}

			byte[] bytes = UTF8Encoding.UTF8.GetBytes(json);

			return new Response {
				ContentType = "application/json",
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

	}

}