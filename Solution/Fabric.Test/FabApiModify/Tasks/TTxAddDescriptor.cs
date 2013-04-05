﻿using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddDescriptor : TModifyTasks {

		private static readonly string QueryStart = 
			"_V1=g.addVertex(["+
				typeof(Descriptor).Name+"Id:_TP1,"+
				"FabType:_TP2"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP3);"+
			"_V2=g.V('"+typeof(Factor).Name+"Id',_TP4)[0].next();"+
			"g.addEdge(_V2,_V1,_TP5);"+
			"_V3=g.V('"+typeof(DescriptorType).Name+"Id',_TP6)[0].next();"+
			"g.addEdge(_V1,_V3,_TP7);";

		private static readonly string QueryPrimRef = 
			"_V{{PrimV}}=g.V('"+typeof(Artifact).Name+"Id',_TP{{PrimId}})[0].next();"+
			"g.addEdge(_V1,_V{{PrimV}},_TP{{PrimTp}});";

		private static readonly string QueryRelRef = 
			"_V{{RelV}}=g.V('"+typeof(Artifact).Name+"Id',_TP{{RelId}})[0].next();"+
			"g.addEdge(_V1,_V{{RelV}},_TP{{RelTp}});";

		private static readonly string QueryTypeRef = 
			"_V{{TypeV}}=g.V('"+typeof(Artifact).Name+"Id',_TP{{TypeId}})[0].next();"+
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
			Dictionary<string, IWeaverQueryVal> txParams = TxBuild.Transaction.Params;
			int tp = 8;
			int v = 4;

			if ( vPrimArtRefId != null ) {
				expect += QueryPrimRef
					.Replace("{{PrimId}}", tp+"")
					.Replace("{{PrimV}}", v+"")
					.Replace("{{PrimTp}}", (tp+1)+"");

				TestUtil.CheckParam(txParams, "_TP"+tp, vPrimArtRefId);
				TestUtil.CheckParam(txParams, "_TP"+(tp+1), 
					typeof(DescriptorRefinesPrimaryWithArtifact).Name);
				tp += 2;
				v++;
			}

			if ( vRelArtRefId != null ) {
				expect += QueryRelRef
					.Replace("{{RelId}}", tp+"")
					.Replace("{{RelV}}", v+"")
					.Replace("{{RelTp}}", (tp+1)+"");

				TestUtil.CheckParam(txParams, "_TP"+tp, vRelArtRefId);
				TestUtil.CheckParam(txParams, "_TP"+(tp+1),
					typeof(DescriptorRefinesRelatedWithArtifact).Name);
				tp += 2;
				v++;
			}

			if ( vDescTypeRefId != null ) {
				expect += QueryTypeRef
					.Replace("{{TypeId}}", tp+"")
					.Replace("{{TypeV}}", v+"")
					.Replace("{{TypeTp}}", (tp+1)+"");

				TestUtil.CheckParam(txParams, "_TP"+tp, vDescTypeRefId);
				TestUtil.CheckParam(txParams, "_TP"+(tp+1),
					typeof(DescriptorRefinesTypeWithArtifact).Name);
			}

			expect = expect
				.Replace("{{NewDescriptorId}}", vNewDescriptorId+"")
				.Replace("{{FactorId}}", f.FactorId+"")
				.Replace("{{DescTypeId}}", vDescTypeId+"")
				.Replace("{{PrimArtRefId}}", vPrimArtRefId+"")
				.Replace("{{RelArtRefId}}", vRelArtRefId+"")
				.Replace("{{TypeArtRefId}}", vDescTypeRefId+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", 0);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vNewDescriptorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", (int)NodeFabType.Descriptor);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", f.FactorId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5",
				typeof(FactorUsesDescriptor).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", vDescTypeId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7",
				typeof(DescriptorUsesDescriptorType).Name);
		}

	}

}