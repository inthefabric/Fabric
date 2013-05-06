using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetDomain {

		private const string QueryGetDomain =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
			".inE('"+RelDbName.OauthDomainUsesApp+"').outV"+
				".filter{it.getProperty('"+PropDbName.OauthDomain_Domain+"').toLowerCase()==_P1};";

		private long vAppId;
		private string vRedirUri;
		private string vRedirDomain;
		private Mock<IApiContext> vMockCtx;
		private OauthDomain vGetDomainResult;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vAppId = 123;
			vRedirDomain = "TeST.com";
			vRedirUri = "http://www."+vRedirDomain+"/redir";
			vUsageMap = new UsageMap();

			vGetDomainResult = new OauthDomain();
			vGetDomainResult.Domain = vRedirDomain;

			vMockCtx = new Mock<IApiContext>();

			vMockCtx
				.Setup(x => x.DbSingle<OauthDomain>(
					GetDomain.Query.GetOauthDomain+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetOauthDomain(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private DomainResult TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetDomain(vAppId, vRedirUri, vMockCtx.Object);
			}

			var task = new GetDomain(vAppId, vRedirUri);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthDomain GetOauthDomain(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			vUsageMap.Increment(GetDomain.Query.GetOauthDomain+"");

			Assert.AreEqual(QueryGetDomain, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vAppId);
			TestUtil.CheckParam(pQuery.Params, "_P1", vRedirDomain.ToLower());

			return vGetDomainResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			DomainResult result = TestGo(pViaTask);

			vUsageMap.AssertUses(GetDomain.Query.GetOauthDomain+"", 1);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vRedirDomain.ToLower(), result.Domain, "Incorrect Result.Domain.");
			Assert.AreEqual(vAppId, result.AppId, "Incorrect Result.AppId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			vGetDomainResult = null;

			DomainResult result = TestGo();

			vUsageMap.AssertUses(GetDomain.Query.GetOauthDomain+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("http://test.com", "test.com")]
		[TestCase("http://www.test.com", "test.com")]
		[TestCase("http://www.test.abcd.what.net", "test.abcd.what.net")]
		[TestCase("http://w3.test.abcd.what.net/test", "w3.test.abcd.what.net")]
		[TestCase("https://test.com/1/2/3/4", "test.com")]
		[TestCase("xyz://test.com/nothin", "test.com")]
		[TestCase("a://a.ru", "a.ru")]
		public void ValidRedirUri(string pRedirUri, string pRedirDom) {
			vRedirUri = pRedirUri;
			vRedirDomain = pRedirDom;

			DomainResult result = TestGo();

			vUsageMap.AssertUses(GetDomain.Query.GetOauthDomain+"", 1);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vRedirDomain, result.Domain, "Incorrect Result.Domain.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullRedirUri() {
			vRedirUri = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test.com")]
		[TestCase("www.test.com")]
		[TestCase("http:/test.com")]
		[TestCase("http//test.com")]
		[TestCase("http://www.t'est.com")]
		public void ErrInvalidRedirUri(string pRedirUri) {
			vRedirUri = pRedirUri;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}