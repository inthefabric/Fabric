using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Operations.Oauth;
using Fabric.New.Test.Integration.Shared;
using Fabric.New.Test.Unit.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Integration.Operations.Oauth {

	/*================================================================================================*/
	public class XOauthLoginPostOperation : IntegrationTest {

		private OauthLoginTasks vTasks;
		private string vClientId;
		private string vRedirUri;
		private string vUsername;
		private string vPassword;
		private bool vAllowScope;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			vTasks = new OauthLoginTasks();
			vClientId = ((long)SetupAppId.Bookmarker)+"";
			vRedirUri = "http://"+SetupOauth.DomBook1+"/test/oauth";
			vUsername = "zachkinstner";
			vPassword = "asdfasdf";
			vAllowScope = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthLoginResult ExecuteLogin() {
			var op = new OauthLoginPostOperation();
			return op.ExecuteLogin(OpCtx, vTasks, vClientId, vRedirUri, vUsername, vPassword);
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthLoginResult ExecuteScope() {
			var op = new OauthLoginPostOperation();
			return op.ExecuteScope(OpCtx, vTasks, vClientId, vRedirUri, vAllowScope);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessLoginInvalid() {
			IsReadOnlyTest = true;
			vUsername = "invalid";

			OauthLoginResult result = ExecuteLogin();

			Assert.AreEqual(true, result.ShowLoginPage, "Incorrect Code.");
			Assert.NotNull(result.LoginErrorText, "Incorrect LoginErrorText.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessLoginNewMember() {
			vUsername = "KinstnerPhotos";
			vPassword = "snapshot1234";

			OauthLoginResult result = ExecuteLogin();
			Assert.AreEqual(false, result.ShowLoginPage, "Incorrect Code.");
			Assert.AreEqual((long)SetupUserId.GalData, result.LoggedUserId, "Incorrect LoggedUserId.");
			Assert.AreEqual(vUsername, result.LoggedUserName, "Incorrect LoggedUserName.");

			NewVertexCount = 1;
			NewEdgeCount = 4;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessScopeDeny() {
			const long memId = (long)SetupMemberId.BookZach;
			const long userId = (long)SetupUserId.Zach;
			OpCtx.Auth.SetCookieUserId(userId);
			vAllowScope = false;

			Member origMem = XOauthLoginGetOperation.GetMember(OpCtx.Data, memId);
			Assert.AreEqual(true, origMem.OauthScopeAllow, "This test requires an allowed scope.");

			OauthException e = TestUtil.Throws<OauthException>(() => ExecuteScope());
			XOauthLoginGetOperation.CheckException(e,
				LoginErrors.access_denied, LoginErrorDescs.AccessDeny);

			Member updatedMem = XOauthLoginGetOperation.GetMember(OpCtx.Data, memId);

			Assert.AreEqual(false, updatedMem.OauthScopeAllow, "Incorrect OauthScopeAllow.");
			Assert.AreNotEqual(origMem.OauthScopeAllow, updatedMem.OauthScopeAllow,
				"OauthScopeAllow did not change.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessScopeUpdate() {
			const long memId = (long)SetupMemberId.BookZach;
			const long userId = (long)SetupUserId.Zach;
			OpCtx.Auth.SetCookieUserId(userId);

			Member origMem = XOauthLoginGetOperation.GetMember(OpCtx.Data, memId);
			Assert.AreEqual(true, origMem.OauthScopeAllow, "This test requires an allowed scope.");

			OauthLoginResult result = ExecuteScope();

			Member updatedMem = XOauthLoginGetOperation.GetMember(OpCtx.Data, memId);

			Assert.AreEqual(updatedMem.OauthGrantCode, result.Code, "Incorrect Code.");
			Assert.AreEqual(updatedMem.OauthGrantRedirectUri, result.Redirect, "Incorrect Redirect.");

			Assert.AreNotEqual(origMem.OauthGrantCode, updatedMem.OauthGrantCode,
				"OauthGrantCode did not change.");
			Assert.AreNotEqual(origMem.OauthGrantRedirectUri, updatedMem.OauthGrantRedirectUri,
				"OauthGrantRedirectUri did not change.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false)]
		[TestCase(true)]
		public void ErrBadClient(bool pLogin) {
			IsReadOnlyTest = true;
			vClientId = "999";
			OauthException e;
			
			if ( pLogin ) {
				e = TestUtil.Throws<OauthException>(() => ExecuteLogin());
			}
			else {
				e = TestUtil.Throws<OauthException>(() => ExecuteScope());
			}

			XOauthLoginGetOperation.CheckException(e,
				LoginErrors.unauthorized_client, LoginErrorDescs.BadClient);
		}

	}

}