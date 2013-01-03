using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Results;
using NUnit.Framework;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthAccessAuthCode : TOauthAccess {

		private string vCode;

		protected GrantResult vGrantResult;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			base.SetUp();
			vCode = "abcdefghijklmnopqrstuvwxyz789012";

			vGrantResult = new GrantResult();
			vGrantResult.AppId = vAppId;
			vGrantResult.UserId = vUserId;
			vGrantResult.RedirectUri = vRedirUri;

			vMockTasks
				.Setup(x => x.GetGrant(vCode, vMockCtx.Object))
				.Returns(vGrantResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string GrantType { get { return "authorization_code"; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			InnerTestGo();
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess InnerTestGo() {
			var func = new OauthAccessAuthCode(
				vGrantType, vRedirUri, vClientSecret, vCode, vMockTasks.Object);
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
		public void ErrCode(string pCode) {
			vCode = pCode;
			CheckOauthEx(TestGo, AccessErrors.invalid_request, AccessErrorDescs.NoCode);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullGrant() {
			vGrantResult = null;

			vMockTasks
				.Setup(x => x.GetGrant(vCode, vMockCtx.Object))
				.Returns(vGrantResult);

			CheckOauthEx(TestGo, AccessErrors.invalid_grant, AccessErrorDescs.BadCode);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrRedirMismatch() {
			vGrantResult.RedirectUri = "mismatch";
			CheckOauthEx(TestGo, AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
		}

	}

}