using Fabric.Api.Oauth;
using Moq;
using Fabric.Api.Oauth.Tasks;
using NUnit.Framework;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Results;
using System;
using Fabric.Test.Util;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthGrantLoginEntry {
	
		private string vResponseType;
		private string vSwitchMode;
		
		private Mock<IApiContext> vMockCtx;
		private Mock<IOauthGrantCore> vMockCore;
		private Mock<IOauthTasks> vMockTasks;
		private App vCoreAppResult;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vResponseType = "code";
			vSwitchMode = "0";
			
			vCoreAppResult = new App() { AppId = 15235, Name = "TestApp" };
			string coreRedirUri = "http://www.test.com/oauth";
			
			vMockCtx = new Mock<IApiContext>();
			
			vMockTasks = new Mock<IOauthTasks>();
			vMockTasks.Setup(x => x.GetDomain(vCoreAppResult.AppId, coreRedirUri, vMockCtx.Object))
				.Returns(new DomainResult());
			
			vMockCore = new Mock<IOauthGrantCore>();
			vMockCore.SetupGet(x => x.RedirectUri).Returns(coreRedirUri);
			vMockCore.SetupGet(x => x.AppId).Returns(vCoreAppResult.AppId);
			vMockCore.Setup(x => x.GetApp(vMockCtx.Object)).Returns(vCoreAppResult);
			vMockCore.Setup(x => x.GetFault(It.IsAny<GrantErrors>(), It.IsAny<GrantErrorDescs>()))
				.Returns(new OauthException("x", "y"));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthLogin TestGo() {
			var func = new OauthGrantLoginEntry(vResponseType, vSwitchMode,
				vMockCore.Object, vMockTasks.Object);
			return func.Go(vMockCtx.Object);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginScopeAllowed() {
			var scope = new LoginScopeResult();
			scope.Code = "fakeCode";
			scope.Redirect = "fakeRedir";
			
			vMockCore.Setup(x => x.GetGrantCodeIfScopeAlreadyAllowed(
				vMockTasks.Object, vMockCtx.Object)).Returns(scope);
			
			FabOauthLogin result = TestGo();
			
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(scope.Code, result.ScopeCode, "Incorrect Result.ScopeCode.");
			Assert.AreEqual(scope.Redirect, result.ScopeRedirect, "Incorrect Result.ScopeRedirect.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginScopeAllowedSwitch() {
			vSwitchMode = "1";
			
			FabOauthLogin result = TestGo();
			
			Assert.NotNull(result, "Result should be filled.");
			vMockCore.Verify(x => x.GetGrantCodeIfScopeAlreadyAllowed(
				It.IsAny<IOauthTasks>(), It.IsAny<IApiContext>()), Times.Never());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, true, true)]
		[TestCase(true, false, false)]
		[TestCase(false, true, true)]
		[TestCase(false, false, true)]
		public void LoginNoScope(bool pHasUser, bool pSwitchMode, bool pShowLogin) {
			vSwitchMode = (pSwitchMode ? "1" : "0");
			User user = null;
			
			if ( pHasUser ) {
				user = new User { UserId = 35353, Name = "TestUser" };
				vMockCore.Setup(x => x.GetUser(vMockCtx.Object)).Returns(user);
			}
			
			FabOauthLogin result = TestGo();
			
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(pShowLogin, result.ShowLoginPage, "Incorrect Result.ShowLoginPage.");
			Assert.AreEqual(vCoreAppResult.AppId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vCoreAppResult.Name, result.AppName, "Incorrect Result.AppName.");
			
			if ( pHasUser ) {
				Assert.AreEqual(user.UserId, result.LoggedUserId, "Incorrect Result.LoggedUserId.");
				Assert.AreEqual(user.Name, result.LoggedUserName, "Incorrect Result.LoggedUserName.");
			}
			else {
				Assert.AreEqual(0, result.LoggedUserId, "Incorrect Result.LoggedUserId.");
				Assert.Null(result.LoggedUserName, "Result.LoggedUserName should be null.");
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrBadRespType() {
			vResponseType = "notCode";
			TestUtil.CheckThrows<OauthException>(true, () => TestGo());
			vMockCore.Verify(x => x.GetFault(
				GrantErrors.invalid_request, GrantErrorDescs.BadRespType), Times.Once());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("-1")]
		[TestCase("2")]
		public void ErrBadSwitch(string pMode) {
			vSwitchMode = pMode;
			TestUtil.CheckThrows<OauthException>(true, () => TestGo());
			vMockCore.Verify(x => x.GetFault(
				GrantErrors.invalid_request, GrantErrorDescs.BadSwitch), Times.Once());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		public void ErrNoRedirUri(string pUri) {
			vMockCore.SetupGet(x => x.RedirectUri).Returns(pUri);
			TestUtil.CheckThrows<OauthException>(true, () => TestGo());
			vMockCore.Verify(x => x.GetFault(
				GrantErrors.invalid_request, GrantErrorDescs.NoRedirUri), Times.Once());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrBadRedirUri() {
			vMockCore.SetupGet(x => x.RedirectUri).Returns("missing:and/and/together");
			TestUtil.CheckThrows<OauthException>(true, () => TestGo());
			vMockCore.Verify(x => x.GetFault(
				GrantErrors.invalid_request, GrantErrorDescs.BadRedirUri), Times.Once());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public void ErrNoClient(long pAppId) {
			vMockCore.SetupGet(x => x.AppId).Returns(pAppId);
			TestUtil.CheckThrows<OauthException>(true, () => TestGo());
			vMockCore.Verify(x => x.GetFault(
				GrantErrors.unauthorized_client, GrantErrorDescs.NoClient), Times.Once());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrRedirMismatch() {
			vMockTasks.Setup(x => x.GetDomain(vCoreAppResult.AppId, vMockCore.Object.RedirectUri,
				vMockCtx.Object)).Returns((DomainResult)null);
				
			TestUtil.CheckThrows<OauthException>(true, () => TestGo());
			
			vMockCore.Verify(x => x.GetFault(
				GrantErrors.invalid_request, GrantErrorDescs.RedirMismatch), Times.Once());
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UnhandledException() {
			var ex = new Exception();
			vMockCore.Setup(x => x.GetApp(vMockCtx.Object)).Throws(ex);
			vMockCore.Setup(x => x.GetFaultOnException(ex)).Throws(new OauthException("x", "y"));
			TestUtil.CheckThrows<OauthException>(true, () => TestGo());
		}
		
	}

}