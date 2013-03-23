﻿using System;
using Fabric.Api.Common;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Internal.Setups {

	/*================================================================================================*/
	public class SetupController : Controller {

		private DataSet vDataSet;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupController(Request pRequest, IApiContext pApiCtx) : base(pRequest, pApiCtx) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildResponse() {
			try {
				if ( NancyReq.Query["pass"] != "asdfasdf" ) {
					return "Password required.";
				}

				long time = DateTime.UtcNow.Ticks;
				vDataSet = Setup.SetupAll(true);

				SendSetupTx();
				SendIndexTx();
				SendNodeTx();
				SendRelTx();

				return "success: "+(DateTime.UtcNow.Ticks-time)/10000000.0;
			}
			catch ( Exception ex ) {
				Log.Error("error", ex);
				return "error: "+ex.Message;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SendSetupTx() {
			Log.Debug("Remove all nodes");
			var tx = new WeaverTransaction();

			foreach ( IWeaverQuery q in vDataSet.Initialization ) {
				tx.AddQuery(q);
			}

			tx.FinishWithoutStartStop();
			ApiCtx.DbData("initTx", tx);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SendIndexTx() {
			Log.Debug("Create Indexes");
			var tx = new WeaverTransaction();

			foreach ( IWeaverQuery q in vDataSet.Indexes ) {
				tx.AddQuery(q);
			}

			tx.FinishWithoutStartStop();
			ApiCtx.DbData("addIndexesTx", tx);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SendNodeTx() {
			int count = 0;

			while ( true ) {
				var tx = new WeaverTransaction();
				string listScript = "";
				int start = count;
				int limit = 50;
				Log.Debug("Node "+start+" / "+vDataSet.Nodes.Count);

				for ( int i = start ; i < vDataSet.Nodes.Count ; ++i ) {
					if ( --limit < 0 ) {
						break;
					}

					IDataNode n = vDataSet.Nodes[i];
					IWeaverVarAlias nodeVar;
					count++;

					tx.AddQuery(WeaverTasks.StoreQueryResultAsVar(tx, n.AddQuery, out nodeVar));
					listScript += nodeVar.Name+".id,";
				}

				var listQ = new WeaverQuery();
				listQ.FinalizeQuery("["+listScript.Substring(0, listScript.Length-1)+"]");
				tx.AddQuery(listQ);

				tx.FinishWithoutStartStop();
				IApiDataAccess nodeData = ApiCtx.DbData("addNodeTx", tx);

				for ( int i = 0 ; i < nodeData.Result.TextList.Count ; ++i ) {
					string idStr = nodeData.Result.TextList[i];

					if ( idStr == null ) {
						throw new Exception("Node is null at index "+i+".");
					}

					vDataSet.Nodes[start+i].Node.Id = long.Parse(idStr);
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
				int limit = 100;
				Log.Debug("Rel "+count+" / "+vDataSet.Rels.Count);

				for ( int i = count ; i < vDataSet.Rels.Count ; ++i ) {
					if ( --limit < 0 ) {
						break;
					}

					tx.AddQuery(vDataSet.Rels[i].AddQuery);
					count++;
				}

				tx.FinishWithoutStartStop();
				ApiCtx.DbData("addRelsTx", tx);

				if ( count >= vDataSet.Rels.Count ) {
					break;
				}
			}
		}

	}

}