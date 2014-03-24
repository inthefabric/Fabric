using System;
using System.Diagnostics;
using System.Threading;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Data;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.Shared {

	/*================================================================================================*/
	public abstract class IntegrationTest {

		private static readonly Logger Log = Logger.Build<IntegrationTest>();

		protected TestOperationContext OpCtx { get; private set; }
		protected bool IsReadOnlyTest { get; set; }
		protected int NewVertexCount { get; set; }
		protected int NewEdgeCount { get; set; }
		protected Action VerificationQueryFunc { get; set; }
		protected bool UsesElasticSearch { get; set; }

		private Stopwatch vWatch;
		private Stopwatch vWatch2;
		private Tuple<int,int> vCounts;


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
			IsReadOnlyTest = false;
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

			AssertionException verifEx = null;

			if ( VerificationQueryFunc != null ) {
				try {
					VerificationQueryFunc();
				}
				catch ( AssertionException e ) {
					verifEx = e;
				}
			}

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
				q.FinalizeQuery("g.loadGraphSON('../db/FabricBackups/FabricTest.json');1");
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

			if ( verifEx != null ) {
				throw verifEx;
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Tuple<int, int> CountVerticesAndEdges() {
			var q = new WeaverQuery();
			q.FinalizeQuery("[g.V.count(),g.E.count()]");
			IDataResult data = OpCtx.ExecuteForTest(q, "Base-Count");
			return new Tuple<int, int>(data.ToIntAt(0, 0), data.ToIntAt(0, 1));
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetTime() {
			return vWatch.ElapsedMilliseconds+"ms";
		}

	}

}