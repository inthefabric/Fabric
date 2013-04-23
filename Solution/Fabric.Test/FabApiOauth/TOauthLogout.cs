using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Infrastructure.Api;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthLogout {

		private string vToken;
		private Mock<IApiContext> vMockCtx;
		private Mock<IOauthTasks> vMockTasks;
		private FabOauthAccess vGetAcc;
		private FabOauthAccess vOutAcc;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vToken = "abcdefghijklmnopqrstuvwxyz789012";

			vMockCtx = new Mock<IApiContext>();
			vMockTasks = new Mock<IOauthTasks>();
			
			vGetAcc = new FabOauthAccess();
			vOutAcc = new FabOauthAccess();
			
			vMockTasks.Setup(x => x.GetAccessToken(vToken, vMockCtx.Object)).Returns(vGetAcc);
			vMockTasks.Setup(x => x.DoLogout(vGetAcc, vMockCtx.Object)).Returns(vOutAcc);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthLogout TestGo() {
			var func = new OauthLogout(vToken, vMockTasks.Object);
			return func.Go(vMockCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			FabOauthLogout result = TestGo();
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(1, result.Success, "Incorrect Result.Success.");
			Assert.AreEqual(vToken, result.AccessToken, "Incorrect Result.AccessToken.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase("x")]
		[TestCase("1234567890123456789012345678901")]
		[TestCase("123456789012345678901234567890123")]
		public void ErrorBadToken(string pToken) {
			vToken = pToken;
			vMockTasks.Setup(x => x.GetAccessToken(pToken, vMockCtx.Object)).Returns(vGetAcc);
			CheckOauthEx(() => TestGo(), LogoutErrors.invalid_request, LogoutErrorDescs.BadToken);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorNoTokenMatch() {
			vMockTasks.Setup(x => x.GetAccessToken(vToken, vMockCtx.Object))
				.Returns((FabOauthAccess)null);
			CheckOauthEx(() => TestGo(), LogoutErrors.invalid_request, LogoutErrorDescs.NoTokenMatch);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorLogoutFailed() {
			vMockTasks.Setup(x => x.DoLogout(vGetAcc, vMockCtx.Object))
				.Returns((FabOauthAccess)null);
			CheckOauthEx(() => TestGo(), LogoutErrors.logout_failure, LogoutErrorDescs.LogoutFailed);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void CheckOauthEx(TestDelegate pFunc, LogoutErrors pErr, LogoutErrorDescs pDesc) {
			OauthException oe = TestUtil.CheckThrows<OauthException>(true, pFunc);

			Assert.NotNull(oe.OauthError, "OauthError should filled.");
			Assert.AreEqual(pErr+"", oe.OauthError.Error, "Invalid OauthError.Error");
			Assert.AreEqual(OauthLogout.ErrDescStrings[(int)pDesc]+"",
				oe.OauthError.ErrorDesc, "Invalid OauthError.ErrorDesc");
		}

	}

}