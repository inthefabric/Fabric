using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Test.Common;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetDomain : TTestBase {

		private const string QueryGetDomain =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
			".inE('"+EdgeDbName.OauthDomainUsesApp+"').outV"+
				".has('"+PropDbName.OauthDomain_Domain+"',Tokens.T.eq,_P1);";

		private long vAppId;
		private string vRedirUri;
		private string vRedirDomain;
		private OauthDomain vGetDomainResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 123;
			vRedirDomain = "TeST.com";
			vRedirUri = "http://www."+vRedirDomain+"/redir";
			
			vGetDomainResult = new OauthDomain();
			vGetDomainResult.Domain = vRedirDomain;
			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vGetDomainResult);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private DomainResult TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetDomain(vAppId, vRedirUri, MockApiCtx.Object);
			}

			var task = new GetDomain(vAppId, vRedirUri);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			Assert.AreEqual(QueryGetDomain, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vAppId);
			TestUtil.CheckParam(cmd.Params, "_P1", vRedirDomain.ToLower());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			DomainResult result = TestGo(pViaTask);

			AssertDataExecution(true);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vRedirDomain, result.Domain, "Incorrect Result.Domain.");
			Assert.AreEqual(vAppId, result.AppId, "Incorrect Result.AppId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			MockDataList[0].MockResult.SetupToElement<OauthDomain>(null);

			DomainResult result = TestGo();

			AssertDataExecution(true);
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

			AssertDataExecution(true);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vRedirDomain.ToLower(), result.Domain, "Incorrect Result.Domain.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullRedirUri() {
			vRedirUri = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			AssertDataExecution(false);
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
			AssertDataExecution(false);
		}

	}

}