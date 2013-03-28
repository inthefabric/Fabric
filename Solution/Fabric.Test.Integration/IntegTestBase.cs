using System;
using System.Linq.Expressions;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Test.Integration {

	/*================================================================================================*/
	public class IntegTestBase {

		//protected static readonly DataSet SetupData = Setup.SetupAll(true);
		//protected static readonly Dictionary<int, IDataNode> SetupNodeMap = BuildSetupNodeMap();
		//protected static readonly Dictionary<string, IDataRel> SetupRel = BuildSetupRelMap();

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
		/*--------------------------------------------------------------------------------------------* /
		private static Dictionary<int, IDataNode> BuildSetupNodeMap() {
			var map = new Dictionary<int, IDataNode>();

			foreach ( IDataNode n in SetupData.Nodes ) {
				map.Add(n.TestVal, n);
			}

			return map;
		}
		
		/*--------------------------------------------------------------------------------------------* /
		private static Dictionary<string, IDataRel> BuildSetupRelMap() {
			var map = new Dictionary<string, IDataRel>();

			foreach ( IDataRel r in SetupData.Nodes ) {
				map.Add(r.TestVal, r);
			}

			return map;
		}


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
			NewNodeCount = 0;
			NewRelCount = 0;

			TestSetUp();

			//vCounts = CountNodesAndRels();
			vCounts = new Tuple<int, int>(637, 2015); //shortcut to help tests run faster

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

			Log.Info("");
			Log.Info("=====================================");
			Log.Info("");
			Log.Info("Core test time: "+(DateTime.UtcNow.Ticks-vStartTime2)/10000+"ms");
			Log.Info("TearDown started at T = "+GetTime());

			////

			Tuple<int, int> c = CountNodesAndRels();
			Log.Info("Counts { V = "+c.Item1+", E = "+c.Item2+" }");

			if ( !IsReadOnlyTest ) {
				var q = new WeaverQuery();
				q.FinalizeQuery("g.V.remove()");
				IApiDataAccess data = ApiCtx.DbData("TEST.RemoveAll", q);
				Assert.AreEqual("", data.Result.Text, "There was an issue with the RemoveAll query!");

				q = new WeaverQuery();
				q.FinalizeQuery("g.loadGraphSON('data/FabricTestFull.json');1");
				data = ApiCtx.DbData("TEST.Reload", q);
				Assert.AreEqual("1", data.Result.Text, "There was an issue with the Reload query!");

				/*IWeaverQuery q = new WeaverQuery();
				//q.FinalizeQuery("g.E[2015..99999].remove();g.V[637..99999].remove();1");
				q.FinalizeQuery("g.E.has('TestVal',Tokens.T.eq,null).remove();"+
					"g.V.has('TestVal',Tokens.T.eq,null).remove();1");
				IApiDataAccess data = ApiCtx.DbData("TEST.RemoveNew", q);
				Assert.AreEqual("1", data.Result.Text, "There was an issue with the RemoveNew query!");

				if ( c.Item1 != vCounts.Item1 ) {
					q = new WeaverQuery();
					q.FinalizeQuery("g.V");
					data = ApiCtx.DbData("TEST.GetVertices", q);

					var nodeMap = new Dictionary<int, IDbDto>();

					foreach ( IDbDto dto in data.ResultDtoList ) {
						nodeMap.Add(int.Parse(dto.Data["TestId"]), dto);
					}

					foreach ( IDataNode n in SetupData.Nodes ) {
						if ( nodeMap.ContainsKey(n.TestVal) ) {
							n.Node.Id = (long)nodeMap[n.TestVal].Id;
							continue;
						}

						var tx = new WeaverTransaction();
						IWeaverVarAlias nodeVar;
						tx.AddQuery(WeaverTasks.StoreQueryResultAsVar(tx, n.AddQuery, out nodeVar));

						q = new WeaverQuery();
						string idParam = q.AddParam(new WeaverQueryVal(n.TestVal));
						q.FinalizeQuery(nodeVar.Name+".TestVal="+idParam);
						tx.AddQuery(q);

						data = ApiCtx.DbData("TEST.AddVertexTx", tx.Finish(nodeVar));
						n.Node.Id = (long)data.ResultDtoList[0].Id;
					}
				}

				if ( c.Item2 != vCounts.Item2 ) {
					q = new WeaverQuery();
					q.FinalizeQuery("g.E.TestVal");
					data = ApiCtx.DbData("TEST.GetEdgeTestVals", q);

					var relMap = new HashSet<string>();

					foreach ( string s in data.Result.TextList ) {
						relMap.Add(s);
					}

					foreach ( IDataRel r in SetupData.Rels ) {
						if ( relMap.Contains(r.TestVal) ) {
							continue;
						}

						r.FromNode.Id = SetupData.GetDataNode(r.FromNode).Node.Id;
						r.ToNode.Id = SetupData.GetDataNode(r.ToNode).Node.Id;
						ApiCtx.DbData("TEST.AddRel", r.AddQuery);
					}

					q = new WeaverQuery();
					q.FinalizeQuery("g.E.each{it.TestVal="+
						"(it.outV.TestVal.next()+'|'+it.label+'|'+it.inV.TestVal.next())}");
					ApiCtx.DbData("setRelTestVals", q);
				}*/

				Log.Info("");
			}
			else {
				Log.Info("READ ONLY MODE: skipped database reset");
			}

			Assert.AreEqual(NewNodeCount, c.Item1-vCounts.Item1, "Incorrect new node count.");
			Assert.AreEqual(NewRelCount, c.Item2-vCounts.Item2, "Incorrect new rel count.");

			if ( IsReadOnlyTest ) {
				Assert.AreEqual(0, NewNodeCount, "NewNodeCount should be zero!");
				Assert.AreEqual(0, NewRelCount, "NewRelCount should be zero!");
			}

			////

			TestTearDown();
			ApiCtx = null;

			Log.Info("TearDown complete at T = "+GetTime());
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void TestSetUp() {}
		protected virtual void TestTearDown() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		protected IList<T> GetSetupNodes<T>() where T : INode {
			var list = new List<T>();
			var t = typeof(T);

			foreach ( IDataNode dn in SetupData.Nodes ) {
				if ( dn.NodeType == t ) {
					list.Add((T)dn.Node);
				}
			}

			return list;
		}*/

		/*--------------------------------------------------------------------------------------------*/
		protected T GetNode<T>(long pId) where T : class, INodeWithId, new() {
			return ApiCtx.DbSingle<T>("TEST.GetNode", GetNodeQuery<T>(pId));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected T GetNodeByProp<T>(Expression<Func<T,object>> pProp, string pValWithQuotes)
																where T : class, INodeWithId, new() {
			var q = GetNodeQuery<Root>(0, ".outE('RootContains"+typeof(T).Name+"').inV"+
				".has('"+WeaverUtil.GetPropertyName(pProp)+"',Tokens.T.eq,"+pValWithQuotes+")");
			return ApiCtx.DbSingle<T>("TEST.GetNodeByProp", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected NodeConnections GetNodeConnections<T>(T pNode) where T : class, INodeWithId, new() {
			string nodeQ = "g.v("+pNode.Id+")";

			var q = new WeaverQuery();
			q.FinalizeQuery("x=[];"+
				nodeQ+".outE.aggregate(x).inV.dedup.aggregate(x).iterate();"+
				nodeQ+".inE.aggregate(x).outV.dedup.aggregate(x).iterate();x");

			IApiDataAccess data = ApiCtx.DbData("TEST.GetNodeConnections", q);
			return new NodeConnections(pNode, data);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Tuple<int, int> CountNodesAndRels() {
			var q = new WeaverQuery();
			q.FinalizeQuery("[g.V.count(),g.E.count()]");
			IApiDataAccess data = ApiCtx.DbData("TEST.CountVE", q);
			return new Tuple<int, int>(data.GetIntResultAt(0), data.GetIntResultAt(1));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IWeaverQuery GetNodeQuery<T>(long pId, string pAppendScript="")
																where T : class, INodeWithId, new() {
			var q = new WeaverQuery();
			string idParam = q.AddParam(new WeaverQueryVal(pId));
			q.FinalizeQuery("g.V('"+typeof(T).Name+"Id',"+idParam+")[0]"+pAppendScript);
			return q;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetTime() {
			return (DateTime.UtcNow.Ticks-vStartTime)/10000+"ms";
		}

	}

}