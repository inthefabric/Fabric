using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Oauth {
	
	/*================================================================================================*/
	public class OauthGrant_LoginEntry : SvcFunc<FabOauthLogin> {

		private readonly OauthGrant_Core vCore;

		private readonly string vResponseType;
		private bool vSwitchMode;
		private readonly string vSwitchModeStr;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrant_LoginEntry(string pResponseType, string pClientId, string pRedirectUri,
									string pSwitchMode, uint pLoggedUserId) : base(AuthType.None) {
			vResponseType = pResponseType;
			vSwitchModeStr = pSwitchMode;

			vCore = new OauthGrant_Core(pClientId, pRedirectUri, pLoggedUserId);

			AddTransactionFunc(GetPageData);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vResponseType != "code" ) {
				vCore.ThrowFault(GrantErrors.invalid_request, GrantErrorDescs.BadRespType);
			}

			if ( vSwitchModeStr != null && vSwitchModeStr != "0" && vSwitchModeStr != "1" ) {
				vCore.ThrowFault(GrantErrors.invalid_request, GrantErrorDescs.BadSwitch);
			}

			vSwitchMode = (vSwitchModeStr == "1");

			// Redirect tests

			if ( vCore.RedirectUri == null || vCore.RedirectUri.Length <= 0 ) {
				vCore.ThrowFault(GrantErrors.invalid_request, GrantErrorDescs.NoRedirUri);
			}

			if ( vCore.RedirectUri.IndexOf("://") <= 0 ) {
				vCore.ThrowFault(GrantErrors.invalid_request, GrantErrorDescs.BadRedirUri);
			}

			// App tests

			if ( vCore.AppKey == null ) {
				vCore.ThrowFault(GrantErrors.unauthorized_client, GrantErrorDescs.NoClient);
			}

			// Scope tests

			/*if ( false ) {
				throwFault(GrantErrors.invalid_scope, "The scope is invalid");
				return;
			}*/
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void GetPageData(ISession pSession) {
			try {
				vCore.Context = Context;

				FabApp app = vCore.GetApp(); //throws fault on error
				CheckDomain();

				var result = new FabOauthLogin();
				SetResult(result);

				if ( !vSwitchMode ) {
					result.Scope = vCore.GetGrantCodeIfScopeAlreadyAllowed();
					if ( result.Scope != null ) { return; }
				}

				FabUser per = vCore.GetUser();

				result.ShowLoginPage = (per == null || vSwitchMode);
				result.AppId = app.Key.Id;
				result.AppName = app.Name;
				result.LoggedUserId = (per == null ? 0 : per.Key.Id);
				result.LoggedUserName = (per == null ? null : per.Name);
			}
			catch ( FabOauthFault ) {
				throw;
			}
			catch ( Exception e ) {
				vCore.ThrowFaultOnException(e);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckDomain() {
			FabOauthDomain dom = new FOauthDomain_Get(vCore.AppKey, vCore.RedirectUri).Go(Context);

			if ( dom == null ) {
				vCore.ThrowFault(GrantErrors.invalid_request, GrantErrorDescs.RedirMismatch);
			}
		}

	}

}