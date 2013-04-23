using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetOauthDomainByDomain : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.App_AppId+"',_P0)"+
			".inE('"+RelDbName.OauthDomainUsesApp+"').outV"+
				".filter{it.getProperty('"+PropDbName.OauthDomain_Domain+"').toLowerCase()==_P1};";

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

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vAppId);
			TestUtil.CheckParam(pQuery.Params, "_P1", vDomain.ToLower());

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