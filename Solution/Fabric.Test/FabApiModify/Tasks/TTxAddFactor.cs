using System;
using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddFactor : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=[];"+ //Member
			"_V2=g.addVertex(["+
				typeof(Factor).Name+"Id:{{NewFactorId}}L,"+
				"IsDefining:true,"+
				"Created:{{UtcNowTicks}}L,"+
				"Note:_TP0"+
			"]);"+
			"g.addEdge(_V0,_V2,_TP1);"+
			"g.V('"+typeof(Artifact).Name+"Id',1251253L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V2,_V3,_TP2);"+
			"g.V('"+typeof(Artifact).Name+"Id',64362346L)[0].each{_V4=g.v(it)};"+
			"g.addEdge(_V2,_V4,_TP3);"+
			"g.V('"+typeof(FactorAssertion).Name+"Id',1L)[0].each{_V5=g.v(it)};"+
			"g.addEdge(_V2,_V5,_TP4);"+
			"g.addEdge(_V1,_V2,_TP5);";

		private long vPrimArtId;
		private long vRelArtId;
		private long vAssertId;
		private bool vIsDefining;
		private string vNote;
		private DateTime vUtcNow;
		private long vNewFactorId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vPrimArtId = 1251253;
			vRelArtId = 64362346;
			vAssertId = 1;
			vIsDefining = true;
			vNote = "note here";
			vUtcNow = new DateTime();
			vNewFactorId = 798756473;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Factor>()).Returns(vNewFactorId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<Factor> factorVar;

			Tasks.TxAddFactor(MockApiCtx.Object, TxBuild, vPrimArtId, vRelArtId, vAssertId, vIsDefining,
				vNote, rootVar, memVar, out factorVar);
			FinishTx();

			Assert.NotNull(factorVar, "FactorVar should not be null.");
			Assert.AreEqual("_V2", factorVar.Name, "Incorrect FactorVar name.");

			string expect = Query
				.Replace("{{NewFactorId}}", vNewFactorId+"")
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNote);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", typeof(RootContainsFactor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2",
				typeof(FactorUsesPrimaryArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3",
				typeof(FactorUsesRelatedArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4",
				typeof(FactorUsesFactorAssertion).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", typeof(MemberCreatesFactor).Name);
		}

	}

}