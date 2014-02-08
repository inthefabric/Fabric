using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Operations.Oauth;
using Fabric.New.Operations.Oauth.Login;
using Fabric.New.Test.Integration.Shared;
using Fabric.New.Test.Unit.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Integration.Operations.Oauth.Login {

	/*================================================================================================*/
	public class XOauthLoginGetOperation : IntegrationTest {

		private OauthLoginTasks vTasks;
		private string vClientId;
		private string vRedirUri;
		private string vRespType;
		private string vSwitchMode;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			vTasks = new OauthLoginTasks();
			vClientId = ((long)SetupAppId.KinPhoGal)+"";
			vRedirUri = "http://www.zachkinstner.com/gallery/test/oauth";
			vRespType = "code";
			vSwitchMode = "0";
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthLoginResult ExecuteOperation() {
			var op = new OauthLoginGetOperation();
			return op.Execute(OpCtx, vTasks, vClientId, vRedirUri, vRespType, vSwitchMode);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void CheckException(OauthException pEx, LoginErrors pErr, LoginErrorDescs pDesc) {
			Assert.AreEqual(pErr.ToString(), pEx.OauthError.Error, "Incorrect Error.");
			Assert.AreEqual(OauthLoginTasks.ErrDescStrings[(int)pDesc], pEx.OauthError.ErrorDesc,
				"Incorrect ErrorDesc.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessLoginPage() {
			IsReadOnlyTest = true;
			vSwitchMode = "1";
			const long userId = (long)SetupUserId.Zach;
			OpCtx.Auth.SetCookieUserId(userId);

			OauthLoginResult result = ExecuteOperation();

			Assert.AreEqual(true, result.ShowLoginPage, "Incorrect Code.");
			Assert.AreEqual(userId, result.LoggedUserId, "Incorrect Redirect.");
			Assert.AreEqual("zachkinstner", result.LoggedUserName, "Incorrect Redirect.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessRedirect() {
			const long memId = (long)SetupMemberId.GalZach;
			const long userId = (long)SetupUserId.Zach;
			OpCtx.Auth.SetCookieUserId(userId);

			Member origMem = OpCtx.Data.GetVertexById<Member>(memId);
			Assert.AreEqual(true, origMem.OauthScopeAllow, "This test requires an allowed scope.");

			OauthLoginResult result = ExecuteOperation();

			OpCtx.Cache.Memory.RemoveVertex<Member>(memId);
			Member updatedMem = OpCtx.Data.GetVertexById<Member>(memId);

			Assert.AreEqual(updatedMem.OauthGrantCode, result.Code, "Incorrect Code.");
			Assert.AreEqual(updatedMem.OauthGrantRedirectUri, result.Redirect, "Incorrect Redirect.");

			Assert.AreNotEqual(origMem.OauthGrantCode, updatedMem.OauthGrantCode,
				"OauthGrantCode did not change.");
			Assert.AreNotEqual(origMem.OauthGrantRedirectUri, updatedMem.OauthGrantRedirectUri,
				"OauthGrantRedirectUri did not change.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrBadClient() {
			IsReadOnlyTest = true;
			vClientId = "999";
			OauthException e = TestUtil.Throws<OauthException>(() => ExecuteOperation());
			CheckException(e, LoginErrors.unauthorized_client, LoginErrorDescs.BadClient);
		}

	}

}