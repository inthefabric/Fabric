using System;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Server.Setups {

	/*================================================================================================*/
	public class SetupRoutine {

		private readonly NancyContext vContext;
		private DataSet vDataSet;
		private ApiContext vApiCtx;


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

				long time = DateTime.UtcNow.Ticks;
				vDataSet = Setup.SetupAll(true);
				vApiCtx = new ApiContext("http://localhost:9001/");

				SendSetupTx();
				SendIndexTx();
				SendNodeTx();
				SendRelTx();

				return "success: "+(DateTime.UtcNow.Ticks-time)/10000.0;
			}
			catch ( Exception ex ) {
				Log.Error("error", ex);
				return "error: "+ex.Message;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SendSetupTx() {
			var tx = new WeaverTransaction();

			foreach ( IWeaverQuery q in vDataSet.Initialization ) {
				tx.AddQuery(q);
			}

			tx.FinishWithoutStartStop();
			vApiCtx.DbData("initTx", tx);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SendIndexTx() {
			var tx = new WeaverTransaction();

			foreach ( IWeaverQuery q in vDataSet.Indexes ) {
				tx.AddQuery(q);
			}

			tx.FinishWithoutStartStop();
			vApiCtx.DbData("addIndexesTx", tx);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SendNodeTx() {
			int count = 0;

			while ( true ) {
				var tx = new WeaverTransaction();
				string listScript = "";
				int start = count;
				int limit = 80;
				Log.Debug("Node "+start+" / "+vDataSet.Nodes.Count);

				for ( int i = start ; i < vDataSet.Nodes.Count ; ++i ) {
					if ( --limit < 0 ) {
						break;
					}

					IDataNode n = vDataSet.Nodes[i];
					IWeaverVarAlias nodeVar;
					count++;

					tx.AddQuery(WeaverTasks.StoreQueryResultAsVar(tx, n.AddQuery, out nodeVar));
					listScript += nodeVar.Name+",";
				}

				var listQ = new WeaverQuery();
				listQ.FinalizeQuery("["+listScript.Substring(0, listScript.Length-1)+"]");
				tx.AddQuery(listQ);

				tx.FinishWithoutStartStop();
				IApiDataAccess nodeData = vApiCtx.DbData("addNodeTx", tx);

				for ( int i = 0 ; i < nodeData.ResultDtoList.Count ; ++i ) {
					IDbDto n = nodeData.ResultDtoList[i];

					if ( n.NodeId == null ) {
						throw new Exception("Node is null at index "+i+".");
					}

					vDataSet.Nodes[start+i].Node.Id = (long)n.NodeId;
				}

				if ( count >= vDataSet.Nodes.Count ) {
					break;
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SendRelTx() {
			int count = 0;

			while ( true ) {
				var tx = new WeaverTransaction();
				int limit = 160;
				Log.Debug("Rel "+count+" / "+vDataSet.Rels.Count);

				for ( int i = count ; i < vDataSet.Rels.Count ; ++i ) {
					if ( --limit < 0 ) {
						break;
					}

					tx.AddQuery(vDataSet.Rels[i].AddQuery);
					count++;
				}

				tx.FinishWithoutStartStop();
				vApiCtx.DbData("addRelsTx", tx);

				if ( count >= vDataSet.Rels.Count ) {
					break;
				}
			}
		}

	}

}