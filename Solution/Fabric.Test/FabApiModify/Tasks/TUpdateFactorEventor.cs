using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorEventor : TModifyTasks {

		private const string Query = 
			"g.V('"+PropDbName.Factor_FactorId+"',_P)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Eventor_TypeId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Eventor_PrecisionId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Eventor_DateTime+"',_P)"+
				"};";

		private Factor vFactor;
		private byte vEveTypeId;
		private byte vEvePrecId;
		private long vDateTime;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vEveTypeId = 9;
			vEvePrecId = 23;
			vDateTime = 253125123523;
			
			MockApiCtx
				.Setup(x => x.DbData("UpdateFactorEventor", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => UpdateFactorEventor(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess UpdateFactorEventor(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("UpdateFactorEventor");

			string expect = TestUtil.InsertParamIndexes(Query, "_P");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			
			TestUtil.CheckParams(pQuery.Params, "_P", new object[] {
				vFactor.FactorId,
				vEveTypeId,
				vEvePrecId,
				vDateTime
			});

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Update() {
			Tasks.UpdateFactorEventor(MockApiCtx.Object, vFactor, vEveTypeId, vEvePrecId, vDateTime);
			UsageMap.AssertUses("UpdateFactorEventor", 1);
		}

	}

}