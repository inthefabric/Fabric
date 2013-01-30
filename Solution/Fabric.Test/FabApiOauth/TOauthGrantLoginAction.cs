using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Moq;
using NUnit.Framework;

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
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vUsername = "zachkinstner";
			vPassword = "testpass";
			
			vCoreAppResult = new App { AppId = 1234, Name = "TestApp" };
			
			vMockCtx = new Mock<IApiContext>();
			
			vMockTasks = new Mock<IOauthTasks>();
				
			vMockCore = new Mock<IOauthGrantCore>();
			vMockCore.Setup(x => x.GetApp(vMockCtx.Object)).Returns(vCoreAppResult);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthLogin TestGo() {
			var func = new OauthGrantLoginAction(
				vUsername, vPassword, vMockCore.Object, vMockTasks.Object);
			return func.Go(vMockCtx.Object);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pAlreadyAllowedScope) {
			var user = new User { UserId = 4325, Name = "TestUser" };
			LoginScopeResult scope = null;

			vMockTasks.Setup(x => x.GetUserAuth(vUsername, vPassword, vMockCtx.Object))
				.Returns(user);

			if ( pAlreadyAllowedScope ) {
				scope = new LoginScopeResult { Code = "FakeCode123", Redirect = "Redir" };

				vMockCore.Setup(x => x.GetGrantCodeIfScopeAlreadyAllowed(
					vMockTasks.Object, vMockCtx.Object)).Returns(scope);
			}

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
			Assert.AreEqual(user.UserId, result.LoggedUserId, "Incorrect Result.LoggedUserId.");
			Assert.AreEqual(user.Name, result.LoggedUserName, "Incorrect Result.LoggedUserName.");

			if ( pAlreadyAllowedScope ) {
				Assert.AreEqual(scope.Redirect, result.ScopeRedirect, "Incorrect Result.ScopeRedirect.");
				Assert.AreEqual(scope.Code, result.ScopeCode, "Incorrect Result.ScopeCode.");
			}
			else {
				Assert.Null(result.ScopeRedirect, "Result.ScopeRedirect should be null.");
				Assert.Null(result.ScopeCode, "Result.ScopeCode should be null.");
			}

			vMockCore.Verify(x => x.SetUserId(user.UserId), Times.Once());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginFailure() {
			vMockTasks.Setup(x => x.GetUserAuth(vUsername, vPassword, vMockCtx.Object))
				.Returns((User)null);
				
			FabOauthLogin result = TestGo();
			
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(true, result.ShowLoginPage, "Incorrect Result.ShowLoginPage.");
			Assert.NotNull(result.LoginErrorText, "Result.LoginErrorText should be filled.");
			
			Assert.AreEqual(vCoreAppResult.AppId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vCoreAppResult.Name, result.AppName, "Incorrect Result.AppName.");
			Assert.AreEqual(0, result.LoggedUserId, "Incorrect Result.LoggedUserId.");
			Assert.Null(result.LoggedUserName, "Result.LoggedUserName should be null.");
		}
		
	}

}