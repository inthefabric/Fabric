using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;

namespace Fabric.New.Operations.Oauth.Grant {

	/*================================================================================================*/
	public class OauthLoginGetOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthLogin Execute(IOperationContext pOpCtx, IOauthGrantTasks pTasks,
						string pClientId, string pRedirUri, string pResponseType, string pSwitchMode) {
			if ( pResponseType != "code" ) {
				throw pTasks.NewFault(GrantErrors.invalid_request, GrantErrorDescs.BadRespType);
			}

			if ( pSwitchMode != null && pSwitchMode != "0" && pSwitchMode != "1" ) {
				throw pTasks.NewFault(GrantErrors.invalid_request, GrantErrorDescs.BadSwitch);
			}

			if ( pRedirUri == null || pRedirUri.Length <= 0 ) {
				throw pTasks.NewFault(GrantErrors.invalid_request, GrantErrorDescs.NoRedirUri);
			}

			long appId = pTasks.AppIdToLong(pClientId);
			App app = pTasks.GetApp(pOpCtx.Data, appId);
			pTasks.VerifyAppDomain(app, pRedirUri);

			Member actMem = pOpCtx.Auth.ActiveMember;
			var result = new FabOauthLogin();
			bool forceLogin = (pSwitchMode == "1");

			if ( actMem != null && actMem.OauthScopeAllow == true && !forceLogin ) {
				pTasks.UpdateGrant(pOpCtx, actMem, pRedirUri);

				result.ScopeCode = actMem.OauthGrantCode;
				result.ScopeRedirect = actMem.OauthGrantRedirectUri;
				return result;
			}

			User user = pTasks.GetUserByMember(pOpCtx.Data, actMem);

			result.ShowLoginPage = (user == null || forceLogin);
			result.AppId = appId;
			result.AppName = app.Name;
			result.LoggedUserId = (user == null ? 0 : user.VertexId);
			result.LoggedUserName = (user == null ? null : user.Name);

			return result;
		}

	}

}