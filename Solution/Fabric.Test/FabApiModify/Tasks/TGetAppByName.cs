using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetAppByName : TModifyTasks {

		private readonly static string Query =
			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
				".outE('"+typeof(RootContainsApp).Name+"').inV"+
				".filter{it.getProperty('Name').toLowerCase()==NAME};";

		private string vName;
		private App vAppResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "TestApp";
			vAppResult = new App();

			MockApiCtx
				.Setup(x => x.DbSingle<App>("GetAppByName", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetApp(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private App GetApp(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetAppByName");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "NAME", vName.ToLower());

			return vAppResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			App result = Tasks.GetAppByName(MockApiCtx.Object, vName);

			UsageMap.AssertUses("GetAppByName", 1);
			Assert.AreEqual(vAppResult, result, "Incorrect Result.");
		}

	}

}