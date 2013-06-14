using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddFactor : TModifyTasks {

		private const string Query = 
			"_V0=g.addVertex(["+
				PropDbName.Factor_FactorId+":_TP"+","+
				PropDbName.Factor_FactorAssertionId+":_TP"+","+
				PropDbName.Factor_IsDefining+":_TP"+","+
				PropDbName.Factor_Created+":_TP"+","+
				PropDbName.Factor_Note+":_TP"+","+
				PropDbName.Node_FabType+":_TP"+""+
			"]);"+
			"_V1=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP"+").next();"+
			"g.addEdge(_V0,_V1,_TP"+");"+
			"_V2=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP"+").next();"+
			"g.addEdge(_V0,_V2,_TP"+");"+
			"_V3=g.V('"+PropDbName.Member_MemberId+"',_TP"+").next();"+
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
				(byte)NodeFabType.Factor,
				vPrimArtId,
				RelDbName.FactorUsesPrimaryArtifact,
				vRelArtId,
				RelDbName.FactorUsesRelatedArtifact,
				mem.MemberId,
				RelDbName.MemberCreatesFactor
			});
		}

	}

}