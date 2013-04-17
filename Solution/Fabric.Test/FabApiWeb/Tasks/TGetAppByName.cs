using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetAppByName : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.Node_FabType+"',_P0)"+
				".filter{"+
					"it.getProperty('"+PropDbName.App_Name+"').toLowerCase()==_P1"+
				"};";

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
			TestUtil.CheckParam(pQuery.Params, "_P0", (int)NodeFabType.App);
			TestUtil.CheckParam(pQuery.Params, "_P1", vName.ToLower());

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