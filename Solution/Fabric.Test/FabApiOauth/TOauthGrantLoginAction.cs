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
	public class TOauthGrantLoginAction {
	
		private string vUsername;
		private string vPassword;
		
		private Mock<IApiContext> vMockCtx;
		private Mock<IOauthGrantCore> vMockCore;
		private Mock<IOauthTasks> vMockTasks;
		private App vCoreAppResult;
		private LoginScopeResult vCoreScopeResult;
		private User vTaskUserResult;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vUsername = "zachkinstner";
			vPassword = "testpass";
			
			vCoreAppResult = new App() { AppId = 1234, Name = "TestApp" };
			vTaskUserResult = new User() { UserId = 4325, Name = "TestUser" };
			vCoreScopeResult = new LoginScopeResult() { Code = "FakeCode123", Redirect = "Redir" };
			
			vMockCtx = new Mock<IApiContext>();
			
			vMockTasks = new Mock<IOauthTasks>();
			vMockTasks.Setup(x => x.GetUserAuth(vUsername, vPassword, vMockCtx.Object))
				.Returns(vTaskUserResult);
				
			vMockCore = new Mock<IOauthGrantCore>();
			vMockCore.Setup(x => x.GetApp(vMockCtx.Object)).Returns(vCoreAppResult);
			vMockCore.Setup(x => x.GetGrantCodeIfScopeAlreadyAllowed(
					vMockTasks.Object, vMockCtx.Object))
				.Returns(vCoreScopeResult);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthLogin TestGo() {
			var func = new OauthGrantLoginAction(
				vUsername, vPassword, vMockCore.Object, vMockTasks.Object);
			return func.Go(vMockCtx.Object);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			FabOauthLogin result = TestGo();
			
			Assert.NotNull(result, "Result should be filled.");
			Assert.Null(result.Code, "Result.Code should be null.");
			Assert.Null(result.State, "Result.State should be null.");
			Assert.Null(result.Error, "Result.Error should be null.");
			Assert.Null(result.ErrorDesc, "Result.ErrorDesc should be null.");
			
			Assert.AreEqual(false, result.ShowLoginPage, "Incorrect Result.ShowLoginPage.");
			Assert.Null(result.LoginErrorText, "Result.LoginErrorText should be null.");
			
			Assert.AreEqual(vCoreAppResult.AppId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vCoreAppResult.Name, result.AppName, "Incorrect Result.AppName.");
			Assert.AreEqual(vTaskUserResult.UserId, result.LoggedUserId,
				"Incorrect Result.LoggedUserId.");
			Assert.AreEqual(vTaskUserResult.Name, result.LoggedUserName,
				"Incorrect Result.LoggedUserName.");
			
			Assert.AreEqual(vCoreScopeResult.Redirect, result.ScopeRedirect, "Incorrect Result.ScopeRedirect.");
			Assert.AreEqual(vCoreScopeResult.Code, result.ScopeCode, "Incorrect Result.ScopeCode.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginFailure() {
			vTaskUserResult = null;
			vMockTasks.Setup(x => x.GetUserAuth(vUsername, vPassword, vMockCtx.Object))
				.Returns(vTaskUserResult);
				
			FabOauthLogin result = TestGo();
			
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(true, result.ShowLoginPage, "Incorrect Result.ShowLoginPage.");
			Assert.NotNull(result.LoginErrorText, "Result.LoginErrorText should be filled.");
			
			Assert.AreEqual(vCoreAppResult.AppId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vCoreAppResult.Name, result.AppName, "Incorrect Result.AppName.");
			Assert.AreEqual(0, result.LoggedUserId, "Incorrect Result.LoggedUserId.");
			Assert.Null(result.LoggedUserName, "Result.LoggedUserName should be null.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UnhandledException() {
			var ex = new Exception();
			vMockTasks.Setup(x => x.GetUserAuth(vUsername, vPassword, vMockCtx.Object)).Throws(ex);
			vMockCore.Setup(x => x.GetFaultOnException(ex)).Throws(new OauthException("x", "y"));
			TestUtil.CheckThrows<OauthException>(true, () => TestGo());
		}
		
	}

}