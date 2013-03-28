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
			"g.V('"+typeof(Root).Name+"Id',_TP0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(Factor).Name+"Id:_TP1,"+
				"IsDefining:_TP2,"+
				"Created:_TP3,"+
				"Note:_TP4"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP5);"+
			"g.V('"+typeof(Artifact).Name+"Id',_TP6)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V1,_V2,_TP7);"+
			"g.V('"+typeof(Artifact).Name+"Id',_TP8)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,_TP9);"+
			"g.V('"+typeof(FactorAssertion).Name+"Id',_TP10)[0].each{_V4=g.v(it)};"+
			"g.addEdge(_V1,_V4,_TP11);"+
			"g.V('"+typeof(Member).Name+"Id',_TP12)[0].each{_V5=g.v(it)};"+
			"g.addEdge(_V5,_V1,_TP13);";

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
			var mem = new Member { MemberId = 12345 };
			IWeaverVarAlias<Factor> factorVar;

			Tasks.TxAddFactor(MockApiCtx.Object, TxBuild, vPrimArtId, vRelArtId, vAssertId, vIsDefining,
				vNote, mem, out factorVar);
			FinishTx();

			Assert.NotNull(factorVar, "FactorVar should not be null.");
			Assert.AreEqual("_V1", factorVar.Name, "Incorrect FactorVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", 0);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vNewFactorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", true);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", vUtcNow.Ticks);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", vNote);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", typeof(RootContainsFactor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", vPrimArtId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7",
				typeof(FactorUsesPrimaryArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP8", vRelArtId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP9",
				typeof(FactorUsesRelatedArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP10", vAssertId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP11",
				typeof(FactorUsesFactorAssertion).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP12", mem.MemberId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP13", typeof(MemberCreatesFactor).Name);
		}

	}

}