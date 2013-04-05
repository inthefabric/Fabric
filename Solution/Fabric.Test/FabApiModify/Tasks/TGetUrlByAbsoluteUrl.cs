using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetUrlByAbsoluteUrl : TModifyTasks {

		private readonly static string Query =
			"g.V('FabType',_P0)"+
				".filter{it.getProperty('AbsoluteUrl').toLowerCase()==_P1};";

		private string vAbsoluteUrl;
		private Url vUrlResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAbsoluteUrl = "http://www.duplicate.com";
			vUrlResult = new Url();

			MockApiCtx
				.Setup(x => x.DbSingle<Url>("GetUrlByAbsoluteUrl", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetUrl(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Url GetUrl(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetUrlByAbsoluteUrl");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", (int)NodeFabType.Url);
			TestUtil.CheckParam(pQuery.Params, "_P1", vAbsoluteUrl.ToLower());

			return vUrlResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Url result = Tasks.GetUrlByAbsoluteUrl(MockApiCtx.Object, vAbsoluteUrl);

			UsageMap.AssertUses("GetUrlByAbsoluteUrl", 1);
			Assert.AreEqual(vUrlResult, result, "Incorrect Result.");
		}

	}

}