using System;
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
			"_V1=[];"+ //Member
			"_V2=g.V('"+typeof(User).Name+"Id',_TP0)[0]"+
				".outE('"+typeof(UserUsesEmail).Name+"').inV.next();"+
			"_V3=g.addVertex(["+
				typeof(App).Name+"Id:_TP1,"+
				"Name:_TP2,"+
				"ArtifactId:_TP3,"+
				"Created:_TP4,"+
				"FabType:_TP5"+
			"]);"+
			"g.addEdge(_V0,_V3,_TP6);"+
			"g.addEdge(_V3,_V2,_TP7);"+
			"g.addEdge(_V1,_V3,_TP8);";

		private string vName;
		private long vUserId;
		private long vNewAppId;
		private long vNewArtifactId;
		private DateTime vUtcNow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "NewApp";
			vUserId = 9876;
			vNewAppId = 43562742344;
			vNewArtifactId = 27357427;
			vUtcNow = DateTime.UtcNow;

			MockApiCtx.Setup(x => x.GetSharpflakeId<App>()).Returns(vNewAppId);
			MockApiCtx.Setup(x => x.GetSharpflakeId<Artifact>()).Returns(vNewArtifactId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<App> appVar;
			Action<IWeaverVarAlias<Member>> setMem;

			Tasks.TxAddApp(MockApiCtx.Object, TxBuild, vName, rootVar, vUserId, out appVar, out setMem);
			setMem(memVar);
			FinishTx();

			Assert.NotNull(appVar, "AppVar should not be null.");
			Assert.AreEqual("_V3", appVar.Name, "Incorrect AppVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vUserId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vNewAppId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", vNewArtifactId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", vUtcNow.Ticks);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", (int)NodeFabType.App);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", typeof(RootContainsApp).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", typeof(AppUsesEmail).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP8", typeof(MemberCreatesArtifact).Name);
		}

	}

}