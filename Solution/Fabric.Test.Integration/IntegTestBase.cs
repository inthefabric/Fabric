using System;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver;

namespace Fabric.Test.Integration {

	/*================================================================================================*/
	public class IntegTestBase {

		//protected static readonly DataSet SetupData = Setup.SetupAll(true);

		protected TestApiContext Context { get; private set; }
		protected bool IsReadOnlyTest { get; set; }

		private long vStartTime;
		private long vStartTime2;

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
			Log.Info("SetUp started");

			vStartTime = DateTime.UtcNow.Ticks;
			Context = new TestApiContext();
			TestSetUp();

			Log.Info("SetUp complete at T = "+GetTime());
			Log.Info("");
			Log.Info("=====================================");

			vStartTime2 = DateTime.UtcNow.Ticks;
		}

		/*--------------------------------------------------------------------------------------------*/
		[TearDown]
		public void TearDown() {
			Log.Info("");
			Log.Info("=====================================");
			Log.Info("");
			Log.Info("Core test time: "+(DateTime.UtcNow.Ticks-vStartTime2)/10000+"ms");
			Log.Info("TearDown started at T = "+GetTime());

			if ( !IsReadOnlyTest ) {
				var q = new WeaverQuery();
				q.FinalizeQuery("g.V.each{g.removeVertex(it)};g.loadGraphSON('data/FabricTestFull.json')");

				IApiDataAccess data = Context.DbData("TearDown", q);
				Assert.Null(data.Result.Text, "There was an issue with the TearDown query!");

				Log.Info("");
			}

			TestTearDown();
			Context = null;

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
			var q = new WeaverQuery();
			q.FinalizeQuery(GetNodeQuery<T>(pId));
			return Context.DbSingle<T>("TEST.GetNode", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected T GetNodeByProp<T>(string pProp, string pValWithQuotes)
																where T : class, INodeWithId, new() {
			var q = new WeaverQuery();
			q.FinalizeQuery(GetNodeQuery<Root>(0)+".outE('RootContains"+typeof(T).Name+"').inV"+
				".has('"+pProp+"',Tokens.T.eq,"+pValWithQuotes+")");
			return Context.DbSingle<T>("TEST.GetNodeByProp", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected NodeConnections GetNodeConnections<T>(T pNode) where T : class, INodeWithId, new() {
			string nodeQ = "g.v("+pNode.Id+")";

			var q = new WeaverQuery();
			q.FinalizeQuery("x=[];"+
				nodeQ+".outE.aggregate(x).inV.dedup.aggregate(x).iterate();"+
				nodeQ+".inE.aggregate(x).outV.dedup.aggregate(x).iterate();x");

			IApiDataAccess data = Context.DbData("TEST.GetNodeConnections", q);
			return new NodeConnections(pNode, data);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string GetNodeQuery<T>(long pId) where T : class, INodeWithId, new() {
			return "g.V('"+typeof(T).Name+"Id',"+pId+")[0]";
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetTime() {
			return (DateTime.UtcNow.Ticks-vStartTime)/10000+"ms";
		}

	}

}