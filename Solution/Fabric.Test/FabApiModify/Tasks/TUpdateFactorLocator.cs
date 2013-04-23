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
	public class TUpdateFactorLocator : TModifyTasks {

		private const string Query = 
			"g.V('"+PropDbName.Factor_FactorId+"',_P)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Locator_TypeId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Locator_ValueX+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Locator_ValueY+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Locator_ValueZ+"',_P)"+
				"};";

		private Factor vFactor;
		private byte vLocTypeId;
		private double vValueX;
		private double vValueY;
		private double vValueZ;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vLocTypeId = 9;
			vValueX = 1.34236;
			vValueY = 99.52352;
			vValueZ = 37.023983;

			MockApiCtx
				.Setup(x => x.DbData("UpdateFactorLocator", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => UpdateFactorLocator(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess UpdateFactorLocator(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("UpdateFactorLocator");

			string expect = TestUtil.InsertParamIndexes(Query, "_P");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pQuery.Params, "_P", new object[] {
				vFactor.FactorId,
				vLocTypeId,
				vValueX,
				vValueY,
				vValueZ,
			});

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Update() {
			Tasks.UpdateFactorLocator(MockApiCtx.Object, vFactor, vLocTypeId, vValueX, vValueY,vValueZ);
			UsageMap.AssertUses("UpdateFactorLocator", 1);
		}

	}

}