using Fabric.New.Domain;

namespace Fabric.New.Operations.Oauth.Login {

	/*================================================================================================*/
	public class OauthLoginGetOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthLoginResult Execute(IOperationContext pOpCtx, IOauthLoginTasks pTasks,
						string pClientId, string pRedirUri, string pResponseType, string pSwitchMode) {
			/*var test = new FabOauthLogin();
			test.ShowLoginPage = false;
			test.AppId = 123;
			test.AppName = "Test App";
			test.LoggedUserId = 345;
			test.LoggedUserName = "Test User";
			test.Code = "TestCode";
			test.Redirect = "http://test.redirect.url";
			return test;*/

			if ( pResponseType != "code" ) {
				throw pTasks.NewFault(LoginErrors.invalid_request, LoginErrorDescs.BadRespType);
			}

			if ( pSwitchMode != null && pSwitchMode != "0" && pSwitchMode != "1" ) {
				throw pTasks.NewFault(LoginErrors.invalid_request, LoginErrorDescs.BadSwitch);
			}

			if ( pRedirUri == null || pRedirUri.Length <= 0 ) {
				throw pTasks.NewFault(LoginErrors.invalid_request, LoginErrorDescs.NoRedirUri);
			}

			long appId = pTasks.AppIdToLong(pClientId);
			App app = pTasks.GetApp(pOpCtx.Data, appId);
			pTasks.VerifyAppDomain(app, pRedirUri);

			var result = new OauthLoginResult();
			bool forceLogin = (pSwitchMode == "1");
			long? userId = pOpCtx.Auth.CookieUserId;

			if ( userId != null ) {
				Member mem = pTasks.GetMember(pOpCtx.Data, appId, (long)userId);

				if ( mem.OauthScopeAllow == true && !forceLogin ) {
					pTasks.UpdateGrant(pOpCtx, mem, pRedirUri);

					result.Code = mem.OauthGrantCode;
					result.Redirect = mem.OauthGrantRedirectUri;
					return result;
				}
			}

			User user = (userId == null ? null : pTasks.GetUser(pOpCtx.Data, (long)userId));

			result.ShowLoginPage = (user == null || forceLogin);
			result.AppId = appId;
			result.AppName = app.Name;
			result.LoggedUserId = (user == null ? 0 : user.VertexId);
			result.LoggedUserName = (user == null ? null : user.Name);

			return result;
		}

	}

}