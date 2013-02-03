using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetLocatorType : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(LocatorType).Name+"Id',{{LocatorTypeId}}L)[0];";

		private long vLocatorTypeId;
		private LocatorType vLocatorTypeResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vLocatorTypeId = 3456;
			vLocatorTypeResult = new LocatorType();

			MockApiCtx
				.Setup(x => x.DbSingle<LocatorType>("GetLocatorType", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetLocatorType(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private LocatorType GetLocatorType(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetLocatorType");

			string expect = Query.Replace("{{LocatorTypeId}}", vLocatorTypeId+"");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			return vLocatorTypeResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			LocatorType result = Tasks.GetLocatorType(MockApiCtx.Object, vLocatorTypeId);

			UsageMap.AssertUses("GetLocatorType", 1);
			Assert.AreEqual(vLocatorTypeResult, result, "Incorrect Result.");
		}

	}

}