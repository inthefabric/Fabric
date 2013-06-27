using System;
using System.Diagnostics;
using Fabric.Api.Common;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;
using Weaver.Core.Query;
using Weaver.Exec.RexConnect;
using Request = Nancy.Request;
using Response = Nancy.Response;

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

				var sw = new Stopwatch();
				sw.Start();

#if DEBUG
				vDataSet = Setup.SetupAll(true);
#else
				vDataSet = Setup.SetupAll(false);
#endif
				//SendSetupTx();
				SendIndexTx();
				SendVertexTx();
				SendEdgeTx();

				return "success: "+sw.ElapsedMilliseconds/1000.0+"sec";
			}
			catch ( Exception ex ) {
				Log.Error("error", ex);
				return "error: "+ex.Message;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SendSetupTx() {
			Log.Debug("Remove all verts");
			var tx = new WeaverTransaction();

			foreach ( IWeaverQuery q in vDataSet.Initialization ) {
				tx.AddQuery(q);
			}

			tx.Finish();
			ApiCtx.DbData("initTx", tx);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SendIndexTx() {
			Log.Debug("Create Indexes...");
			string reqId = ApiCtx.ContextId.ToString();

			var req = new WeaverRequest(reqId);
			req.AddSessionAction(RexConn.SessionAction.Start);
			var da = new ApiDataAccess(ApiCtx, req);
			da.Execute();

			string sessId = da.Result.Response.SessId;

			foreach ( IWeaverQuery q in vDataSet.Indexes ) {
				req = new WeaverRequest(reqId, sessId);
				req.AddQuery(q);
				da = new ApiDataAccess(ApiCtx, req);
				da.Execute();
			}

			req = new WeaverRequest(reqId, sessId);
			req.AddSessionAction(RexConn.SessionAction.Commit);
			req.AddSessionAction(RexConn.SessionAction.Close);
			da = new ApiDataAccess(ApiCtx, req);
			da.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SendVertexTx() {
			int count = 0;

			while ( true ) {
				var tx = new WeaverTransaction();
				string listScript = "";
				int start = count;
				int limit = 1;
				Log.Debug("Vertex "+start+" / "+vDataSet.Vertices.Count);

				for ( int i = start ; i < vDataSet.Vertices.Count ; ++i ) {
					if ( --limit < 0 ) {
						break;
					}

					IDataVertex n = vDataSet.Vertices[i];
					IWeaverVarAlias vertexVar;
					count++;

					tx.AddQuery(WeaverQuery.StoreResultAsVar("vertex", n.AddQuery, out vertexVar));
					listScript += vertexVar.Name+".id,";
				}

				var listQ = new WeaverQuery();
				listQ.FinalizeQuery("["+listScript.Substring(0, listScript.Length-1)+"]");
				tx.AddQuery(listQ);

				tx.Finish();
				IApiDataAccess vertexData = ApiCtx.DbData("addVertexTx", tx);

				ITextResultList trl = vertexData.Result.GetTextResultsAt(0);

				for ( int i = 0 ; i < trl.Values.Count ; ++i ) {
					string idStr = trl.ToString(i);

					if ( idStr == null ) {
						throw new Exception("Vertex is null at index "+i+".");
					}

					vDataSet.Vertices[start+i].Vertex.Id = idStr;
				}

				if ( count >= vDataSet.Vertices.Count ) {
					break;
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SendEdgeTx() {
			int count = 0;

			while ( true ) {
				var tx = new WeaverTransaction();
				int limit = 10;
				Log.Debug("Edge "+count+" / "+vDataSet.Edges.Count);

				for ( int i = count ; i < vDataSet.Edges.Count ; ++i ) {
					if ( --limit < 0 ) {
						break;
					}

					tx.AddQuery(vDataSet.Edges[i].AddQuery);
					count++;
				}

				tx.Finish();
				ApiCtx.DbData("addEdgesTx", tx);

				if ( count >= vDataSet.Edges.Count ) {
					break;
				}
			}
		}

	}

}