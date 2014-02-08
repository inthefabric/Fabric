using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Operations;
using Fabric.New.Operations.Create;
using Fabric.New.Operations.Oauth;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthLoginTasks {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;

		private OauthLoginTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockData = new Mock<IOperationData>(MockBehavior.Strict);

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vTasks = new OauthLoginTasks();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AssertFault(TestDelegate pDelegate, LoginErrors pError, LoginErrorDescs pDesc) {
			OauthException oe = TestUtil.Throws<OauthException>(pDelegate);

			Assert.NotNull(oe.OauthError, "OauthError should filled.");
			Assert.AreEqual(pError+"", oe.OauthError.Error, "Invalid OauthError.Error");
			Assert.AreEqual(OauthLoginTasks.ErrDescStrings[(int)pDesc]+"",
				oe.OauthError.ErrorDesc, "Invalid OauthError.ErrorDesc");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase("abcd")]
		[TestCase("0")]
		[TestCase("-1")]
		[TestCase("987987987987987987987987")]
		public void AppIdToLongErrNoClient(string pAppId) {
			AssertFault(() => vTasks.AppIdToLong(pAppId),
				LoginErrors.unauthorized_client, LoginErrorDescs.NoClient);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("1", 1)]
		[TestCase("321654987", 321654987)]
		public void AppIdToLong(string pAppId, long pExpectId) {
			long result = vTasks.AppIdToLong(pAppId);
			Assert.AreEqual(pExpectId, result, "Incorrect result.");
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VerifyAppDomainErrBadRedirUri() {
			AssertFault(() => vTasks.VerifyAppDomain(new App(), "missing:and/and/together"),
				LoginErrors.invalid_request, LoginErrorDescs.BadRedirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase("testing.net")]
		[TestCase("testing.net|zesting.com|abcd.edu")]
		public void VerifyAppDomainErrRedirMismatch(string pDomainList) {
			const string redir = "http://testing.com";
			var app = new App { OauthDomains = pDomainList };

			AssertFault(() => vTasks.VerifyAppDomain(app, redir),
				LoginErrors.invalid_request, LoginErrorDescs.RedirMismatch);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("abc://www.TESTING.com")]
		[TestCase("http://www.TESTING.com")]
		[TestCase("ftp://TESTing.com")]
		[TestCase("http://TESTing.com/1/2/3/4")]
		public void VerifyAppDomainSuccess(string pRedirUri) {
			var app = new App { OauthDomains = "testing.net|testing.com|abcd.edu" };
			TestUtil.CheckThrows<OauthException>(false, () => vTasks.VerifyAppDomain(app, pRedirUri));
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("abc://www.TESTING.com", "TESTING.com")]
		[TestCase("http://www.TESTING.com", "TESTING.com")]
		[TestCase("http://ww.testing.com", "ww.testing.com")]
		[TestCase("http://wwww.testing.com", "wwww.testing.com")]
		[TestCase("ftp://TESTing.com/", "TESTing.com")]
		[TestCase("http://TESTing.com/1/2/3/4", "TESTing.com")]
		[TestCase("http://subdomain.TESTing.com/1/2/3/4", "subdomain.TESTing.com")]
		[TestCase("http://1.2.3.4.com/5/6/7/8", "1.2.3.4.com")]
		public void GetDomainFromRedirUri(string pRedirUri, string pExpectDomain) {
			string result = OauthLoginTasks.GetDomainFromRedirUri(pRedirUri);
			Assert.AreEqual(pExpectDomain, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAppErrBadClient() {
			const long appId = 123423;

			vMockData
				.Setup(x => x.GetVertexById<App>(appId))
				.Returns((App)null);

			AssertFault(() => vTasks.GetApp(vMockData.Object, appId),
				LoginErrors.unauthorized_client, LoginErrorDescs.BadClient);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAppSuccess() {
			var app = new App { VertexId = 13634634 };

			vMockData
				.Setup(x => x.GetVertexById<App>(app.VertexId))
				.Returns(app);

			App result = vTasks.GetApp(vMockData.Object, app.VertexId);

			Assert.AreEqual(app, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetUserSuccess() {
			var user = new User { VertexId = 68735743 };

			vMockData
				.Setup(x => x.GetVertexById<User>(user.VertexId))
				.Returns(user);

			User result = vTasks.GetUser(vMockData.Object, user.VertexId);

			Assert.AreEqual(user, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetUserByCredentialsSuccess() {
			const string username = "MyUserName";
			const string password = "MyPassword";
			var user = new User();

			const string expectScript = 
				"g.V('"+DbName.Vert.User.NameKey+"',_P)"+
					".has('"+DbName.Vert.User.Password+"',Tokens.T.eq,_P);";

			var expectParams = new List<object> {
				username.ToLower(),
				DataUtil.HashPassword(password)
			};

			vMockData
				.Setup(x => x.Get<User>(It.IsAny<IWeaverQuery>(), "OauthLogin-GetUserByCredentials"))
				.Callback((IWeaverScript q, string n) =>
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns(user);

			User result = vTasks.GetUserByCredentials(vMockData.Object, username, password);

			Assert.AreEqual(user, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetMemberSuccess() {
			const long appId = 987654;
			const long userId = 357327;
			var mem = new Member();

			const string expectScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
				".outE('"+DbName.Edge.UserDefinesMemberName+"')"+
					".has('"+DbName.Edge.UserDefinesMember.AppId+"',Tokens.T.eq,_P)"+
					".inV;";

			var expectParams = new List<object> {
				userId,
				appId
			};

			vMockData
				.Setup(x => x.Get<Member>(It.IsAny<IWeaverQuery>(), "OauthLogin-GetMember"))
				.Callback((IWeaverScript q, string n) =>
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns(mem);

			Member result = vTasks.GetMember(vMockData.Object, appId, userId);

			Assert.AreEqual(mem, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddMemberSuccess() {
			const long appId = 657465723;
			const long userId = 763462332;

			var mockAuth = new Mock<IOperationAuth>();
			mockAuth.Setup(x => x.SetFabricActiveMember());
			mockAuth.Setup(x => x.RemoveFabricActiveMember());

			vMockOpCtx.SetupGet(x => x.Auth).Returns(mockAuth.Object);

			var mem = new Member();

			var mockCreOp = new Mock<CreateMemberOperation>();
			mockCreOp
				.Setup(x => x.Execute(vMockOpCtx.Object, It.IsAny<ICreateOperationBuilder>(),
					It.IsAny<CreateOperationTasks>(), It.IsAny<CreateFabMember>()))
				.Callback((IOperationContext opCtx, ICreateOperationBuilder build,
						CreateOperationTasks tasks, CreateFabMember cre) => {
					Assert.NotNull(cre, "Create should be filled.");
					Assert.AreEqual(appId, cre.DefinedByAppId, "Incorrect DefinedByAppId.");
					Assert.AreEqual(userId, cre.DefinedByUserId, "Incorrect DefinedByUserId.");
					Assert.AreEqual((byte)MemberType.Id.Member, cre.Type, "Incorrect Type.");
				})
				.Returns(mem);

			Member result = vTasks.AddMember(vMockOpCtx.Object, mockCreOp.Object, appId, userId);

			Assert.AreEqual(mem, result, "Incorrect result.");

			mockAuth.Verify(x => x.SetFabricActiveMember(), Times.Once);
			mockAuth.Verify(x => x.RemoveFabricActiveMember(), Times.Once);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase(false)]
		[TestCase(true)]
		public void DenyScopeSuccess(bool? pInitAllow) {
			var mem = new Member();
			mem.VertexId = 452523;
			mem.OauthScopeAllow = pInitAllow;

			const string expectScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
					".sideEffect{"+
						"it.setProperty('"+DbName.Vert.Member.OauthScopeAllow+"',_P);"+
					"};";

			var expectParams = new List<object> {
				mem.VertexId,
				false
			};

			vMockData
				.Setup(x => x.Execute(It.IsAny<IWeaverQuery>(), "OauthLogin-DenyScope"))
				.Callback((IWeaverScript q, string n) =>
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns((IDataResult)null);

			vTasks.DenyScope(vMockData.Object, mem);

			Assert.AreEqual(false, mem.OauthScopeAllow, "Incorrect Member.OauthScopeAllow.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UpdateGrantSuccess() {
			const string redirUri = "http://THIS.is.a.TEST.com";
			const string code = "alsdiugalskdgj";
			const long ticks = 2309572305;
			const long expires = ticks+2*TimeSpan.TicksPerMinute;

			var mem = new Member();
			mem.VertexId = 452523;

			const string expectScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
					".sideEffect{"+
						"it.setProperty('"+DbName.Vert.Member.OauthScopeAllow+"',_P);"+
						"it.setProperty('"+DbName.Vert.Member.OauthGrantCode+"',_P);"+
						"it.setProperty('"+DbName.Vert.Member.OauthGrantExpires+"',_P);"+
						"it.setProperty('"+DbName.Vert.Member.OauthGrantRedirectUri+"',_P);"+
					"};";

			var expectParams = new List<object> {
				mem.VertexId,
				true,
				code,
				expires,
				redirUri.ToLower()
			};

			vMockData
				.Setup(x => x.Execute(It.IsAny<IWeaverQuery>(), "OauthLogin-UpdateGrant"))
				.Callback((IWeaverScript q, string n) =>
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns((IDataResult)null);

			vMockOpCtx
				.SetupGet(x => x.Code32)
				.Returns(code);

			vMockOpCtx
				.SetupGet(x => x.UtcNow)
				.Returns(new DateTime(ticks));

			vTasks.UpdateGrant(vMockOpCtx.Object, mem, redirUri);

			Assert.AreEqual(true, mem.OauthScopeAllow, "Incorrect Member.OauthScopeAllow.");
			Assert.AreEqual(code, mem.OauthGrantCode, "Incorrect Member.OauthGrantCode.");
			Assert.AreEqual(expires, mem.OauthGrantExpires, "Incorrect Member.OauthGrantExpires.");
			Assert.AreEqual(redirUri.ToLower(), mem.OauthGrantRedirectUri,
				"Incorrect Member.OauthGrantRedirectUri.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewFault() {
			OauthException oe = vTasks.NewFault(LoginErrors.invalid_request, LoginErrorDescs.NoClient);

			Assert.NotNull(oe, "Result should not be null.");
			Assert.AreEqual("invalid_request", oe.OauthError.Error, "Incorrect OauthError.Error.");
			Assert.AreEqual(OauthLoginTasks.ErrDescStrings[(int)LoginErrorDescs.NoClient],
				oe.OauthError.ErrorDesc, "Incorrect OauthError.ErrorDesc.");
		}

	}

}