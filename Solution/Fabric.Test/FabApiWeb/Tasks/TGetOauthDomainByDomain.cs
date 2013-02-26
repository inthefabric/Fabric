using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetOauthDomainByDomain : TWebTasks {

		private readonly static string Query =
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0]"+
			".inE('"+typeof(OauthDomainUsesApp).Name+"').outV"+
				".filter{it.getProperty('Domain').toLowerCase()==DOM};";

		private long vAppId;
		private string vDomain;
		private OauthDomain vOauthDomainResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 462346;
			vDomain = "TestOauthDomain";
			vOauthDomainResult = new OauthDomain();

			MockApiCtx
				.Setup(x => x.DbSingle<OauthDomain>("GetOauthDomainByDomain", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetOauthDomain(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthDomain GetOauthDomain(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetOauthDomainByDomain");

			string expect = Query.Replace("{{AppId}}", vAppId+"");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "DOM", vDomain.ToLower());

			return vOauthDomainResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			OauthDomain result = Tasks.GetOauthDomainByDomain(MockApiCtx.Object, vAppId, vDomain);

			UsageMap.AssertUses("GetOauthDomainByDomain", 1);
			Assert.AreEqual(vOauthDomainResult, result, "Incorrect Result.");
		}

	}

}