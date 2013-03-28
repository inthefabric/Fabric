using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddApp : TWebTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"g.V('"+typeof(User).Name+"Id',_TP0)[0]"+
				".outE('"+typeof(UserUsesEmail).Name+"').inV"+
				".each{_V1=g.v(it)};"+
			"_V2=g.addVertex(["+
				typeof(App).Name+"Id:_TP1,"+
				"Name:_TP2"+
			"]);"+
			"g.addEdge(_V0,_V2,_TP3);"+
			"g.addEdge(_V2,_V1,_TP4);";

		private string vName;
		private long vUserId;
		private long vNewAppId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "NewApp";
			vUserId = 9876;
			vNewAppId = 43562742344;

			MockApiCtx.Setup(x => x.GetSharpflakeId<App>()).Returns(vNewAppId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<App> appVar;

			Tasks.TxAddApp(MockApiCtx.Object, TxBuild, vName, rootVar, vUserId, out appVar);
			FinishTx();

			Assert.NotNull(appVar, "AppVar should not be null.");
			Assert.AreEqual("_V2", appVar.Name, "Incorrect AppVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vUserId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vNewAppId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", typeof(RootContainsApp).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", typeof(AppUsesEmail).Name);
		}

	}

}