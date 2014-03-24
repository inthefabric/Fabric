using System;
using System.Diagnostics;
using Fabric.New.Database.Init;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
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
			string sessId = vOpCtx.Data.Build().AddSessionStart()
				.Execute("InitDb-StartIndexSession").GetSessionId();

			foreach ( IWeaverQuery q in vDataSet.Indexes ) {
				//Log.Debug(DataUtil.WeaverQueryToJson(q));
				vOpCtx.Data.Build(sessId).AddQuery(q).Execute("InitDb-AddIndex");
			}

			vOpCtx.Data.Build(sessId).AddSessionCommit().AddSessionClose()
				.Execute("InitDb-CloseIndexSession");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SendVertexTx() {
			int count = vDataSet.Vertices.Count;

			for ( int i = 0 ; i < count ; i++ ) {
				IDataVertex n = vDataSet.Vertices[i];
				Log.Debug("Vertex "+(i+1)+"/"+count);//+": "+DataUtil.WeaverQueryToJson(n.AddQuery));

				Vertex v = vOpCtx.Data
					.Execute(n.AddQuery, "InitDb-AddVert")
					.ToElementAt<Vertex>(0, 0);

				n.Vertex.Id = v.Id;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SendEdgeTx() {
			int count = vDataSet.Edges.Count;

			for ( int i = 0 ; i < count ; i++ ) {
				IDataEdge t = vDataSet.Edges[i];
				Log.Debug("Edge "+(i+1)+"/"+count);//+": "+DataUtil.WeaverQueryToJson(t.AddQuery));
				vOpCtx.Data.Execute(t.AddQuery, "InitDb-AddEdge");
			}
		}
	}

}