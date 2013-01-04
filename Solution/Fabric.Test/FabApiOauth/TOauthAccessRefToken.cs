using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Results;
using NUnit.Framework;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthAccessRefToken : TOauthAccess {

		private string vRefToken;

		private RefreshResult vRefreshResult;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			base.SetUp();
			vRefToken = "ABCDEFGHIJ12345678901234567890123456789012";

			Assert.NotNull(vUserId, "vUserId must not be null.");
			vRefreshResult = new RefreshResult();
			vRefreshResult.AppId = vAppId;
			vRefreshResult.UserId = (long)vUserId;

			vMockTasks
				.Setup(x => x.GetRefresh(vRefToken, vMockCtx.Object))
				.Returns(vRefreshResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string GrantType { get { return "refresh_token"; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			InnerTestGo();
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess InnerTestGo() {
			var func = new OauthAccessRefToken(
				vGrantType, vRedirUri, vClientSecret, vRefToken, vMockTasks.Object);
			return func.Go(vMockCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public virtual void Success() {
			FabOauthAccess result = InnerTestGo();
			Assert.AreEqual(vAccessResult, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		public void ErrNullRefToken(string pRefToken) {
			vRefToken = pRefToken;
			CheckOauthEx(TestGo, AccessErrors.invalid_request, AccessErrorDescs.NoRefresh);
		}

	}

}