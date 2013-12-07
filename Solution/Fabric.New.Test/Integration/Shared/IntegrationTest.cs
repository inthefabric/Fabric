using System;
using System.Diagnostics;
using System.Threading;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using NUnit.Framework;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.New.Test.Integration.Shared {

	/*================================================================================================*/
	public abstract class IntegrationTest {

		private static readonly Logger Log = Logger.Build<IntegrationTest>();

		protected TestOperationContext OpCtx { get; private set; }
		protected bool IsReadOnlyTest { get; set; }
		protected int NewVertexCount { get; set; }
		protected int NewEdgeCount { get; set; }
		protected bool UsesElasticSearch { get; set; }

		private Stopwatch vWatch;
		private Stopwatch vWatch2;
		private Tuple<int,int> vCounts;

		protected const SetupAppId AppFab = SetupAppId.FabSys;
		protected const SetupAppId AppGal = SetupAppId.KinPhoGal;
		protected const SetupAppId AppBook = SetupAppId.Bookmarker;

		protected const SetupUserId UserFab = SetupUserId.FabData;
		protected const SetupUserId UserGal = SetupUserId.GalData;
		protected const SetupUserId UserBook = SetupUserId.BookData;
		protected const SetupUserId UserZach = SetupUserId.Zach;
		protected const SetupUserId UserMel = SetupUserId.Mel;
		protected const SetupUserId UserEllie = SetupUserId.Ellie;
		protected const SetupUserId UserPenny = SetupUserId.Penny;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
#if LIVE
			Assert.Fail("Cannot run integration tests in LIVE mode!");
#endif

			Log.Info("SetUp started");

			vWatch = new Stopwatch();
			vWatch.Start();

			OpCtx = new TestOperationContext();
			NewVertexCount = 0;
			NewEdgeCount = 0;

			TestSetUp();

			if ( UsesElasticSearch ) {
				Thread.Sleep(1000); //ElasticSearch has a delay when re-indexing
			}

			//vCounts = CountVerticesAndEdges();
			vCounts = new Tuple<int, int>(215, 934); //shortcut to help tests run faster

			Log.Info("SetUp complete at T = "+GetTime());
			Log.Info("Counts { V = "+vCounts.Item1+", E = "+vCounts.Item2+" }");
			Log.Info("");
			Log.Info("=====================================");

			vWatch2 = new Stopwatch();
			vWatch2.Start();
		}

		/*--------------------------------------------------------------------------------------------*/
		[TearDown]
		public void TearDown() {
#if LIVE
			Assert.Fail("Skipping TearDown in LIVE mode.");
#endif
			TestPreTearDown();

			Log.Info("");
			Log.Info("=====================================");
			Log.Info("");
			Log.Info("Core test time: "+vWatch2.ElapsedMilliseconds+"ms");
			Log.Info("TearDown started at T = "+GetTime());

			////

			Tuple<int, int> c = CountVerticesAndEdges();
			Log.Info("Counts { V = "+c.Item1+", E = "+c.Item2+" }");

			int vertexDiff = c.Item1-vCounts.Item1;
			int edgeDiff = c.Item2-vCounts.Item2;

			if ( IsReadOnlyTest && 
					(vertexDiff != 0 || edgeDiff != 0 || NewVertexCount != 0 || NewEdgeCount != 0) ) {
				Log.Info("");
				Log.Info("WARNING: Overriding read-only mode due to counts: "+
					vertexDiff+", "+edgeDiff+", "+NewVertexCount+", "+NewEdgeCount);
				Log.Info("");
				IsReadOnlyTest = false;
			}

			if ( !IsReadOnlyTest ) {
				var q = new WeaverQuery();
				q.FinalizeQuery("g.V.remove();1");
				IDataResult remAllData = OpCtx.ExecuteForTest(q);

				q = new WeaverQuery();
				q.FinalizeQuery("g.loadGraphSON('db/FabricBackups/FabricTest.json');1");
				IDataResult reloadData = OpCtx.ExecuteForTest(q);

				Assert.AreEqual("1", remAllData.ToStringAt(0, 0),
					"There was an issue with the RemoveAll query!");
				Assert.AreEqual("1", reloadData.ToStringAt(0, 0),
					"There was an issue with the Reload query!");
				Log.Info("");
			}
			else {
				Log.Info("READ ONLY MODE: skipped database reset");
			}

			Assert.AreEqual(NewVertexCount, vertexDiff, "Incorrect new vertex count.");
			Assert.AreEqual(NewEdgeCount, edgeDiff, "Incorrect new edge count.");

			if ( IsReadOnlyTest ) {
				Assert.AreEqual(0, NewVertexCount, "NewVertexCount should be zero!");
				Assert.AreEqual(0, NewEdgeCount, "NewEdgeCount should be zero!");
			}

			////

			TestPostTearDown();
			OpCtx = null;

			Log.Info("TearDown complete at T = "+GetTime());
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void TestSetUp() {}
		protected virtual void TestPreTearDown() {}
		protected virtual void TestPostTearDown() {}

		/*--------------------------------------------------------------------------------------------*/
		protected T GetVertex<T>(long pId) where T : class, IWeaverElement, IVertex, new() {
			return OpCtx.ExecuteForTest(GetVertexQuery<T>(pId)).ToElement<T>();
		}

		/*--------------------------------------------------------------------------------------------* /
		protected T GetVertexByProp<T>(Expression<Func<T, object>> pProp, string pValWithQuotes)
												where T : class, IVertex, IWeaverElement, new() {
			int ft = (byte)VertexFabTypeUtil.TypeMap[typeof(T)];

			var q = new WeaverQuery();
			q.FinalizeQuery("g.V.has('"+DbName.Vert.Vertex.VertexType+"',Tokens.T.eq,(byte)"+ft+")"+
				".has('"+WeaverUtil.GetPropertyDbName(pProp)+"',Tokens.T.eq,"+pValWithQuotes+")");
			return ApiCtx.ExecuteForTest(q).ToElement<T>();
		}

		/*--------------------------------------------------------------------------------------------* /
		protected VertexConnections GetVertexConnections<T>(T pVertex) where T : class, IVertex, new() {
			string vertexQ = "g.v("+pVertex.Id+")";

			var q = new WeaverQuery();
			q.FinalizeQuery("x=[];"+
				vertexQ+".outE.aggregate(x).inV.dedup.aggregate(x).iterate();"+
				vertexQ+".inE.aggregate(x).outV.dedup.aggregate(x).iterate();x");

			return new VertexConnections(pVertex, ApiCtx.Execute(q, "Test-Base-GetVertConn"));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Tuple<int, int> CountVerticesAndEdges() {
			var q = new WeaverQuery();
			q.FinalizeQuery("[g.V.count(),g.E.count()]");
			IDataResult data = OpCtx.ExecuteForTest(q, "Base-Count");
			return new Tuple<int, int>(data.ToIntAt(0, 0), data.ToIntAt(0, 1));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverQuery GetVertexQuery<T>(long pId, string pAppendScript="")
																	where T : class, IVertex, new() {
			var q = new WeaverQuery();
			string idParam = q.AddParam(new WeaverQueryVal(pId));
			q.FinalizeQuery("g.V('"+DbName.Vert.Vertex.VertexId+"',"+idParam+")[0]"+pAppendScript);
			return q;
		}

		/*--------------------------------------------------------------------------------------------* /
		protected IWeaverQuery GetVertexByPropQuery<T>(string pAppendScript="") where T : IVertex {
			int ft = (byte)VertexFabTypeUtil.TypeMap[typeof(T)];

			var q = new WeaverQuery();
			q.FinalizeQuery("g.V.has('"+PropDbName.Vertex_FabType+"',Tokens.T.eq,(byte)"+ft+")"+
				pAppendScript);
			return q;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetTime() {
			return vWatch.ElapsedMilliseconds+"ms";
		}

	}

}