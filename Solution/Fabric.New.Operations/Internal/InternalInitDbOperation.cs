using System;
using System.Diagnostics;
using Fabric.New.Database.Init;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Util;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Internal {

	/*================================================================================================*/
	public class InternalInitDbOperation : IInternalOperation {

		private static readonly Logger Log = Logger.Build<InternalInitDbOperation>();

		private IOperationContext vOpCtx { get; set; }
		private DataSet vDataSet;
		private object vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Perform(IOperationContext pOpCtx, string pPass) {
			vOpCtx = pOpCtx;

			if ( pPass != "build-0.3.0" ) {
				vResult = new {
					Error = "Password required."
				};

				return;
			}

			var sw = new Stopwatch();
			sw.Start();

			try {
#if DEBUG
				vDataSet = Setup.SetupAll(true);
#else
				vDataSet = Setup.SetupAll(false);
#endif
				//PrintAllQueries();
				//SendSetupTx();
				SendIndexTx();
				SendVertexTx();
				SendEdgeTx();

				vResult = new {
					Success = true,
					Seconds = sw.ElapsedMilliseconds/1000.0
				};
			}
			catch ( Exception ex ) {
				Log.Error("Error", ex);
				
				vResult = new {
					Error = ex.Message
				};
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public object GetResult() {
			return vResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		private void PrintAllQueries() {
			int vi = 0;

			foreach ( WeaverQuery q in vDataSet.Initialization ) {
				Log.Debug(DataUtil.WeaverQueryToJson(q));
			}

			foreach ( WeaverQuery q in vDataSet.Indexes ) {
				Log.Debug(DataUtil.WeaverQueryToJson(q));
			}

			foreach ( IDataVertex n in vDataSet.Vertices ) {
				Log.Debug(DataUtil.WeaverQueryToJson(n.AddQuery));
				n.Vertex.Id = (vi++)+"";
			}

			foreach ( IDataEdge r in vDataSet.Edges ) {
				Log.Debug(DataUtil.WeaverQueryToJson(r.AddQuery));
			}
		}
		
		/*--------------------------------------------------------------------------------------------* /
		private void SendSetupTx() {
			Log.Debug("Remove all verts");
			var tx = new WeaverTransaction();

			foreach ( IWeaverQuery q in vDataSet.Initialization ) {
				tx.AddQuery(q);
			}

			tx.Finish();
			OpCtx.Execute(tx);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SendIndexTx() {
			Log.Debug("Create Indexes...");
			string sessId = vOpCtx.NewData().AddSessionStart()
				.Execute("InitDb-StartIndexSession").GetSessionId();

			foreach ( IWeaverQuery q in vDataSet.Indexes ) {
				Log.Debug(DataUtil.WeaverQueryToJson(q));
				vOpCtx.NewData(sessId).AddQuery(q).Execute("InitDb-AddIndex");
			}

			vOpCtx.NewData(sessId).AddSessionCommit().AddSessionClose()
				.Execute("InitDb-CloseIndexSession");
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

					Log.Debug(DataUtil.WeaverQueryToJson(n.AddQuery));
					tx.AddQuery(WeaverQuery.StoreResultAsVar("vertex", n.AddQuery, out vertexVar));
					listScript += vertexVar.Name+".id,";
				}

				var listQ = new WeaverQuery();
				listQ.FinalizeQuery("["+listScript.Substring(0, listScript.Length-1)+"]");
				tx.AddQuery(listQ);

				tx.Finish();
				IDataResult result = vOpCtx.Execute(tx, "InitDb-AddVert");

				for ( int i = 0 ; i < result.GetCommandResultCount() ; ++i ) {
					string idStr = result.ToStringAt(0, i);

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

					IWeaverQuery q = vDataSet.Edges[i].AddQuery;
					Log.Debug(DataUtil.WeaverQueryToJson(q));
					tx.AddQuery(q);
					count++;
				}

				tx.Finish();
				vOpCtx.Execute(tx, "InitDb-AddEdge");

				if ( count >= vDataSet.Edges.Count ) {
					break;
				}
			}
		}

	}

}