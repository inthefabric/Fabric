using System;
using System.Linq.Expressions;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Test.Integration {

	/*================================================================================================*/
	public class IntegTestBase {

		protected TestApiContext ApiCtx { get; private set; }
		protected bool IsReadOnlyTest { get; set; }
		protected int NewNodeCount { get; set; }
		protected int NewRelCount { get; set; }

		private long vStartTime;
		private long vStartTime2;
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

			vStartTime = DateTime.UtcNow.Ticks;
			
			ApiCtx = new TestApiContext();
			ApiCtx.PerformSessionAction(RexConnSessionAction.Start);

			NewNodeCount = 0;
			NewRelCount = 0;

			TestSetUp();

			vCounts = new Tuple<int, int>(259, 590); //shortcut to help tests run faster

			Log.Info("SetUp complete at T = "+GetTime());
			Log.Info("Counts { V = "+vCounts.Item1+", E = "+vCounts.Item2+" }");
			Log.Info("");
			Log.Info("=====================================");

			vStartTime2 = DateTime.UtcNow.Ticks;
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
			Log.Info("Core test time: "+(DateTime.UtcNow.Ticks-vStartTime2)/10000+"ms");
			Log.Info("TearDown started at T = "+GetTime());

			ApiCtx.Cache.UniqueClasses.Dispose();

			////

			Tuple<int, int> c = CountNodesAndRels();
			Log.Info("Counts { V = "+c.Item1+", E = "+c.Item2+" }");

			ApiCtx.CloseInternalSessions();
			ApiCtx.PerformSessionAction(RexConnSessionAction.Rollback);
			ApiCtx.PerformSessionAction(RexConnSessionAction.Close);

			int nodeDiff = c.Item1-vCounts.Item1;
			int relDiff = c.Item2-vCounts.Item2;

			Assert.AreEqual(NewNodeCount, nodeDiff, "Incorrect new node count.");
			Assert.AreEqual(NewRelCount, relDiff, "Incorrect new rel count.");

			if ( IsReadOnlyTest ) {
				Assert.AreEqual(0, NewNodeCount, "NewNodeCount should be zero!");
				Assert.AreEqual(0, NewRelCount, "NewRelCount should be zero!");
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
		protected T GetNode<T>(long pId) where T : class, INodeWithId, new() {
			return ApiCtx.DbSingle<T>("TEST.GetNode", GetNodeQuery<T>(pId));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected T GetNodeByProp<T>(Expression<Func<T, object>> pProp, string pValWithQuotes)
											where T : class, INodeWithId, IWeaverItemIndexable, new() {
			int ft = (int)NodeFabTypeUtil.TypeMap[typeof(T)];

			var q = Weave.Inst.NewQuery();
			q.FinalizeQuery("g.V('"+PropDbName.Node_FabType+"',"+ft+")"+
				".has('"+WeaverUtil.GetPropertyName(Weave.Inst.Config, pProp)+
				"',Tokens.T.eq,"+pValWithQuotes+")");
			return ApiCtx.DbSingle<T>("TEST.GetNodeByProp", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected NodeConnections GetNodeConnections<T>(T pNode) where T : class, INodeWithId, new() {
			string nodeQ = "g.v("+pNode.Id+")";

			var q = Weave.Inst.NewQuery();
			q.FinalizeQuery("x=[];"+
				nodeQ+".outE.aggregate(x).inV.dedup.aggregate(x).iterate();"+
				nodeQ+".inE.aggregate(x).outV.dedup.aggregate(x).iterate();x");

			IApiDataAccess data = ApiCtx.DbData("TEST.GetNodeConnections", q);

			//when the "x" variable is not reset, the integration test fails
			//resulting bug report: http://github.com/thinkaurelius/titan/issues/255
			q = Weave.Inst.NewQuery();
			q.FinalizeQuery("x=null");
			ApiCtx.DbData("TEST.GetNodeConnections", q);

			return new NodeConnections(pNode, data);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Tuple<int, int> CountNodesAndRels() {
			var q = Weave.Inst.NewQuery();
			q.FinalizeQuery("[g.V.count(),g.E.count()]");
			IApiDataAccess data = ApiCtx.DbData("TEST.CountVE", q);
			return new Tuple<int, int>(data.GetIntResultAt(0), data.GetIntResultAt(1));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IWeaverQuery GetNodeQuery<T>(long pId, string pAppendScript="")
																where T : class, INodeWithId, new() {
			var q = Weave.Inst.NewQuery();
			string idParam = q.AddParam(new WeaverQueryVal(pId));
			q.FinalizeQuery("g.V('"+PropDbName.TypeIdMap[typeof(T)]+"',"+idParam+")[0]"+pAppendScript);
			return q;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverQuery GetNodeByPropQuery<T>(string pAppendScript="") where T : INodeWithId {
			int ft = (int)NodeFabTypeUtil.TypeMap[typeof(T)];

			var q = Weave.Inst.NewQuery();
			q.FinalizeQuery("g.V('"+PropDbName.Node_FabType+"',"+ft+")"+pAppendScript);
			return q;
		}


		/*--------------------------------------------------------------------------------------------*/
		private string GetTime() {
			return (DateTime.UtcNow.Ticks-vStartTime)/10000+"ms";
		}

	}

}