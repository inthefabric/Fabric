using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorIdentor : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Factor).Name+"Id',_P)"+
				".sideEffect{"+
					"it.setProperty('Identor_TypeId',_P);"+
					"it.setProperty('Identor_Value',_P)"+
				"};";

		private Factor vFactor;
		private byte vIdenTypeId;
		private string vValue;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vIdenTypeId = 9;
			vValue = "my unique value";

			MockApiCtx
				.Setup(x => x.DbData("UpdateFactorIdentor", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => UpdateFactorIdentor(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess UpdateFactorIdentor(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("UpdateFactorIdentor");

			string expect = TestUtil.InsertParamIndexes(Query, "_P");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			
			TestUtil.CheckParams(pQuery.Params, "_P", new object[] {
				vFactor.FactorId,
				vIdenTypeId,
				vValue
			});

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Update() {
			Tasks.UpdateFactorIdentor(MockApiCtx.Object, vFactor, vIdenTypeId, vValue);
			UsageMap.AssertUses("UpdateFactorIdentor", 1);
		}

	}

}