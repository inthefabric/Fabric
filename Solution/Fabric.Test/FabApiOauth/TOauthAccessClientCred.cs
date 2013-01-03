using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Results;
using NUnit.Framework;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthAccessClientCred : TOauthAccess {

		private string vClientId;
		private long vClientIdLong;

		private DomainResult vDomainResult;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			base.SetUp();
			vUserId = null;
			vClientIdLong = vAppId;
			vClientId = vClientIdLong+"";

			vDomainResult = new DomainResult();

			vMockTasks
				.Setup(x => x.GetDomain(vClientIdLong, vRedirUri, vMockCtx.Object))
				.Returns(vDomainResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string GrantType { get { return "client_credentials"; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			InnerTestGo();
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess InnerTestGo() {
			var func = new OauthAccessClientCred(
				vGrantType, vRedirUri, vClientSecret, vClientId, vMockTasks.Object);
			return func.Go(vMockCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			FabOauthAccess result = InnerTestGo();
			Assert.AreEqual(vAccessResult, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase("x")]
		[TestCase("0")]
		[TestCase("-1")]
		public void ErrClientId(string pClientId) {
			vClientId = pClientId;
			CheckOauthEx(TestGo, AccessErrors.invalid_client, AccessErrorDescs.NoClientId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("invalid")]
		[TestCase("http:/asdf.com")]
		[TestCase("http::/asdf.com")]
		[TestCase("http//asdf.com")]
		public void ErrInvalidRedirectUri(string pUri) {
			vRedirUri = pUri;
			CheckOauthEx(TestGo, AccessErrors.invalid_grant, AccessErrorDescs.BadRedirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullDomain() {
			vDomainResult = null;

			vMockTasks
				.Setup(x => x.GetDomain(vClientIdLong, vRedirUri, vMockCtx.Object))
				.Returns(vDomainResult);

			CheckOauthEx(TestGo, AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
		}

	}

}