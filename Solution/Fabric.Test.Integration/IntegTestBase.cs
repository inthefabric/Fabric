using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Domain.Meta;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Elements;
using Weaver.Core.Query;
using Weaver.Core.Util;

namespace Fabric.Test.Integration {

	/*================================================================================================*/
	public class IntegTestBase {

		protected TestApiContext ApiCtx { get; private set; }
		protected bool IsReadOnlyTest { get; set; }
		protected int NewVertexCount { get; set; }
		protected int NewEdgeCount { get; set; }

		private Stopwatch vWatch;
		private Stopwatch vWatch2;
		private Tuple<int,int> vCounts;

		protected const SetupUsers.AppId AppFab = SetupUsers.AppId.FabSys;
		protected const SetupUsers.AppId AppGal = SetupUsers.AppId.KinPhoGal;
		protected const SetupUsers.AppId AppBook = SetupUsers.AppId.Bookmarker;

		protected const SetupUsers.UserId UserFab = SetupUsers.UserId.FabData;
		protected const SetupUsers.UserId UserGal = SetupUsers.UserId.GalData;
		protected const SetupUsers.UserId UserBook = SetupUsers.UserId.BookData;
		protected const SetupUsers.UserId UserZach = SetupUsers.UserId.Zach;
		protected const SetupUsers.UserId UserMel = SetupUsers.UserId.Mel;
		protected const SetupUsers.UserId UserEllie = SetupUsers.UserId.Ellie;
		protected const SetupUsers.UserId UserPenny = SetupUsers.UserId.Penny;


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

			ApiCtx = new TestApiContext();
			NewVertexCount = 0;
			NewEdgeCount = 0;

			TestSetUp();

			//vCounts = CountVerticesAndEdges();
			vCounts = new Tuple<int, int>(259, 590); //shortcut to help tests run faster

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
				IApiDataAccess remAllData = ApiCtx.DbData("TEST.RemoveAll", q);

				q = new WeaverQuery();
				q.FinalizeQuery("g.loadGraphSON('data/FabricTest.json');1");
				IApiDataAccess reloadData = ApiCtx.DbData("TEST.Edgeoad", q);

				Assert.AreEqual("1", remAllData.Result.TextList[0],
					"There was an issue with the RemoveAll query!");
				Assert.AreEqual("1", reloadData.Result.TextList[0],
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
			ApiCtx = null;

			Log.Info("TearDown complete at T = "+GetTime());
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void TestSetUp() {}
		protected virtual void TestPreTearDown() {}
		protected virtual void TestPostTearDown() {}

		/*--------------------------------------------------------------------------------------------*/
		protected T GetVertex<T>(long pId) where T : class, IVertexWithId, new() {
			return ApiCtx.DbSingle<T>("TEST.GetVertex", GetVertexQuery<T>(pId));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected T GetVertexByProp<T>(Expression<Func<T, object>> pProp, string pValWithQuotes)
												where T : class, IVertexWithId, IWeaverElement, new() {
			int ft = (byte)VertexFabTypeUtil.TypeMap[typeof(T)];

			var q = new WeaverQuery();
			q.FinalizeQuery("g.V.has('"+PropDbName.Vertex_FabType+"',Tokens.T.eq,(byte)"+ft+")"+
				".has('"+WeaverUtil.GetPropertyName(Weave.Inst.Config, pProp)+
				"',Tokens.T.eq,"+pValWithQuotes+")");
			return ApiCtx.DbSingle<T>("TEST.GetVertexByProp", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected VertexConnections GetVertexConnections<T>(T pVertex) where T : class, IVertexWithId, new() {
			string vertexQ = "g.v("+pVertex.Id+")";

			var q = new WeaverQuery();
			q.FinalizeQuery("x=[];"+
				vertexQ+".outE.aggregate(x).inV.dedup.aggregate(x).iterate();"+
				vertexQ+".inE.aggregate(x).outV.dedup.aggregate(x).iterate();x");

			IApiDataAccess data = ApiCtx.DbData("TEST.GetVertexConnections", q);
			return new VertexConnections(pVertex, data);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Tuple<int, int> CountVerticesAndEdges() {
			var q = new WeaverQuery();
			q.FinalizeQuery("[g.V.count(),g.E.count()]");
			IApiDataAccess data = ApiCtx.DbData("TEST.CountVE", q);
			return new Tuple<int, int>(data.GetIntResultAt(0), data.GetIntResultAt(1));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IWeaverQuery GetVertexQuery<T>(long pId, string pAppendScript="")
																where T : class, IVertexWithId, new() {
			SchemaHelperVertex hn = SchemaHelper.GetVertex(typeof(T).Name);
			string pkType = hn.GetPrimaryKeyProp().PropSchema.Name;
			pkType = pkType.Substring(0, pkType.Length-2);

			var q = new WeaverQuery();
			string idParam = q.AddParam(new WeaverQueryVal(pId));
			q.FinalizeQuery("g.V('"+PropDbName.StrTypeIdMap[pkType]+"',"+idParam+")[0]"+pAppendScript);
			return q;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverQuery GetVertexByPropQuery<T>(string pAppendScript="") where T : IVertexWithId {
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