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
				PropDbName.Vertex_FabType+":_TP"+""+
			"]);"+
			
			"_V1=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP"+").next();"+
			
			"_PROP=[:];"+
			"_TRY=[F_Fa:_V0,F_Df:_V0,F_Cr:_V0,F_DeT:_V0,F_DiT:_V0,F_DiP:_V0,F_DiR:_V0,F_EvT:_V0,"+
				"F_EvD:_V0,F_IdT:_V0,F_IdV:_V0,F_LoT:_V0,F_LoX:_V0,F_LoY:_V0,F_LoZ:_V0,"+
				"F_VeT:_V0,F_VeU:_V0,F_VeP:_V0,F_VeV:_V0,A_Cr:_V1];"+
			TestUtil.TryPropScript+
			"g.addEdge(_V0,_V1,_TP,_PROP);"+
			
			"_V2=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP"+").next();"+
			
			"_PROP=[:];"+
			"_TRY=[F_Fa:_V0,F_Df:_V0,F_Cr:_V0,F_DeT:_V0,F_DiT:_V0,F_DiP:_V0,F_DiR:_V0,F_EvT:_V0,"+
				"F_EvD:_V0,F_IdT:_V0,F_IdV:_V0,F_LoT:_V0,F_LoX:_V0,F_LoY:_V0,F_LoZ:_V0,"+
				"F_VeT:_V0,F_VeU:_V0,F_VeP:_V0,F_VeV:_V0,A_Cr:_V2];"+
				TestUtil.TryPropScript+
			"g.addEdge(_V0,_V2,_TP,_PROP);"+
			
			"_V3=g.V('"+PropDbName.Member_MemberId+"',_TP"+").next();"+
			
			"_PROP=[:];"+
			"_TRY=[F_Fa:_V0,F_Df:_V0,F_Cr:_V0,F_DeT:_V0,F_DiT:_V0,F_DiP:_V0,F_DiR:_V0,F_EvT:_V0,"+
				"F_EvD:_V0,F_IdT:_V0,F_IdV:_V0,F_LoT:_V0,F_LoX:_V0,F_LoY:_V0,F_LoZ:_V0,"+
				"F_VeT:_V0,F_VeU:_V0,F_VeP:_V0,F_VeV:_V0];"+
			TestUtil.TryPropScript+
			"g.addEdge(_V3,_V0,_TP,_PROP);";

		private long vPrimArtId;
		private long vEdgeArtId;
		private byte vAssertId;
		private bool vIsDefining;
		private string vNote;
		private DateTime vUtcNow;
		private long vNewFactorId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vPrimArtId = 1251253;
			vEdgeArtId = 64362346;
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

			Tasks.TxAddFactor(MockApiCtx.Object, TxBuild, vPrimArtId, vEdgeArtId, vAssertId, vIsDefining,
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
				(byte)VertexFabType.Factor,
				vPrimArtId,
				EdgeDbName.FactorUsesPrimaryArtifact,
				vEdgeArtId,
				EdgeDbName.FactorUsesRelatedArtifact,
				mem.MemberId,
				EdgeDbName.MemberCreatesFactor
			});
		}

	}

}