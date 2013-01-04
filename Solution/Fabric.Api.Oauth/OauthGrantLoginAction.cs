using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth {
	
	/*================================================================================================*/
	public class OauthGrantLoginAction : ApiFunc<FabOauthLogin> { //TEST: OauthGrantLoginAction

		private readonly string vUsername;
		private readonly string vPassword;
		private readonly IOauthGrantCore vCore;
		private readonly IOauthTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantLoginAction(string pUsername, string pPassword, IOauthGrantCore pCore,
																				IOauthTasks pTasks) {
			vUsername = pUsername;
			vPassword = pPassword;
			vCore = pCore;
			vTasks = pTasks;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthLogin Execute() {
			try {
				return GetLogin();
			}
			catch ( OauthException ) {
				throw;
			}
			catch ( Exception e ) {
				throw vCore.GetFaultOnException(e);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthLogin GetLogin() {
			var result = new FabOauthLogin();

			App app = vCore.GetApp(Context);
			result.AppId = app.AppId;
			result.AppName = app.Name;

			User user = vTasks.GetUserAuth(vUsername, vPassword, Context);

			if ( user == null ) {
				result.ShowLoginPage = true;
				result.LoginErrorText = "Login was not successful.";
			}
			else {
				LoginScopeResult scope = vCore.GetGrantCodeIfScopeAlreadyAllowed(vTasks, Context);
				result.LoggedUserId = user.UserId;
				result.LoggedUserName = user.Name;
				result.ScopeCode = scope.Code;
				result.ScopeRedirect = scope.Redirect;
			}

			return result;
		}

	}

}