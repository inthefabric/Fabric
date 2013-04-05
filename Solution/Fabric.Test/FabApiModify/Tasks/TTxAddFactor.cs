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
			"_V1=g.addVertex(["+
				typeof(Factor).Name+"Id:_TP1,"+
				"IsDefining:_TP2,"+
				"Created:_TP3,"+
				"Note:_TP4,"+
				"FabType:_TP5"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP6);"+
			"_V2=g.V('"+typeof(Artifact).Name+"Id',_TP7)[0].next();"+
			"g.addEdge(_V1,_V2,_TP8);"+
			"_V3=g.V('"+typeof(Artifact).Name+"Id',_TP9)[0].next();"+
			"g.addEdge(_V1,_V3,_TP10);"+
			"_V4=g.V('"+typeof(FactorAssertion).Name+"Id',_TP11)[0].next();"+
			"g.addEdge(_V1,_V4,_TP12);"+
			"_V5=g.V('"+typeof(Member).Name+"Id',_TP13)[0].next();"+
			"g.addEdge(_V5,_V1,_TP14);";

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
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", (int)NodeFabType.Factor);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", vPrimArtId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP8",
				typeof(FactorUsesPrimaryArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP9", vRelArtId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP10",
				typeof(FactorUsesRelatedArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP11", vAssertId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP12",
				typeof(FactorUsesFactorAssertion).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP13", mem.MemberId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP14", typeof(MemberCreatesFactor).Name);
		}

	}

}