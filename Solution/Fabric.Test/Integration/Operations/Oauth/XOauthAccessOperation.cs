using Fabric.Api.Objects.Oauth;
using Fabric.Database.Init.Setups;
using Fabric.Operations.Oauth;
using Fabric.Test.Integration.Shared;
using Fabric.Test.Unit.Shared;
using NUnit.Framework;

namespace Fabric.Test.Integration.Operations.Oauth {

	/*================================================================================================*/
	public class XOauthAccessOperation : IntegrationTest {

		private OauthAccessTasks vTasks;
		private string vGrantType;
		private string vClientId;
		private string vSecret;
		private string vCode;
		private string vRefresh;
		private string vRedirUri;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			vTasks = new OauthAccessTasks();
			vGrantType = null; //to be set in each test
			vClientId = ((long)SetupAppId.KinPhoGal)+"";
			vSecret = SetupUsers.KinPhoGalSecret;
			vCode = SetupOauth.GrantGalZach;
			vRefresh = SetupOauth.RefreshGalZach;
			vRedirUri = "http://localhost:49316/testing";
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteOperation() {
			var op = new OauthAccessOperation();
			return op.Execute(OpCtx, vTasks, vGrantType, vClientId, vSecret, vCode, vRefresh,vRedirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckSuccess(FabOauthAccess pResult) {
			Assert.NotNull(pResult, "Result should be filled.");
			NewVertexCount = 1;
			NewEdgeCount = 2;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckException(OauthException pEx, AccessErrors pErr,AccessErrorDescs pDesc){
			Assert.AreEqual(pErr.ToString(), pEx.OauthError.Error, "Incorrect Error.");
			Assert.AreEqual(OauthAccessTasks.ErrDescStrings[(int)pDesc], pEx.OauthError.ErrorDesc,
				"Incorrect ErrorDesc.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SetAuthCodeValues() {
			vGrantType = OauthAccessOperation.GrantTypeAc;
			vClientId = null;
			vRefresh = null;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SetRefreshValues() {
			vGrantType = OauthAccessOperation.GrantTypeRt;
			vClientId = null;
			vCode = null;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SetClientValues() {
			vGrantType = OauthAccessOperation.GrantTypeCc;
			vCode = null;
			vRefresh = null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AuthCodeErrBadCode() {
			IsReadOnlyTest = true;
			SetAuthCodeValues();
			vCode = "999";
			OauthException e = TestUtil.Throws<OauthException>(() => ExecuteOperation());
			CheckException(e, AccessErrors.invalid_grant, AccessErrorDescs.BadCode);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AuthCodeErrBadClientSecret() {
			IsReadOnlyTest = true;
			SetAuthCodeValues();
			vSecret = "fail";
			OauthException e = TestUtil.Throws<OauthException>(() => ExecuteOperation());
			CheckException(e, AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AuthCodeSuccess() {
			SetAuthCodeValues();
			CheckSuccess(ExecuteOperation());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RefreshErrBadRefresh() {
			IsReadOnlyTest = true;
			SetRefreshValues();
			vRefresh = "999";
			OauthException e = TestUtil.Throws<OauthException>(() => ExecuteOperation());
			CheckException(e, AccessErrors.invalid_request, AccessErrorDescs.BadRefresh);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RefreshErrBadClientSecret() {
			IsReadOnlyTest = true;
			SetRefreshValues();
			vSecret = "fail";
			OauthException e = TestUtil.Throws<OauthException>(() => ExecuteOperation());
			CheckException(e, AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RefreshCodeSuccess() {
			SetRefreshValues();
			CheckSuccess(ExecuteOperation());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ClientErrBadClientSecret() {
			IsReadOnlyTest = true;
			SetClientValues();
			vSecret = "fail";
			OauthException e = TestUtil.Throws<OauthException>(() => ExecuteOperation());
			CheckException(e, AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ClientSuccess() {
			SetClientValues();
			CheckSuccess(ExecuteOperation());
		}

	}

}