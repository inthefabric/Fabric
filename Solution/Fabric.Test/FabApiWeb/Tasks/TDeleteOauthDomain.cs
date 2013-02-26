using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TDeleteOauthDomain : TWebTasks {

		private static readonly string Query =
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0]"+
			".inE('"+typeof(OauthDomainUsesApp).Name+"').outV"+
				".has('"+typeof(OauthDomain).Name+"Id',Tokens.T.eq,{{OauthDomainId}}L)"+
				".sideEffect{g.removeVertex(it)};";

		private long vAppId;
		private long vOauthDomainId;
		private Mock<IApiDataAccess> vDataResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vOauthDomainId = 842645;

			vDataResult = new Mock<IApiDataAccess>();
			vDataResult.Setup(x => x.GetResultCount()).Returns(1);

			MockApiCtx
				.Setup(x => x.DbData("DeleteOauthDomain", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => DeleteOauthDomain(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess DeleteOauthDomain(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("DeleteOauthDomain");

			string expect = Query
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{OauthDomainId}}", vOauthDomainId+"");

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			return vDataResult.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			bool result = Tasks.DeleteOauthDomain(MockApiCtx.Object, vAppId, vOauthDomainId);

			UsageMap.AssertUses("DeleteOauthDomain", 1);
			Assert.True(result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Failure() {
			vDataResult.Setup(x => x.GetResultCount()).Returns(0);

			bool result = Tasks.DeleteOauthDomain(MockApiCtx.Object, vAppId, vOauthDomainId);

			UsageMap.AssertUses("DeleteOauthDomain", 1);
			Assert.False(result, "Incorrect Result.");
		}

	}

}