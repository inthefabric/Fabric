using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth {
	
	/*================================================================================================*/
	public class OauthGrantLoginAction : ApiFunc<FabOauthLogin> {

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
			var result = new FabOauthLogin();

			App app = vCore.GetApp(ApiCtx);
			result.AppId = app.AppId;
			result.AppName = app.Name;

			User user = vTasks.GetUserAuth(vUsername, vPassword, ApiCtx);

			if ( user == null ) {
				result.ShowLoginPage = true;
				result.LoginErrorText = "The Username or Password was incorrect.";
				return result;
			}

			vCore.SetUserId(user.UserId);
			result.LoggedUserId = user.UserId;
			result.LoggedUserName = user.Name;

			LoginScopeResult scope = vCore.GetGrantCodeIfScopeAlreadyAllowed(vTasks, ApiCtx);
			
			if ( scope != null ) {
				result.ScopeCode = scope.Code;
				result.ScopeRedirect = scope.Redirect;
			}

			return result;
		}

	}

}