using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Oauth {
	
	/*================================================================================================*/
	public class OauthGrant_LoginAction : SvcFunc<FabOauthLogin> {

		private readonly OauthGrant_Core vCore;
		private readonly string vUsername;
		private readonly string vPassword;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrant_LoginAction(string pUsername, string pPassword, string pClientId,
											string pRedirectUri) : base(AuthType.None) {
			vUsername = pUsername;
			vPassword = pPassword;

			vCore = new OauthGrant_Core(pClientId, pRedirectUri, 0);

			AddTransactionFunc(DoLoginAction);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoLoginAction(ISession pSession) {
			try {
				vCore.Context = Context;

				FabUserKey pk = new FAuthUser_Get(vUsername, vPassword).Go(Context);
				
				var result = new FabOauthLogin();
				SetResult(result);

				FabApp app = vCore.GetApp();
				result.AppId = app.Key.Id;
				result.AppName = app.Name;

				if ( pk == null ) {
					result.ShowLoginPage = true;
					result.LoginErrorText = "Login was not successful.<br/><br/>";
					return;
				}

				vCore.SetUserKeyId(pk.Id);
				result.Scope = vCore.GetGrantCodeIfScopeAlreadyAllowed();
				result.LoggedUserId = pk.Id;
				result.LoggedUserName = vCore.GetUser().Name;
			}
			catch ( FabOauthFault ) {
				throw;
			}
			catch ( Exception e ) {
				vCore.ThrowFaultOnException(e);
			}
		}

	}

}