using Fabric.Domain;
using Fabric.Operations.Create;

namespace Fabric.Operations.Oauth {

	/*================================================================================================*/
	public class OauthLoginPostOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthLoginResult ExecuteLogin(IOperationContext pOpCtx, IOauthLoginTasks pTasks,
							string pClientId, string pRedirUri, string pUsername, string pPassword) {
								var result = new OauthLoginResult();

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

			Member mem = pTasks.GetMember(pOpCtx.Data, app.VertexId, user.VertexId);

			if ( mem == null ) {
				mem = pTasks.AddMember(pOpCtx, 
					new CreateMemberOperation(), app.VertexId, user.VertexId);
			}

			if ( mem.OauthScopeAllow == true ) {
				result.Code = mem.OauthGrantCode;
				result.Redirect = pRedirUri;
			}

			return result;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthLoginResult ExecuteScope(IOperationContext pOpCtx, IOauthLoginTasks pTasks,
												string pClientId, string pRedirUri, bool pAllowScope) {
			App app = ValidateAndGetApp(pOpCtx, pTasks, pClientId, pRedirUri);
			
			if ( pOpCtx.Auth.CookieUserId == null ) {
				throw pTasks.NewFault(LoginErrors.access_denied, LoginErrorDescs.NotLoggedIn);
			}

			Member mem = pTasks.GetMember(pOpCtx.Data, app.VertexId, (long)pOpCtx.Auth.CookieUserId);

			if ( !pAllowScope ) {
				pTasks.DenyScope(pOpCtx.Data, mem);
				throw pTasks.NewFault(LoginErrors.access_denied, LoginErrorDescs.AccessDeny);
			}

			pTasks.UpdateGrant(pOpCtx, mem, pRedirUri);

			return new OauthLoginResult {
				Redirect = pRedirUri,
				Code = mem.OauthGrantCode
			};
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void ExecuteCancel(IOauthLoginTasks pTasks) {
			throw pTasks.NewFault(LoginErrors.access_denied, LoginErrorDescs.LoginCancel);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static App ValidateAndGetApp(IOperationContext pOpCtx, IOauthLoginTasks pTasks, 
																string pClientId, string pRedirUri) {
			if ( pRedirUri == null || pRedirUri.Length <= 0 ) {
				throw pTasks.NewFault(LoginErrors.invalid_request, LoginErrorDescs.NoRedirUri);
			}

			long appId = pTasks.AppIdToLong(pClientId);
			App app = pTasks.GetApp(pOpCtx.Data, appId);
			pTasks.VerifyAppDomain(app, pRedirUri);
			return app;
		}

	}

}