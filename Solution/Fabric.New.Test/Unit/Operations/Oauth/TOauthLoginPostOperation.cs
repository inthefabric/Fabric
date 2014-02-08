using Fabric.New.Domain;
using Fabric.New.Operations;
using Fabric.New.Operations.Create;
using Fabric.New.Operations.Oauth;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthLoginPostOperation {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;
		private Mock<IOauthLoginTasks> vMockTasks;

		private string vClientId;
		private string vRedirUri;
		private string vUsername;
		private string vPassword;
		private bool vAllowScope;
		private OauthLoginPostOperation vOper;
		private OauthLoginResult vExecuteResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockData = new Mock<IOperationData>();

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vMockTasks = new Mock<IOauthLoginTasks>(MockBehavior.Strict);

			vClientId = "12345";
			vRedirUri = "http://redirect.to.this.com/test";
			vUsername = "myUsername";
			vPassword = "myPassword";
			vAllowScope = true;
			vOper = new OauthLoginPostOperation();
		}

		/*--------------------------------------------------------------------------------------------*/
		private App SetupAppTasks() {
			var app = new App();
			app.VertexId = 12345;

			vMockTasks
				.Setup(x => x.AppIdToLong(vClientId))
				.Returns(app.VertexId);

			vMockTasks
				.Setup(x => x.GetApp(vMockData.Object, app.VertexId))
				.Returns(app);

			vMockTasks
				.Setup(x => x.VerifyAppDomain(app, vRedirUri));

			return app;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void DoExecuteLogin() {
			vExecuteResult = vOper.ExecuteLogin(vMockOpCtx.Object, vMockTasks.Object,
				vClientId, vRedirUri, vUsername, vPassword);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void DoExecuteScope() {
			vExecuteResult = vOper.ExecuteScope(vMockOpCtx.Object, vMockTasks.Object,
				vClientId, vRedirUri, vAllowScope);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AssertFault(TestDelegate pExecute, LoginErrors pError, LoginErrorDescs pDesc) {
			var oe = new OauthException(null, null);

			vMockTasks
				.Setup(x => x.NewFault(pError, pDesc))
				.Returns(oe);

			OauthException thrown = TestUtil.Throws<OauthException>(pExecute);
			Assert.AreEqual(oe, thrown, "Incorrect thrown OauthException.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		public void LoginErrNoRedirUri(string pUri) {
			vRedirUri = pUri;
			AssertFault(DoExecuteLogin, LoginErrors.invalid_request, LoginErrorDescs.NoRedirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LoginIncorrectCredentials() {
			SetupAppTasks();

			vMockTasks
				.Setup(x => x.GetUserByCredentials(vMockData.Object, vUsername, vPassword))
				.Returns((User)null);

			DoExecuteLogin();

			Assert.NotNull(vExecuteResult, "Result should be filled.");
			Assert.True(vExecuteResult.ShowLoginPage, "Incorrect ShowLoginPage.");
			TestUtil.AssertContains("LoginErrorText", vExecuteResult.LoginErrorText, "incorrect.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false, false)]
		[TestCase(false, true)]
		[TestCase(true, false)]
		[TestCase(true, true)]
		public void LoginSuccess(bool pMemberExists, bool pScopeAllow) {
			App app = SetupAppTasks();

			var user = new User();
			user.VertexId = 9876;
			user.Name = "TestUser";

			var mem = new Member();
			mem.OauthGrantCode = "thisismycodestring";
			mem.OauthScopeAllow = pScopeAllow;

			vMockTasks
				.Setup(x => x.GetUserByCredentials(vMockData.Object, vUsername, vPassword))
				.Returns(user);

			vMockTasks
				.Setup(x => x.GetMember(vMockData.Object, app.VertexId, user.VertexId))
				.Returns(pMemberExists ? mem : null);

			if ( !pMemberExists ) {
				vMockTasks
					.Setup(x => x.AddMember(vMockOpCtx.Object, It.IsAny<CreateMemberOperation>(), 
						app.VertexId, user.VertexId))
					.Returns(mem);
			}

			DoExecuteLogin();

			Assert.NotNull(vExecuteResult, "Result should be filled.");
			Assert.False(vExecuteResult.ShowLoginPage, "Incorrect ShowLoginPage.");
			Assert.Null(vExecuteResult.LoginErrorText, "LoginErrorText should be null.");
			Assert.AreEqual(user.VertexId, vExecuteResult.LoggedUserId, "Incorrect LoggedUserId.");
			Assert.AreEqual(user.Name, vExecuteResult.LoggedUserName, "Incorrect LoggedUserName.");

			if ( pScopeAllow ) {
				Assert.AreEqual(mem.OauthGrantCode, vExecuteResult.Code, "Incorrect Code.");
				Assert.AreEqual(vRedirUri, vExecuteResult.Redirect, "Incorrect Redirect.");
			}
			else {
				Assert.Null(vExecuteResult.Code, "Code should be null.");
				Assert.Null(vExecuteResult.Redirect, "Redirect should be null.");
			}

			vMockTasks.Verify(x => x.AddMember(vMockOpCtx.Object, It.IsAny<CreateMemberOperation>(),
					app.VertexId, user.VertexId),
				(pMemberExists ? Times.Never() : Times.Once()));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		public void ScopeErrNoRedirUri(string pUri) {
			vRedirUri = pUri;
			AssertFault(DoExecuteScope, LoginErrors.invalid_request, LoginErrorDescs.NoRedirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ScopeAccessDeny() {
			vAllowScope = false;

			App app = SetupAppTasks();

			const long userId = 125262346;
			var mem = new Member();

			var mockAuth = new Mock<IOperationAuth>();
			mockAuth.SetupGet(x => x.CookieUserId).Returns(userId);

			vMockOpCtx.SetupGet(x => x.Auth).Returns(mockAuth.Object);

			vMockTasks
				.Setup(x => x.GetMember(vMockData.Object, app.VertexId, userId))
				.Returns(mem);

			vMockTasks
				.Setup(x => x.DenyScope(vMockData.Object, mem));

			AssertFault(DoExecuteScope, LoginErrors.access_denied, LoginErrorDescs.AccessDeny);

			vMockTasks
				.Verify(x => x.DenyScope(vMockData.Object, mem), Times.Once);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ScopeSuccess() {
			App app = SetupAppTasks();

			const long userId = 125262346;
			var mem = new Member { OauthGrantCode = "testcode" };

			var mockAuth = new Mock<IOperationAuth>();
			mockAuth.SetupGet(x => x.CookieUserId).Returns(userId);

			vMockOpCtx.SetupGet(x => x.Auth).Returns(mockAuth.Object);

			vMockTasks
				.Setup(x => x.GetMember(vMockData.Object, app.VertexId, userId))
				.Returns(mem);

			vMockTasks
				.Setup(x => x.UpdateGrant(vMockOpCtx.Object, mem, vRedirUri));

			DoExecuteScope();

			Assert.NotNull(vExecuteResult, "Result should be filled.");
			Assert.False(vExecuteResult.ShowLoginPage, "Incorrect ShowLoginPage.");
			Assert.Null(vExecuteResult.LoginErrorText, "Incorrect LoginErrorText.");
			Assert.AreEqual(vRedirUri, vExecuteResult.Redirect, "Incorrect Redirect.");
			Assert.AreEqual(mem.OauthGrantCode, vExecuteResult.Code, "Incorrect Code.");

			vMockTasks
				.Verify(x => x.UpdateGrant(vMockOpCtx.Object, mem, vRedirUri), Times.Once);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void CancelSuccess() {
			AssertFault(() => vOper.ExecuteCancel(vMockTasks.Object),
				LoginErrors.access_denied, LoginErrorDescs.LoginCancel);
		}

	}

}