using Fabric.New.Domain;
using Fabric.New.Operations;
using Fabric.New.Operations.Oauth;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthLoginGetOperation {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;
		private Mock<IOauthLoginTasks> vMockTasks;

		private string vClientId;
		private string vRedirUri;
		private string vRespType;
		private string vSwitchMode;
		private OauthLoginGetOperation vOper;
		private OauthLoginResult vExecuteResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockData = new Mock<IOperationData>(MockBehavior.Strict);

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vMockTasks = new Mock<IOauthLoginTasks>(MockBehavior.Strict);

			vClientId = "12345";
			vRedirUri = "http://redirect.to.this.com/test";
			vRespType = "code";
			vSwitchMode = "0";
			vOper = new OauthLoginGetOperation();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void DoExecute() {
			vExecuteResult = vOper.Execute(vMockOpCtx.Object, vMockTasks.Object,
				vClientId, vRedirUri, vRespType, vSwitchMode);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AssertFault(LoginErrors pError, LoginErrorDescs pDesc) {
			var oe = new OauthException(null, null);

			vMockTasks
				.Setup(x => x.NewFault(pError, pDesc))
				.Returns(oe);

			OauthException thrown = TestUtil.Throws<OauthException>(DoExecute);
			Assert.AreEqual(oe, thrown, "Incorrect thrown OauthException.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrBadRespType() {
			vRespType = "invalid";
			AssertFault(LoginErrors.invalid_request, LoginErrorDescs.BadRespType);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("-1")]
		[TestCase("2")]
		public void ErrBadSwitch(string pMode) {
			vSwitchMode = pMode;
			AssertFault(LoginErrors.invalid_request, LoginErrorDescs.BadSwitch);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		public void ErrNoRedirUri(string pUri) {
			vRedirUri = pUri;
			AssertFault(LoginErrors.invalid_request, LoginErrorDescs.NoRedirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null, false, "0", true)]
		[TestCase(null, false, "1", true)]
		[TestCase(987L, false, "0", false)]
		[TestCase(987L, false, "1", true)]
		[TestCase(987L, true, "1", true)]
		public void Success(long? pUserId, bool pScopeAllow, string pSwitchMode, bool pExpectShow) {
			vSwitchMode = pSwitchMode;

			const long appId = 12345;
			var app = new App { Name = "testName" };
			User user = null;
			var mockAuth = new Mock<IOperationAuth>(MockBehavior.Strict);

			vMockTasks
				.Setup(x => x.AppIdToLong(vClientId))
				.Returns(appId);

			vMockTasks
				.Setup(x => x.GetApp(vMockData.Object, appId))
				.Returns(app);

			vMockTasks
				.Setup(x => x.VerifyAppDomain(app, vRedirUri));

			mockAuth
				.SetupGet(x => x.CookieUserId).Returns(pUserId);

			vMockOpCtx
				.SetupGet(x => x.Auth)
				.Returns(mockAuth.Object);

			if ( pUserId != null ) {
				var mem = new Member { OauthScopeAllow = pScopeAllow };
				
				user = new User();
				user.VertexId = 235235;
				user.Name = "testName";

				vMockTasks
					.Setup(x => x.GetMember(vMockData.Object, appId, (long)pUserId))
					.Returns(mem);

				vMockTasks
					.Setup(x => x.GetUser(vMockData.Object, (long)pUserId))
					.Returns(user);
			}

			DoExecute();

			Assert.NotNull(vExecuteResult, "Result should be filled.");
			Assert.Null(vExecuteResult.Code, "Code should be null.");
			Assert.Null(vExecuteResult.Redirect, "Redirect should be null.");
			Assert.AreEqual(pExpectShow, vExecuteResult.ShowLoginPage, "Incorrect ShowLoginPage.");
			Assert.AreEqual(appId, vExecuteResult.AppId, "Incorrect AppId.");
			Assert.AreEqual(app.Name, vExecuteResult.AppName, "Incorrect AppName.");

			if ( pUserId == null ) {
				Assert.AreEqual(0, vExecuteResult.LoggedUserId, "Incorrect LoggedUserId.");
				Assert.Null(vExecuteResult.LoggedUserName, "LoggedUserName should be null.");
			}
			else {
				Assert.AreEqual(user.VertexId, vExecuteResult.LoggedUserId, "Incorrect LoggedUserId.");
				Assert.AreEqual(user.Name, vExecuteResult.LoggedUserName, "Incorrect LoggedUserName.");
			}

			vMockTasks.Verify(x => 
				x.UpdateGrant(vMockOpCtx.Object, It.IsAny<Member>(), vRedirUri), Times.Never);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessScope() {
			const long appId = 12345;
			const long userId = 74578457;

			var app = new App();
			var mockAuth = new Mock<IOperationAuth>(MockBehavior.Strict);

			var mem = new Member();
			mem.OauthScopeAllow = true;
			mem.OauthGrantCode = "sdfasgasdgasd";
			mem.OauthGrantRedirectUri = "ejejefufuufd";

			vMockTasks
				.Setup(x => x.AppIdToLong(vClientId))
				.Returns(appId);

			vMockTasks
				.Setup(x => x.GetApp(vMockData.Object, appId))
				.Returns(app);

			vMockTasks
				.Setup(x => x.VerifyAppDomain(app, vRedirUri));

			mockAuth
				.SetupGet(x => x.CookieUserId).Returns(userId);

			vMockOpCtx
				.SetupGet(x => x.Auth)
				.Returns(mockAuth.Object);

			vMockTasks
				.Setup(x => x.GetMember(vMockData.Object, appId, userId))
				.Returns(mem);

			vMockTasks
				.Setup(x => x.UpdateGrant(vMockOpCtx.Object, mem, vRedirUri));

			DoExecute();

			Assert.NotNull(vExecuteResult, "Result should be filled.");
			Assert.False(vExecuteResult.ShowLoginPage, "Incorrect ShowLoginPage.");
			Assert.AreEqual(mem.OauthGrantCode, vExecuteResult.Code, "Incorrect Code.");
			Assert.AreEqual(mem.OauthGrantRedirectUri, vExecuteResult.Redirect, "Incorrect Redirect.");

			vMockTasks.Verify(x => x.UpdateGrant(vMockOpCtx.Object, mem, vRedirUri), Times.Once);
		}

	}

}