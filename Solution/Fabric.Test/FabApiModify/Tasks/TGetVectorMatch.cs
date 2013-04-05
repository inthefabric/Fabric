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
			"g.V('FabType',_P0)[0]"+
				".has('Value',Tokens.T.eq,_P1)"+
				".as('step4')"+
			".outE('"+typeof(VectorUsesVectorType).Name+"').inV"+
				".has('"+typeof(VectorType).Name+"Id',Tokens.T.eq,_P2)"+
			".back('step4')"+
			".outE('"+typeof(VectorUsesAxisArtifact).Name+"').inV"+
				".has('"+typeof(Artifact).Name+"Id',Tokens.T.eq,_P3)"+
			".back('step4')"+
			".outE('"+typeof(VectorUsesVectorUnit).Name+"').inV"+
				".has('"+typeof(VectorUnit).Name+"Id',Tokens.T.eq,_P4)"+
			".back('step4')"+
			".outE('"+typeof(VectorUsesVectorUnitPrefix).Name+"').inV"+
				".has('"+typeof(VectorUnitPrefix).Name+"Id',Tokens.T.eq,_P5)"+
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

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", (int)NodeFabType.Vector);
			TestUtil.CheckParam(pQuery.Params, "_P1", vValue);
			TestUtil.CheckParam(pQuery.Params, "_P2", vVecTypeId);
			TestUtil.CheckParam(pQuery.Params, "_P3", vAxisArtId);
			TestUtil.CheckParam(pQuery.Params, "_P4", vVecUnitId);
			TestUtil.CheckParam(pQuery.Params, "_P5", vVecUnitPrefId);

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