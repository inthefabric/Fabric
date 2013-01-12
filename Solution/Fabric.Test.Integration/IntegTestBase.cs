using System;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver;

namespace Fabric.Test.Integration {

	/*================================================================================================*/
	public class IntegTestBase {

		//protected static readonly DataSet SetupData = Setup.SetupAll(true);

		protected TestApiContext Context { get; private set; }

		private long vStartTime;

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
			vStartTime = DateTime.UtcNow.Ticks;
			Context = new TestApiContext();
			TestSetUp();
		}

		/*--------------------------------------------------------------------------------------------*/
		[TearDown]
		public void TearDown() {
			var q = new WeaverQuery();
			q.FinalizeQuery("g.V.each{g.removeVertex(it)};g.loadGraphSON('data/FabricTestFull.json')");
			Context.DbData("TearDown", q);

			TestTearDown();
			Context = null;

			Log.Debug("Total test time: "+(DateTime.UtcNow.Ticks-vStartTime)/10000.0+"ms");
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
			q.FinalizeQuery("g.V('"+typeof(T).Name+"Id',"+pId+")[0]");
			return Context.DbSingle<T>("TEST.GetNode", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected T GetNodeByProp<T>(string pProp, string pValWithQuotes)
																where T : class, INodeWithId, new() {
			var q = new WeaverQuery();
			q.FinalizeQuery("g.V('RootId',0)[0].outE('RootContains"+typeof(T).Name+"').inV"+
				".has('"+pProp+"',Tokens.T.eq,"+pValWithQuotes+")");
			return Context.DbSingle<T>("TEST.GetNodeByProp", q);
		}

	}

}