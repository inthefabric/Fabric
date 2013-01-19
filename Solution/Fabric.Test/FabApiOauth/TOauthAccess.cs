using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public abstract class TOauthAccess {

		protected string vGrantType;
		protected string vRedirUri;
		protected string vClientSecret;
		protected long vAppId;
		protected long? vUserId;

		protected Mock<IApiContext> vMockCtx;
		protected Mock<IOauthTasks> vMockTasks;
		protected FabOauthAccess vAccessResult;
		protected App vGetAppAuthResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vGrantType = GrantType;
			vClientSecret = "12345678901234567890123456789012";
			vRedirUri = "http://test.com/oauth";
			vAppId = 123;
			vUserId = 345;

			vMockCtx = new Mock<IApiContext>();
			vMockTasks = new Mock<IOauthTasks>();

			vGetAppAuthResult = new App { AppId = vAppId };

			vAccessResult = new FabOauthAccess();

			Log.Debug("MOCK: "+vAppId+", "+vClientSecret);
			vMockTasks
				.Setup(x => x.GetAppAuth(vAppId, vClientSecret, vMockCtx.Object))
				.Returns(vGetAppAuthResult);

			vMockTasks
				.Setup(x => x.AddAccess(vAppId, vUserId, 3600, false, vMockCtx.Object))
				.Returns(vAccessResult);

			vMockTasks
				.Setup(x => x.AddAccess(vAppId, null, 3600, true, vMockCtx.Object))
				.Returns(vAccessResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract string GrantType { get; }

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void TestGo();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrGrantCode() {
			vGrantType = "invalid";
			CheckOauthEx(TestGo, AccessErrors.unsupported_grant_type, AccessErrorDescs.BadGrantType);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		public void ErrClientSecret(string pSecret) {
			vClientSecret = pSecret;
			CheckOauthEx(TestGo, AccessErrors.invalid_request, AccessErrorDescs.NoClientSecret);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		public void ErrRedirectUri(string pRedirUri) {
			vRedirUri = pRedirUri;
			CheckOauthEx(TestGo, AccessErrors.invalid_request, AccessErrorDescs.NoRedirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAppAuth() {
			vGetAppAuthResult = null;

			vMockTasks
				.Setup(x => x.GetAppAuth(vAppId, vClientSecret, vMockCtx.Object))
				.Returns(vGetAppAuthResult);

			CheckOauthEx(TestGo, AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void CheckOauthEx(TestDelegate pFunc, AccessErrors pErr, AccessErrorDescs pDesc) {
			OauthException oe = TestUtil.CheckThrows<OauthException>(true, pFunc);

			Assert.NotNull(oe.OauthError, "OauthError should filled.");
			Assert.AreEqual(pErr+"", oe.OauthError.Error, "Invalid OauthError.Error");
			Assert.AreEqual(OauthAccessBase.ErrDescStrings[(int)pDesc]+"",
				oe.OauthError.ErrorDesc, "Invalid OauthError.ErrorDesc");
		}

	}

}