using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetDescriptorMatch : TModifyTasks {

		private static readonly string QueryStart = 
			"_V0=[];"+
			"_V1=[];"+
			"g.V('FabType',_TP)"+
				".as('step1')"+
			".outE('"+typeof(DescriptorUsesDescriptorType).Name+"').inV"+
				".has('"+typeof(DescriptorType).Name+"Id',Tokens.T.eq,_TP)"+
			".back('step1')";

		private const string QueryMid = 
				".dedup"+
				".aggregate(_V0)"+
				".iterate();";

		private const string QueryEnd = 
			"g.V('FabType',_TP)"+
				".retain(_V0)"+
				".except(_V1);";

		private static readonly string QueryPrimRef = 
			".outE('"+typeof(DescriptorRefinesPrimaryWithArtifact).Name+"')"+
				".inV.has('"+typeof(Artifact).Name+"Id',Tokens.T.eq,_TP)"+
			".back('step1')";

		private static readonly string QueryRelRef = 
			".outE('"+typeof(DescriptorRefinesRelatedWithArtifact).Name+"')"+
				".inV.has('"+typeof(Artifact).Name+"Id',Tokens.T.eq,_TP)"+
			".back('step1')";

		private static readonly string QueryTypeRef = 
			".outE('"+typeof(DescriptorRefinesTypeWithArtifact).Name+"')"+
				".inV.has('"+typeof(Artifact).Name+"Id',Tokens.T.eq,_TP)"+
			".back('step1')";

		private static readonly string QueryPrimRefNull = 
			"g.V('FabType',_TP)"+
				".retain(_V0)"+
				".as('step2')"+
			".outE('"+typeof(DescriptorRefinesPrimaryWithArtifact).Name+"')"+
			".back('step2')"+
				".aggregate(_V1)"+
				".iterate();";

		private static readonly string QueryRelRefNull = 
			"g.V('FabType',_TP)"+
				".retain(_V0)"+
				".as('step2')"+
			".outE('"+typeof(DescriptorRefinesRelatedWithArtifact).Name+"')"+
			".back('step2')"+
				".aggregate(_V1)"+
				".iterate();";

		private static readonly string QueryTypeRefNull = 
			"g.V('FabType',_TP)"+
				".retain(_V0)"+
				".as('step2')"+
			".outE('"+typeof(DescriptorRefinesTypeWithArtifact).Name+"')"+
			".back('step2')"+
				".aggregate(_V1)"+
				".iterate();";

		private long vDescTypeId;
		private long? vPrimArtRefId;
		private long? vRelArtRefId;
		private long? vDescTypeRefId;
		private Descriptor vDescriptorResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vDescTypeId = 9;
			vPrimArtRefId = 14365126;
			vRelArtRefId = 2575275;
			vDescTypeRefId = 1373546;
			vDescriptorResult = new Descriptor();

			MockApiCtx
				.Setup(x => x.DbSingle<Descriptor>("GetDescriptorMatch",
					It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => GetDescriptorMatch(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Descriptor GetDescriptorMatch(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			UsageMap.Increment("GetDescriptorMatch");

			string expect = QueryStart;

			var vals = new List<object>();
			vals.Add((int)NodeFabType.Descriptor);
			vals.Add(vDescTypeId);

			if ( vPrimArtRefId != null ) {
				expect += QueryPrimRef;
				vals.Add(vPrimArtRefId);
			}

			if ( vRelArtRefId != null ) {
				expect += QueryRelRef;
				vals.Add(vRelArtRefId);
			}

			if ( vDescTypeRefId != null ) {
				expect += QueryTypeRef;
				vals.Add(vDescTypeRefId);
			}

			expect += QueryMid;

			if ( vPrimArtRefId == null ) {
				expect += QueryPrimRefNull;
				vals.Add((int)NodeFabType.Descriptor);
			}

			if ( vRelArtRefId == null ) {
				expect += QueryRelRefNull;
				vals.Add((int)NodeFabType.Descriptor);
			}

			if ( vDescTypeRefId == null ) {
				expect += QueryTypeRefNull;
				vals.Add((int)NodeFabType.Descriptor);
			}

			vals.Add((int)NodeFabType.Descriptor);

			expect = TestUtil.InsertParamIndexes(expect+QueryEnd, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParams(pTx.Params, "_TP", vals);

			return vDescriptorResult;
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
		public void Success(long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId) {
			vPrimArtRefId = pPrimArtRefId;
			vRelArtRefId = pRelArtRefId;
			vDescTypeRefId = pDescTypeRefId;

			Descriptor result = Tasks.GetDescriptorMatch(MockApiCtx.Object, vDescTypeId, vPrimArtRefId,
				vRelArtRefId, vDescTypeRefId);

			UsageMap.AssertUses("GetDescriptorMatch", 1);
			Assert.AreEqual(vDescriptorResult, result, "Incorrect Result.");
		}

	}

}