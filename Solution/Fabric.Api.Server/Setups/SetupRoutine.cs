using System;
using System.Collections.Generic;
using Fabric.Api.Server.Util;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Nancy;
using Weaver;
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

				DataSet ds = Setup.SetupAll(true);
				var queries = new List<IWeaverQuery>();
				long nodeI = 0;

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
		}

	}

}