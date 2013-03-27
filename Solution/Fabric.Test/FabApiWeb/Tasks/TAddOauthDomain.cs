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
			"g.V('"+typeof(Root).Name+"Id',0)[0].each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+typeof(OauthDomain).Name+"Id:{{OauthDomainId}}L,Domain:_TP0]);"+
			"g.addEdge(_V0,_V1,_TP1);"+
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0].each{_V2=g.v(it)};"+
			"g.addEdge(_V1,_V2,_TP2);"+
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

			string expect = Query
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{OauthDomainId}}", vNewDomainId+"");

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", vDomain);
			TestUtil.CheckParam(pTx.Params, "_TP1", typeof(RootContainsOauthDomain).Name);
			TestUtil.CheckParam(pTx.Params, "_TP2", typeof(OauthDomainUsesApp).Name);

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