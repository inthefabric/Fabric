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
			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
				".outE('"+typeof(RootContainsDescriptor).Name+"').inV"+
					".as('step3')"+
				".outE('"+typeof(DescriptorUsesDescriptorType).Name+"').inV"+
					".has('"+typeof(DescriptorType).Name+"Id',Tokens.T.eq,{{DescTypeId}}L)"+
				".back('step3')";

		private const string QueryMid = 
					".dedup"+
					".aggregate(_V0)"+
					".iterate();";

		private static readonly string QueryEnd = 
			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
				".outE('"+typeof(RootContainsDescriptor).Name+"').inV"+
					".retain(_V0)"+
					".except(_V1);";

		private static readonly string QueryPrimRef = 
				".outE('"+typeof(DescriptorRefinesPrimaryWithArtifact).Name+"')"+
					".inV.has('"+typeof(Artifact).Name+"Id',Tokens.T.eq,{{PrimArtRefId}}L)"+
				".back('step3')";

		private static readonly string QueryRelRef = 
				".outE('"+typeof(DescriptorRefinesRelatedWithArtifact).Name+"')"+
					".inV.has('"+typeof(Artifact).Name+"Id',Tokens.T.eq,{{RelArtRefId}}L)"+
				".back('step3')";

		private static readonly string QueryTypeRef = 
				".outE('"+typeof(DescriptorRefinesTypeWithArtifact).Name+"')"+
					".inV.has('"+typeof(Artifact).Name+"Id',Tokens.T.eq,{{TypeArtRefId}}L)"+
				".back('step3')";

		private static readonly string QueryPrimRefNull = 
			"g.V('RootId',0)[0]"+
				".outE('"+typeof(RootContainsDescriptor).Name+"').inV"+
					".retain(_V0)"+
					".as('step4')"+
				".outE('"+typeof(DescriptorRefinesPrimaryWithArtifact).Name+"')"+
				".back('step4')"+
					".aggregate(_V1)"+
					".iterate();";

		private static readonly string QueryRelRefNull = 
			"g.V('RootId',0)[0]"+
				".outE('"+typeof(RootContainsDescriptor).Name+"').inV"+
					".retain(_V0)"+
					".as('step4')"+
				".outE('"+typeof(DescriptorRefinesRelatedWithArtifact).Name+"')"+
				".back('step4')"+
					".aggregate(_V1)"+
					".iterate();";

		private static readonly string QueryTypeRefNull = 
			"g.V('RootId',0)[0]"+
				".outE('"+typeof(RootContainsDescriptor).Name+"').inV"+
					".retain(_V0)"+
					".as('step4')"+
				".outE('"+typeof(DescriptorRefinesTypeWithArtifact).Name+"')"+
				".back('step4')"+
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
			if ( vPrimArtRefId != null ) { expect += QueryPrimRef; }
			if ( vRelArtRefId != null ) { expect += QueryRelRef; }
			if ( vDescTypeRefId != null ) { expect += QueryTypeRef; }
			expect += QueryMid;
			if ( vPrimArtRefId == null ) { expect += QueryPrimRefNull; }
			if ( vRelArtRefId == null ) { expect += QueryRelRefNull; }
			if ( vDescTypeRefId == null ) { expect += QueryTypeRefNull; }
			expect += QueryEnd;

			expect = expect
				.Replace("{{DescTypeId}}", vDescTypeId+"")
				.Replace("{{PrimArtRefId}}", vPrimArtRefId+"")
				.Replace("{{RelArtRefId}}", vRelArtRefId+"")
				.Replace("{{TypeArtRefId}}", vDescTypeRefId+"");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

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