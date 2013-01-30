using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth {
	
	/*================================================================================================*/
	public class OauthGrantScopeAction : ApiFunc<LoginScopeResult> {

		private readonly bool vAllowScope;
		private readonly IOauthGrantCore vCore;
		private readonly IOauthTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantScopeAction(bool pAllowScope, IOauthGrantCore pCore, IOauthTasks pTasks) {
			vAllowScope = pAllowScope;
			vCore = pCore;
			vTasks = pTasks;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override LoginScopeResult Execute() {
			if ( !vAllowScope ) {
				vTasks.AddScope(vCore.AppId, (long)vCore.UserId, false, Context);
				throw vCore.GetFault(GrantErrors.access_denied, GrantErrorDescs.AccessDeny);
			}
			
			return vCore.AddGrantCode(false, vTasks, Context);
		}

	}

}