using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorVector : TModifyTasks {

		private const string Query = 
			"_V0=g.V('"+PropDbName.Factor_FactorId+"',_TP)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Vector_TypeId+"',_TP);"+
					"it.setProperty('"+PropDbName.Factor_Vector_UnitId+"',_TP);"+
					"it.setProperty('"+PropDbName.Factor_Vector_UnitPrefixId+"',_TP);"+
					"it.setProperty('"+PropDbName.Factor_Vector_Value+"',_TP)"+
				"}"+
				".next();"+
			"_V1=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);";

		private Factor vFactor;
		private byte vVecTypeId;
		private long vValue;
		private long vAxisArtId;
		private byte vVecUnitId;
		private byte vVecUnitPrefId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vVecTypeId = 9;
			vValue = 987654;
			vAxisArtId = 123525;
			vVecUnitId = 235;
			vVecUnitPrefId = 132;

			MockApiCtx
				.Setup(x => x.DbData("UpdateFactorVector", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => UpdateFactorVector(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess UpdateFactorVector(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			UsageMap.Increment("UpdateFactorVector");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pTx.Params, "_TP", new object[] {
				vFactor.FactorId,
				vVecTypeId,
				vVecUnitId,
				vVecUnitPrefId,
				vValue,
				vAxisArtId,
				RelDbName.FactorVectorUsesAxisArtifact
			});

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Update() {
			Tasks.UpdateFactorVector(MockApiCtx.Object, vFactor, vVecTypeId, vValue, vAxisArtId,
				vVecUnitId, vVecUnitPrefId);
			UsageMap.AssertUses("UpdateFactorVector", 1);
		}

	}

}