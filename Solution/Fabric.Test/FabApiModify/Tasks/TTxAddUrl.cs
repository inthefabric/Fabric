using System;
using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddUrl : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=[];"+ //Member
			"_V2=g.addVertex(["+
				typeof(Url).Name+"Id:_TP0,"+
				"Name:_TP1,"+
				"AbsoluteUrl:_TP2,"+
				"ArtifactId:_TP3,"+
				"Created:_TP4,"+
				"FabType:_TP5"+
			"]);"+
			"g.addEdge(_V0,_V2,_TP6);"+
			"g.addEdge(_V1,_V2,_TP7);";

		private string vAbsoluteUrl;
		private string vName;
		private long vNewUrlId;
		private long vNewArtifactId;
		private DateTime vUtcNow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAbsoluteUrl = "http://www.mywebsite.com";
			vName = "My Web Site";
			vNewUrlId = 79875647;
			vNewArtifactId = 27357427;
			vUtcNow = DateTime.UtcNow;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Url>()).Returns(vNewUrlId);
			MockApiCtx.Setup(x => x.GetSharpflakeId<Artifact>()).Returns(vNewArtifactId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<Url> urlVar;

			Tasks.TxAddUrl(MockApiCtx.Object, TxBuild, vAbsoluteUrl, vName, rootVar, memVar,out urlVar);
			FinishTx();

			Assert.NotNull(urlVar, "UrlVar should not be null.");
			Assert.AreEqual("_V2", urlVar.Name, "Incorrect UrlVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewUrlId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vAbsoluteUrl);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", vNewArtifactId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", vUtcNow.Ticks);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", (int)NodeFabType.Url);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", typeof(RootContainsUrl).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", typeof(MemberCreatesArtifact).Name);
		}

	}

}