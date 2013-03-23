using System;
using Fabric.Domain;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddFactor : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(Factor).Name+"Id:{{NewFactorId}}L,"+
				"IsDefining:true,"+
				"Created:{{UtcNowTicks}}L,"+
				"Note:'{{Note}}'"+
			"]);"+
			"g.addEdge(_V0,_V1,'"+typeof(RootContainsFactor).Name+"');"+
			"g.V('"+typeof(Artifact).Name+"Id',{{PrimArtId}}L)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V1,_V2,'"+typeof(FactorUsesPrimaryArtifact).Name+"');"+
			"g.V('"+typeof(Artifact).Name+"Id',{{RelArtId}}L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,'"+typeof(FactorUsesRelatedArtifact).Name+"');"+
			"g.V('"+typeof(FactorAssertion).Name+"Id',{{AssertId}}L)[0].each{_V4=g.v(it)};"+
			"g.addEdge(_V1,_V4,'"+typeof(FactorUsesFactorAssertion).Name+"');"+
			"g.V('"+typeof(Member).Name+"Id',{{MemberId}}L)[0].each{_V5=g.v(it)};"+
			"g.addEdge(_V5,_V1,'"+typeof(MemberCreatesFactor).Name+"');";

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

			string expect = Query
				.Replace("{{NewFactorId}}", vNewFactorId+"")
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"")
				.Replace("{{PrimArtId}}", vPrimArtId+"")
				.Replace("{{RelArtId}}", vRelArtId+"")
				.Replace("{{AssertId}}", vAssertId+"")
				.Replace("{{MemberId}}", mem.MemberId+"")
				.Replace("{{Note}}", vNote);

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
		}

	}

}