using System;
using System.Collections.Generic;
using Fabric.Api.Common;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using Nancy;
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
				if ( NancyReq.Query["pass"] != "build-0.1.30" ) {
					return "Password required.";
				}

				long time = DateTime.UtcNow.Ticks;
#if DEBUG
				vDataSet = Setup.SetupAll(true);
#else
				vDataSet = Setup.SetupAll(false);
#endif
				//SendSetupTx();
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
			var tx = Weave.Inst.NewTx();

			foreach ( IWeaverQuery q in vDataSet.Initialization ) {
				tx.AddQuery(q);
			}

			tx.Finish();
			ApiCtx.DbData("initTx", tx);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SendIndexTx() {
			Log.Debug("Create Indexes...");

			var req = new RexConnTcpRequest();
			req.ReqId = ApiCtx.ContextId.ToString();
			req.CmdList = new List<RexConnTcpRequestCommand>();
			ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Start);
			IApiDataAccess data = ApiCtx.DbData("StartIndexes", req);

			req.SessId = data.Response.SessId;

			foreach ( IWeaverQuery q in vDataSet.Indexes ) {
				req.CmdList = new List<RexConnTcpRequestCommand>();
				req.CmdList.Add(ApiDataAccess.BuildRequestCommand(q.Script, q.Params));
				ApiCtx.DbData("AddIndex", req);
			}
			
			req.CmdList = new List<RexConnTcpRequestCommand>();
			ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Commit);
			ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Close);
			ApiCtx.DbData("CommitIndexes", req);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SendNodeTx() {
			int count = 0;

			while ( true ) {
				var tx = Weave.Inst.NewTx();
				string listScript = "";
				int start = count;
				int limit = 1;
				Log.Debug("Node "+start+" / "+vDataSet.Nodes.Count);

				for ( int i = start ; i < vDataSet.Nodes.Count ; ++i ) {
					if ( --limit < 0 ) {
						break;
					}

					IDataNode n = vDataSet.Nodes[i];
					IWeaverVarAlias nodeVar;
					count++;

					tx.AddQuery(Weave.Inst.StoreQueryResultAsVar(tx, n.AddQuery, out nodeVar));
					listScript += nodeVar.Name+".id,";
				}

				var listQ = Weave.Inst.NewQuery();
				listQ.FinalizeQuery("["+listScript.Substring(0, listScript.Length-1)+"]");
				tx.AddQuery(listQ);

				tx.Finish();
				IApiDataAccess nodeData = ApiCtx.DbData("addNodeTx", tx);

				for ( int i = 0 ; i < nodeData.Result.TextList.Count ; ++i ) {
					string idStr = nodeData.Result.TextList[i];

					if ( idStr == null ) {
						throw new Exception("Node is null at index "+i+".");
					}

					vDataSet.Nodes[start+i].Node.Id = idStr;
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
				var tx = Weave.Inst.NewTx();
				int limit = 10;
				Log.Debug("Rel "+count+" / "+vDataSet.Rels.Count);

				for ( int i = count ; i < vDataSet.Rels.Count ; ++i ) {
					if ( --limit < 0 ) {
						break;
					}

					tx.AddQuery(vDataSet.Rels[i].AddQuery);
					count++;
				}

				tx.Finish();
				ApiCtx.DbData("addRelsTx", tx);

				if ( count >= vDataSet.Rels.Count ) {
					break;
				}
			}
		}

	}

}