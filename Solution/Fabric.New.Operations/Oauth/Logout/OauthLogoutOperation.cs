using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;

namespace Fabric.New.Operations.Oauth.Logout {

	/*================================================================================================*/
	public class OauthLogoutOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthLogout Execute(IOperationContext pOpCtx, 
															IOauthLogoutTasks pTasks, string pToken) {
			OauthAccess oa = pTasks.GetAccessToken(pOpCtx.Data, pToken);
			pTasks.DoLogout(pOpCtx.Data, oa);

			return new FabOauthLogout {
				Success = 1,
				AccessToken = pToken
			};
		}

	}

}