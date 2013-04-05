using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddOauthDomain : TWebTasks {

		private static readonly string Query =
			"_V1=g.addVertex(["+
				typeof(OauthDomain).Name+"Id:_TP1,"+
				"Domain:_TP2,"+
				"FabType:_TP3"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP4);"+
			"_V2=g.V('"+typeof(App).Name+"Id',_TP5)[0].next();"+
			"g.addEdge(_V1,_V2,_TP6);"+
			"_V1;";

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

			Assert.AreEqual(Query, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", 0);
			TestUtil.CheckParam(pTx.Params, "_TP1", vNewDomainId);
			TestUtil.CheckParam(pTx.Params, "_TP2", vDomain);
			TestUtil.CheckParam(pTx.Params, "_TP3", (int)NodeFabType.OauthDomain);
			TestUtil.CheckParam(pTx.Params, "_TP5", vAppId);
			TestUtil.CheckParam(pTx.Params, "_TP6", typeof(OauthDomainUsesApp).Name);

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