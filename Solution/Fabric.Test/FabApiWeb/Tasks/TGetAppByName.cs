using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetAppByName : TWebTasks {

		private const string Cont = "com.thinkaurelius.titan.core.attribute.Text.CONTAINS";

		private const string Query =
			"g.query()"+
				".has('"+PropDbName.App_Name+"',"+Cont+",_P0)"+
				".has('"+PropDbName.App_Name+"',"+Cont+",_P1)"+
				".has('"+PropDbName.App_Name+"',"+Cont+",_P2)"+
			".vertices();";

		private string vName;
		private App vAppResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Test App";

			vAppResult = new App();
			vAppResult.Name = vName;

			MockApiCtx
				.Setup(x => x.DbSingle<App>("GetAppByName", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetApp(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private App GetApp(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetAppByName");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", "My");
			TestUtil.CheckParam(pQuery.Params, "_P1", "Test");
			TestUtil.CheckParam(pQuery.Params, "_P2", "App");

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
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Failure() {
			vAppResult.Name = vName+" Extra Tokens";

			App result = Tasks.GetAppByName(MockApiCtx.Object, vName);

			UsageMap.AssertUses("GetAppByName", 1);
			Assert.Null(result, "Incorrect Result.");
		}

	}

}