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
	public class TUpdateFactorDirector : TModifyTasks {

		private const string Query = 
			"g.V('"+PropDbName.Factor_FactorId+"',_P)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Director_TypeId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Director_PrimaryActionId+"',_P);"+
					"it.setProperty('"+PropDbName.Factor_Director_RelatedActionId+"',_P)"+
				"};";


		private Factor vFactor;
		private byte vDirTypeId;
		private byte vPrimActId;
		private byte vRelActId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vDirTypeId = 9;
			vPrimActId = 25;
			vRelActId = 64;

			MockApiCtx
				.Setup(x => x.DbData("UpdateFactorDirector", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => UpdateFactorDirector(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess UpdateFactorDirector(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("UpdateFactorDirector");

			string expect = TestUtil.InsertParamIndexes(Query, "_P").Replace('*', '_');
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pQuery.Params, "_P", new object[] {
				vFactor.FactorId,
				vDirTypeId,
				vPrimActId,
				vRelActId
			});

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Update() {
			Tasks.UpdateFactorDirector(MockApiCtx.Object, vFactor, vDirTypeId, vPrimActId, vRelActId);
			UsageMap.AssertUses("UpdateFactorDirector", 1);
		}

	}

}