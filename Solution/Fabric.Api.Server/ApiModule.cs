using System;
using Fabric.Api.Server.Util;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Nancy;
using Weaver;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class ApiModule : NancyModule {

		private readonly Guid vRequestId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiModule() {
			Log.ConfigureOnce();

			vRequestId = Guid.NewGuid();
			//Log.Info(vRequestId, "REQUEST", "ApiModule Request");

			Get["/setup"] = DoSetup;
			Get["/(.*)"] = GremlinRequest;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GremlinRequest(dynamic pParams) {
			try {
				string query = (string)pParams["1"];
				query = query.Replace('/', '.');
				var gremReq = new GremlinRequest(query);
				return gremReq.ResponseData;
			}
			catch ( Exception ex ) {
				return "error: "+ex.Message;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string DoSetup(dynamic pParams) {
			try {
				if ( Context.Request.Query["pass"] != "asdfasdf" ) {
					//Context.Response.StatusCode = HttpStatusCode.Unauthorized;
					return "Password required.";
				}

				DataSet ds = Setup.SetupAll(false);
				string result = "";
				GremlinRequest req;

				foreach ( WeaverQuery q in ds.Indexes ) {
					req = new GremlinRequest(q);
					result += GetSetupLineItem(req);
				}

				foreach ( IDataNode n in ds.Nodes ) {
					req = new GremlinRequest(n.AddQuery);
					result += GetSetupLineItem(req);
					n.Node.Id = req.Result.GetNodeId();
				}

				foreach ( IDataNodeIndex ni in ds.NodeToIndexes ) {
					req = new GremlinRequest(ni.AddToIndexQuery);
					result += GetSetupLineItem(req);
				}

				foreach ( IDataRel r in ds.Rels ) {
					req = new GremlinRequest(r.AddQuery);
					result += GetSetupLineItem(req);
				}

				return result;
			}
			catch ( Exception ex ) {
				return "error: "+ex.Message;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string GetSetupLineItem(GremlinRequest pReq) {
			return "<b>"+pReq.Script+"</b><br/>"+pReq.ResponseData+"<br/><br/>";
		}

	}

}