using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth {
	
	/*================================================================================================*/
	public class OauthGrantLoginEntry : ApiFunc<FabOauthLogin> {

		private readonly string vResponseType;
		private readonly string vSwitchMode;
		private readonly IOauthGrantCore vCore;
		private readonly IOauthTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantLoginEntry(string pResponseType, string pSwitchMode, IOauthGrantCore pCore,
		                            											IOauthTasks pTasks) {
			vResponseType = pResponseType;
			vSwitchMode = pSwitchMode;
			vCore = pCore;
			vTasks = pTasks;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vResponseType != "code" ) {
				throw vCore.GetFault(GrantErrors.invalid_request, GrantErrorDescs.BadRespType);
			}

			if ( vSwitchMode != null && vSwitchMode != "0" && vSwitchMode != "1" ) {
				throw vCore.GetFault(GrantErrors.invalid_request, GrantErrorDescs.BadSwitch);
			}

			// Redirect tests

			if ( vCore.RedirectUri == null || vCore.RedirectUri.Length <= 0 ) {
				throw vCore.GetFault(GrantErrors.invalid_request, GrantErrorDescs.NoRedirUri);
			}

			if ( vCore.RedirectUri.IndexOf("://") <= 0 ) {
				throw vCore.GetFault(GrantErrors.invalid_request, GrantErrorDescs.BadRedirUri);
			}

			// App tests

			if ( vCore.AppId <= 0 ) {
				throw vCore.GetFault(GrantErrors.unauthorized_client, GrantErrorDescs.NoClient);
			}

			// Scope tests

			/*if ( false ) {
				throw vCore.GetFault(GrantErrors.invalid_scope, "The scope is invalid");
				return;
			}*/
		}


		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthLogin Execute() {
			App app = vCore.GetApp(ApiCtx); //throws fault on error
			CheckDomain();
			
			var result = new FabOauthLogin();
			bool switchBool = (vSwitchMode == "1");

			if ( !switchBool ) {
				LoginScopeResult scope = vCore.GetGrantCodeIfScopeAlreadyAllowed(vTasks, ApiCtx);
				
				if ( scope != null ) {
					result.ScopeCode = scope.Code;
					result.ScopeRedirect = scope.Redirect;
					return result;
				}
			}

			User user = vCore.GetUser(ApiCtx);
			
			result.ShowLoginPage = (user == null || switchBool);
			result.AppId = app.AppId;
			result.AppName = app.Name;
			result.LoggedUserId = (user == null ? 0 : user.UserId);
			result.LoggedUserName = (user == null ? null : user.Name);
			return result;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckDomain() {
			DomainResult dom = vTasks.GetDomain(vCore.AppId, vCore.RedirectUri, ApiCtx);

			if ( dom == null ) {
				throw vCore.GetFault(GrantErrors.invalid_request, GrantErrorDescs.RedirMismatch);
			}
		}

	}

}