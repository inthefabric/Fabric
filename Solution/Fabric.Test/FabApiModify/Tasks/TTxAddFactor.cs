using System;
using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddFactor : TModifyTasks {

		private static int A = 0;
		private static readonly string Query = 
			"_V0=g.addVertex(["+
				typeof(Factor).Name+"Id:_TP"+(A++)+","+
				"IsDefining:_TP"+(A++)+","+
				"Created:_TP"+(A++)+","+
				"Note:_TP"+(A++)+","+
				"FabType:_TP"+(A++)+""+
			"]);"+
			"_V1=g.V('"+typeof(Artifact).Name+"Id',_TP"+(A++)+")[0].next();"+
			"g.addEdge(_V0,_V1,_TP"+(A++)+");"+
			"_V2=g.V('"+typeof(Artifact).Name+"Id',_TP"+(A++)+")[0].next();"+
			"g.addEdge(_V0,_V2,_TP"+(A++)+");"+
			"_V3=g.V('"+typeof(FactorAssertion).Name+"Id',_TP"+(A++)+")[0].next();"+
			"g.addEdge(_V0,_V3,_TP"+(A++)+");"+
			"_V4=g.V('"+typeof(Member).Name+"Id',_TP"+(A++)+")[0].next();"+
			"g.addEdge(_V4,_V0,_TP"+(A++)+");";

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
			Assert.AreEqual("_V0", factorVar.Name, "Incorrect FactorVar name.");

			int i = 0;

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++), vNewFactorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++), true);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++), vUtcNow.Ticks);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++), vNote);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++), (int)NodeFabType.Factor);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++), vPrimArtId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++),
				typeof(FactorUsesPrimaryArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++), vRelArtId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++),
				typeof(FactorUsesRelatedArtifact).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++), vAssertId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++),
				typeof(FactorUsesFactorAssertion).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+(i++), mem.MemberId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+i, typeof(MemberCreatesFactor).Name);
		}

	}

}