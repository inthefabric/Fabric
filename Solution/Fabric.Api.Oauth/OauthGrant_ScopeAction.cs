using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Oauth {
	
	/*================================================================================================*/
	public class OauthGrant_ScopeAction : SvcFunc<FabOauthLoginScope> {

		private readonly OauthGrant_Core vCore;

		private readonly bool vAllowScope;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrant_ScopeAction(bool pAllowScope, string pClientId, string pRedirectUri,
														uint pLoggedUserId) : base(AuthType.None) {
			vAllowScope = pAllowScope;
			vCore = new OauthGrant_Core(pClientId, pRedirectUri, pLoggedUserId);

			AddTransactionFunc(DoScopeAction);
			if ( !vAllowScope ) { AddTransactionFunc(DoScopeDenyAction); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() { }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoScopeAction(ISession pSession) {
			try {
				vCore.Context = Context;

				if ( !vAllowScope ) {
					new FOauthScope_Add(vCore.AppKey, vCore.UserKey, false).Go(Context);
					return;
				}

				SetResult(vCore.AddGrantCode(false));
			}
			catch ( FabOauthFault ) {
				throw;
			}
			catch ( Exception e ) {
				vCore.ThrowFaultOnException(e);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoScopeDenyAction(ISession pSession) {
			vCore.Context = Context;
			vCore.ThrowFault(GrantErrors.access_denied, GrantErrorDescs.AccessDeny);
		}

	}

}