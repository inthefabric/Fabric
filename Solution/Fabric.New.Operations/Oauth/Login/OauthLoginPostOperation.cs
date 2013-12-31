using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;

namespace Fabric.New.Operations.Oauth.Login {

	/*================================================================================================*/
	public class OauthLoginPostOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthLogin ExecuteLogin(IOperationContext pOpCtx, IOauthLoginTasks pTasks,
							string pClientId, string pRedirUri, string pUsername, string pPassword) {
			var result = new FabOauthLogin();

			App app = ValidateAndGetApp(pOpCtx, pTasks, pClientId, pRedirUri);
			result.AppId = app.VertexId;
			result.AppName = app.Name;

			User user = pTasks.GetUserByCredentials(pOpCtx.Data, pUsername, pPassword);

			if ( user == null ) {
				result.ShowLoginPage = true;
				result.LoginErrorText = "The Username or Password was incorrect.";
				return result;
			}

			result.LoggedUserId = user.VertexId;
			result.LoggedUserName = user.Name;

			Member mem = pTasks.GetOrAddMember(pOpCtx, app.VertexId, user.VertexId);

			if ( mem.OauthScopeAllow == true ) {
				result.ScopeCode = mem.OauthGrantCode;
				result.ScopeRedirect = pRedirUri;
			}

			return result;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthLogin ExecuteScope(IOperationContext pOpCtx, IOauthLoginTasks pTasks,
												string pClientId, string pRedirUri, bool pAllowScope) {
			ValidateAndGetApp(pOpCtx, pTasks, pClientId, pRedirUri);
			Member actMem = pOpCtx.Auth.ActiveMember;

			if ( !pAllowScope ) {
				pTasks.DenyScope(pOpCtx.Data, actMem);
				throw pTasks.NewFault(GrantErrors.access_denied, GrantErrorDescs.AccessDeny);
			}

			pTasks.UpdateGrant(pOpCtx, actMem, pRedirUri);

			return new FabOauthLogin {
				ScopeRedirect = pRedirUri,
				ScopeCode = actMem.OauthGrantCode
			};
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void ExecuteCancel(IOauthLoginTasks pTasks) {
			throw pTasks.NewFault(GrantErrors.access_denied, GrantErrorDescs.LoginCancel);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static App ValidateAndGetApp(IOperationContext pOpCtx, IOauthLoginTasks pTasks, 
																string pClientId, string pRedirUri) {
			if ( pRedirUri == null || pRedirUri.Length <= 0 ) {
				throw pTasks.NewFault(GrantErrors.invalid_request, GrantErrorDescs.NoRedirUri);
			}

			long appId = pTasks.AppIdToLong(pClientId);
			App app = pTasks.GetApp(pOpCtx.Data, appId);
			pTasks.VerifyAppDomain(app, pRedirUri);
			return app;
		}

	}

}