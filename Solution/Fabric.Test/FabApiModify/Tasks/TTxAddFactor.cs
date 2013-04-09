using System;
using Fabric.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddFactor : TModifyTasks {

		private static readonly string Query = 
			"_V0=g.addVertex(["+
				typeof(Factor).Name+"Id:_TP"+","+
				typeof(FactorAssertion).Name+"Id:_TP"+","+
				"IsDefining:_TP"+","+
				"Created:_TP"+","+
				"Note:_TP"+","+
				"FabType:_TP"+""+
			"]);"+
			"_V1=g.V('"+typeof(Artifact).Name+"Id',_TP"+").next();"+
			"g.addEdge(_V0,_V1,_TP"+");"+
			"_V2=g.V('"+typeof(Artifact).Name+"Id',_TP"+").next();"+
			"g.addEdge(_V0,_V2,_TP"+");"+
			"_V3=g.V('"+typeof(Member).Name+"Id',_TP"+").next();"+
			"g.addEdge(_V3,_V0,_TP"+");";

		private long vPrimArtId;
		private long vRelArtId;
		private byte vAssertId;
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

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewFactorId,
				vAssertId,
				true,
				vUtcNow.Ticks,
				vNote,
				(int)NodeFabType.Factor,
				vPrimArtId,
				typeof(FactorUsesPrimaryArtifact).Name,
				vRelArtId,
				typeof(FactorUsesRelatedArtifact).Name,
				mem.MemberId,
				typeof(MemberCreatesFactor).Name
			});
		}

	}

}