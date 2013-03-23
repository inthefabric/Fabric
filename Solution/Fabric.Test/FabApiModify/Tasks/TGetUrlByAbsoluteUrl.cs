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
			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
				".outE('"+typeof(RootContainsUrl).Name+"').inV"+
				".filter{it.getProperty('AbsoluteUrl').toLowerCase()=='{{AbsUrl}}'};";

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

			string expect = Query.Replace("{{AbsUrl}}", vAbsoluteUrl);
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

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