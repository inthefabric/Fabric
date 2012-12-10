using System;
using Fabric.Api.Server.Util;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Nancy;
using Weaver;

namespace Fabric.Api.Server.Setups {

	/*================================================================================================*/
	public class SetupRoutine {

		private readonly NancyContext vContext;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupRoutine(NancyContext pContext) {
			vContext = pContext;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetResponse() {
			try {
				if ( vContext.Request.Query["pass"] != "asdfasdf" ) {
					return "Password required.";
				}

				DataSet ds = Setup.SetupAll(true); //false);
				string result = "";
				GremlinRequest req;

				foreach ( WeaverQuery q in ds.Indexes ) {
					req = new GremlinRequest(q);
					result += GetSetupLineItem(req);
				}

				foreach ( IDataNode n in ds.Nodes ) {
					req = new GremlinRequest(n.AddQuery);
					result += GetSetupLineItem(req);
					n.Node.Id = (req.Dto.Id ?? -1);
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
				Log.Error("error", ex);
				return "error: "+ex.Message;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetSetupLineItem(GremlinRequest pReq) {
			return "<b>"+pReq.Query+"</b><br/>"+pReq.ResponseString+"<br/><br/>";
		}

	}

}