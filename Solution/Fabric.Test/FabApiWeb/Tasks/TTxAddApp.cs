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
			"_V0=[];"+ //Member
			"_V1=g.V('"+typeof(User).Name+"Id',_TP)"+
				".outE('"+typeof(UserUsesEmail).Name+"').inV.next();"+
			"_V2=g.addVertex(["+
				typeof(App).Name+"Id:_TP,"+
				"Name:_TP,"+
				"ArtifactId:_TP,"+
				"Created:_TP,"+
				"FabType:_TP"+
			"]);"+
			"g.addEdge(_V2,_V1,_TP);"+
			"g.addEdge(_V0,_V2,_TP);";

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
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<App> appVar;
			Action<IWeaverVarAlias<Member>> setMem;

			Tasks.TxAddApp(MockApiCtx.Object, TxBuild, vName, vUserId, out appVar, out setMem);
			setMem(memVar);
			FinishTx();

			Assert.NotNull(appVar, "AppVar should not be null.");
			Assert.AreEqual("_V2", appVar.Name, "Incorrect AppVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vUserId,
				vNewAppId,
				vName,
				vNewArtifactId,
				vUtcNow.Ticks,
				(int)NodeFabType.App,
				typeof(AppUsesEmail).Name,
				typeof(MemberCreatesArtifact).Name
			});
		}

	}

}