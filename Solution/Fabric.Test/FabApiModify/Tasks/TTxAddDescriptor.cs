﻿using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddDescriptor : TModifyTasks {

		private static readonly string QueryStart = 
			"g.V('"+typeof(Root).Name+"Id',0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+typeof(Descriptor).Name+"Id:{{NewDescriptorId}}L]);"+
			"g.addEdge(_V0,_V1,_TP0);"+
			"g.V('"+typeof(Factor).Name+"Id',{{FactorId}}L)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V2,_V1,_TP1);"+
			"g.V('"+typeof(DescriptorType).Name+"Id',{{DescTypeId}}L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,_TP2);";

		private static readonly string QueryPrimRef = 
			"g.V('"+typeof(Artifact).Name+"Id',{{PrimArtRefId}}L)[0].each{_V{{PrimV}}=g.v(it)};"+
			"g.addEdge(_V1,_V{{PrimV}},_TP{{PrimTp}});";

		private static readonly string QueryRelRef = 
			"g.V('"+typeof(Artifact).Name+"Id',{{RelArtRefId}}L)[0].each{_V{{RelV}}=g.v(it)};"+
			"g.addEdge(_V1,_V{{RelV}},_TP{{RelTp}});";

		private static readonly string QueryTypeRef = 
			"g.V('"+typeof(Artifact).Name+"Id',{{TypeArtRefId}}L)[0].each{_V{{TypeV}}=g.v(it)};"+
			"g.addEdge(_V1,_V{{TypeV}},_TP{{TypeTp}});";

		private long vDescTypeId;
		private long? vPrimArtRefId;
		private long? vRelArtRefId;
		private long? vDescTypeRefId;
		private long vNewDescriptorId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vDescTypeId = 9;
			vPrimArtRefId = 935823;
			vRelArtRefId = 25323;
			vDescTypeRefId = 5439225;
			vNewDescriptorId = 346137173314;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Descriptor>()).Returns(vNewDescriptorId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(123L, 456L, 789L)]
		[TestCase(null, 456L, 789L)]
		[TestCase(123L, null, 789L)]
		[TestCase(123L, 456L, null)]
		[TestCase(null, null, 789L)]
		[TestCase(123L, null, null)]
		[TestCase(null, 456L, null)]
		[TestCase(null, null, null)]
		public void BuildTx(long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId) {
			vPrimArtRefId = pPrimArtRefId;
			vRelArtRefId = pRelArtRefId;
			vDescTypeRefId = pDescTypeRefId;

			IWeaverVarAlias<Descriptor> elemVar;
			var f = new Factor { FactorId = 132414 };

			Tasks.TxAddDescriptor(MockApiCtx.Object, TxBuild, vDescTypeId, vPrimArtRefId, vRelArtRefId,
				vDescTypeRefId, f, out elemVar);
			FinishTx();

			Assert.NotNull(elemVar, "ElemVar should not be null.");
			Assert.AreEqual("_V1", elemVar.Name, "Incorrect ElemVar name.");

			string expect = QueryStart;
			int tp = 3;
			int v = 4;

			if ( vPrimArtRefId != null ) {
				expect += QueryPrimRef
					.Replace("{{PrimV}}", v+"")
					.Replace("{{PrimTp}}", tp+"");
				tp++;
				v++;
			}

			if ( vRelArtRefId != null ) {
				expect += QueryRelRef
					.Replace("{{RelV}}", v+"")
					.Replace("{{RelTp}}", tp+"");
				tp++;
				v++;
			}

			if ( vDescTypeRefId != null ) {
				expect += QueryTypeRef
					.Replace("{{TypeV}}", v+"")
					.Replace("{{TypeTp}}", tp+"");
			}

			expect = expect
				.Replace("{{NewDescriptorId}}", vNewDescriptorId+"")
				.Replace("{{FactorId}}", f.FactorId+"")
				.Replace("{{DescTypeId}}", vDescTypeId+"")
				.Replace("{{PrimArtRefId}}", vPrimArtRefId+"")
				.Replace("{{RelArtRefId}}", vRelArtRefId+"")
				.Replace("{{TypeArtRefId}}", vDescTypeRefId+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0",
				typeof(RootContainsDescriptor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1",
				typeof(FactorUsesDescriptor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2",
				typeof(DescriptorUsesDescriptorType).Name);

			tp = 3;

			if ( vPrimArtRefId != null ) {
				TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+tp,
					typeof(DescriptorRefinesPrimaryWithArtifact).Name);
				tp++;
			}

			if ( vRelArtRefId != null ) {
				TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+tp,
					typeof(DescriptorRefinesRelatedWithArtifact).Name);
				tp++;
			}

			if ( vDescTypeRefId != null ) {
				TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP"+tp,
					typeof(DescriptorRefinesTypeWithArtifact).Name);
			}
		}

	}

}