using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetVectorMatch : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
				".outE('"+typeof(RootContainsVector).Name+"').inV"+
					".has('Value',Tokens.T.eq,{{Value}}L)"+
					".as('step4')"+
				".outE('"+typeof(VectorUsesVectorType).Name+"').inV"+
					".has('"+typeof(VectorType).Name+"Id',Tokens.T.eq,{{VecTypeId}}L)"+
				".back('step4')"+
				".outE('"+typeof(VectorUsesAxisArtifact).Name+"').inV"+
					".has('"+typeof(Artifact).Name+"Id',Tokens.T.eq,{{AxisArtId}}L)"+
				".back('step4')"+
				".outE('"+typeof(VectorUsesVectorUnit).Name+"').inV"+
					".has('"+typeof(VectorUnit).Name+"Id',Tokens.T.eq,{{VecUnitId}}L)"+
				".back('step4')"+
				".outE('"+typeof(VectorUsesVectorUnitPrefix).Name+"').inV"+
					".has('"+typeof(VectorUnitPrefix).Name+"Id',Tokens.T.eq,{{VecUnitPrefId}}L)"+
				".back('step4');";

		private long vVecTypeId;
		private long vValue;
		private long vAxisArtId;
		private long vVecUnitId;
		private long vVecUnitPrefId;
		private Vector vVectorResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vVecTypeId = 9;
			vValue = 987654;
			vAxisArtId = 123525;
			vVecUnitId = 5325235;
			vVecUnitPrefId = 32525;
			vVectorResult = new Vector();

			MockApiCtx
				.Setup(x => x.DbSingle<Vector>("GetVectorMatch", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetVectorMatch(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Vector GetVectorMatch(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetVectorMatch");

			string expect = Query
				.Replace("{{VecTypeId}}", vVecTypeId+"")
				.Replace("{{Value}}", vValue+"")
				.Replace("{{AxisArtId}}", vAxisArtId+"")
				.Replace("{{VecUnitId}}", vVecUnitId+"")
				.Replace("{{VecUnitPrefId}}", vVecUnitPrefId+"");
			
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			return vVectorResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Vector result = Tasks.GetVectorMatch(MockApiCtx.Object,
				vVecTypeId, vValue, vAxisArtId, vVecUnitId, vVecUnitPrefId);

			UsageMap.AssertUses("GetVectorMatch", 1);
			Assert.AreEqual(vVectorResult, result, "Incorrect Result.");
		}

	}

}