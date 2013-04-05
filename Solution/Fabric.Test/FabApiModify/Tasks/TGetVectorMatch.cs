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
			"g.V('FabType',_P)"+
				".has('Value',Tokens.T.eq,_P)"+
				".as('step2')"+
			".outE('"+typeof(VectorUsesVectorType).Name+"').inV"+
				".has('"+typeof(VectorType).Name+"Id',Tokens.T.eq,_P)"+
			".back('step2')"+
			".outE('"+typeof(VectorUsesAxisArtifact).Name+"').inV"+
				".has('"+typeof(Artifact).Name+"Id',Tokens.T.eq,_P)"+
			".back('step2')"+
			".outE('"+typeof(VectorUsesVectorUnit).Name+"').inV"+
				".has('"+typeof(VectorUnit).Name+"Id',Tokens.T.eq,_P)"+
			".back('step2')"+
			".outE('"+typeof(VectorUsesVectorUnitPrefix).Name+"').inV"+
				".has('"+typeof(VectorUnitPrefix).Name+"Id',Tokens.T.eq,_P)"+
			".back('step2');";

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

			string expect = TestUtil.InsertParamIndexes(Query, "_P");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pQuery.Params, "_P", new object[] {
				(int)NodeFabType.Vector,
				vValue,
				vVecTypeId,
				vAxisArtId,
				vVecUnitId,
				vVecUnitPrefId
			});

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