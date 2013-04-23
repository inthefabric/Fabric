using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddOauthDomain : TWebTasks {

		private const string Query =
			"_V0=g.addVertex(["+
				PropDbName.OauthDomain_OauthDomainId+":_TP,"+
				PropDbName.OauthDomain_Domain+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
			"]);"+
			"_V1=g.V('"+PropDbName.App_AppId+"',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"_V0;";

		private long vAppId;
		private string vDomain;
		private long vNewDomainId;
		private OauthDomain vDomainResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vDomain = "testing.com";
			vNewDomainId = 874265982347;
			vDomainResult = new OauthDomain();

			MockApiCtx.Setup(x => x.GetSharpflakeId<OauthDomain>()).Returns(vNewDomainId);

			MockApiCtx
				.Setup(x => x.DbSingle<OauthDomain>("AddOauthDomain", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => AddOauthDomain(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthDomain AddOauthDomain(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			UsageMap.Increment("AddOauthDomain");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pTx.Params, "_TP", new object[] {
				vNewDomainId,
				vDomain,
				(int)NodeFabType.OauthDomain,
				vAppId,
				RelDbName.OauthDomainUsesApp
			});

			return vDomainResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			OauthDomain result = Tasks.AddOauthDomain(MockApiCtx.Object, vAppId, vDomain);

			UsageMap.AssertUses("AddOauthDomain", 1);
			Assert.AreEqual(vDomainResult, result, "Incorrect Result.");
		}

	}

}