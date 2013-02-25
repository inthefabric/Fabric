using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetApp : TWebTasks {

		private static readonly string Query =
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0];";

		private long vAppId;
		private App vAppResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vAppResult = new App();

			MockApiCtx
				.Setup(x => x.DbSingle<App>("GetApp", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetApp(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private App GetApp(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetApp");

			string expect = Query.Replace("{{AppId}}", vAppId+"");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			return vAppResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			App result = Tasks.GetApp(MockApiCtx.Object, vAppId);

			UsageMap.AssertUses("GetApp", 1);
			Assert.AreEqual(vAppResult, result, "Incorrect Result.");
		}

	}

}