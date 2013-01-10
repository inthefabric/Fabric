using System;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using Weaver.Interfaces;

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

				var ctx = new ApiContext("http://localhost:9001/");
				DataSet ds = Setup.SetupAll(true);

				foreach ( IWeaverQuery q in ds.Indexes ) {
					//new GremlinRequest(q);
				}

				foreach ( IDataNode n in ds.Nodes ) {
					IApiDataAccess ad = ctx.DbData("addNode", n.AddQuery);
					long? id = ad.Result.DbDtos[0].Id;

					if ( id == null ) {
						throw new Exception("Returned ID was null.");
					}

					n.Node.Id = (long)id;
				}

				foreach ( IDataNodeIndex ni in ds.NodeToIndexes ) {
					//new GremlinRequest(ni.AddToIndexQuery);
				}
				
				foreach ( IDataRel r in ds.Rels ) {
					//new GremlinRequest(r.AddQuery);
				}

				return "success";
			}
			catch ( Exception ex ) {
				Log.Error("error", ex);
				return "error: "+ex.Message;
			}
		}

		/*--------------------------------------------------------------------------------------------* /
		public string GetResponse() {
			try {
				if ( vContext.Request.Query["pass"] != "asdfasdf" ) {
					return "Password required.";
				}

				DataSet ds = Setup.SetupAll(true);
				var queries = new List<IWeaverQuery>();
				long nodeI = 1;

				foreach ( WeaverQuery q in ds.Indexes ) {
					queries.Add(q);
				}

				foreach ( IDataNode n in ds.Nodes ) {
					queries.Add(n.AddQuery);
					n.Node.Id = nodeI++;
				}

				foreach ( IDataNodeIndex ni in ds.NodeToIndexes ) {
					queries.Add(ni.AddToIndexQuery);
				}

				foreach ( IDataRel r in ds.Rels ) {
					queries.Add(r.AddQuery);
				}

				////

				string result = "<b>Results:</b><br/><br/>";

				while ( queries.Count > 0 ) {
					var tx = new WeaverTransaction();
					int count = 0;

					for ( int i = 0 ; queries.Count > 0 && count < 100 ; ++i ) {
						tx.AddQuery(queries[0]);
						queries.RemoveAt(0);
						count++;
					}

					tx.Finish(WeaverTransaction.ConclusionType.Success);

					var req = new GremlinRequest(tx.Script, tx.Params);
					result += "<hr/><b>"+req.Query+"</b><br/><br/>"+req.ResponseString+"<br/><br/>";
				}

				return result;
			}
			catch ( Exception ex ) {
				Log.Error("error", ex);
				return "error: "+ex.Message;
			}
		}*/

	}

}