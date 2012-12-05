using System;
using System.IO;
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
		public string GetResponse() {
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

				Log.Debug(vReqId, "RESULT", json);
			}
			catch ( Exception ex ) {
				var err = new DbDto {
					Item = DbDto.ItemType.Error,
					Exception = ex+""
				};

				json = JsonSerializer.SerializeToString(err);
				Log.Error(vReqId, "FAIL", json);
			}

			return json;
		}

	}

}