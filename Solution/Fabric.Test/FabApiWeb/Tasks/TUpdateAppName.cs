using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateAppName : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.App_Name+"',_P1);"+
				"};";

		private long vAppId;
		private string vName;
		private App vAppResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vName = "MyTestPass";
			vAppResult = new App();

			MockApiCtx
				.Setup(x => x.DbSingle<App>("UpdateAppName", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => UpdateAppName(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private App UpdateAppName(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("UpdateAppName");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vAppId);
			TestUtil.CheckParam(pQuery.Params, "_P1", vName);

			return vAppResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			App result = Tasks.UpdateAppName(MockApiCtx.Object, vAppId, vName);

			UsageMap.AssertUses("UpdateAppName", 1);
			Assert.AreEqual(vAppResult, result, "Incorrect Result.");
		}

	}

}