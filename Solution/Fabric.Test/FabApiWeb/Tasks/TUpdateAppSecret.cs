using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateAppSecret : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.App_AppId+"',_P0)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.App_Secret+"',_P1)"+
				"};";

		private long vAppId;
		private string vSecret;
		private App vAppResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vSecret = "abcdefgHIJKLMNOPqrsTUVwxyz12345678";
			vAppResult = new App();

			MockApiCtx
				.Setup(x => x.DbSingle<App>("UpdateAppSecret", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => UpdateAppSecret(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private App UpdateAppSecret(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("UpdateAppSecret");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vAppId);
			TestUtil.CheckParam(pQuery.Params, "_P1", vSecret);

			return vAppResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			App result = Tasks.UpdateAppSecret(MockApiCtx.Object, vAppId, vSecret);

			UsageMap.AssertUses("UpdateAppSecret", 1);
			Assert.AreEqual(vAppResult, result, "Incorrect Result.");
		}

	}

}