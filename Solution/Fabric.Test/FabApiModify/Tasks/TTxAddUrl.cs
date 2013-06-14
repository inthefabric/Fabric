using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddUrl : TModifyTasks {

		private const string Query = 
			"_V0=[];"+ //Member
			"_V1=g.addVertex(["+
				PropDbName.Url_Name+":_TP,"+
				PropDbName.Url_AbsoluteUrl+":_TP,"+
				PropDbName.Artifact_ArtifactId+":_TP,"+
				PropDbName.Artifact_Created+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP);";

		private string vAbsoluteUrl;
		private string vName;
		private long vNewArtifactId;
		private DateTime vUtcNow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAbsoluteUrl = "http://www.mywebsite.com";
			vName = "My Web Site";
			vNewArtifactId = 27357427;
			vUtcNow = DateTime.UtcNow;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Artifact>()).Returns(vNewArtifactId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<Url> urlVar;

			Tasks.TxAddUrl(MockApiCtx.Object, TxBuild, vAbsoluteUrl, vName, memVar,out urlVar);
			FinishTx();

			Assert.NotNull(urlVar, "UrlVar should not be null.");
			Assert.AreEqual("_V1", urlVar.Name, "Incorrect UrlVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vName,
				vAbsoluteUrl,
				vNewArtifactId,
				vUtcNow.Ticks,
				(byte)NodeFabType.Url,
				RelDbName.MemberCreatesArtifact
			});
		}

	}

}