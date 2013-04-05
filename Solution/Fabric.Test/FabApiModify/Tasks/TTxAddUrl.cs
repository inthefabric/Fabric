﻿using System;
using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddUrl : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Member
			"_V1=g.addVertex(["+
				typeof(Url).Name+"Id:_TP,"+
				"Name:_TP,"+
				"AbsoluteUrl:_TP,"+
				"ArtifactId:_TP,"+
				"Created:_TP,"+
				"FabType:_TP"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP);";

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
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<Url> urlVar;

			Tasks.TxAddUrl(MockApiCtx.Object, TxBuild, vAbsoluteUrl, vName, memVar,out urlVar);
			FinishTx();

			Assert.NotNull(urlVar, "UrlVar should not be null.");
			Assert.AreEqual("_V1", urlVar.Name, "Incorrect UrlVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewUrlId,
				vName,
				vAbsoluteUrl,
				vNewArtifactId,
				vUtcNow.Ticks,
				(int)NodeFabType.Url,
				typeof(MemberCreatesArtifact).Name
			});
		}

	}

}