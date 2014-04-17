using Fabric.Api.Objects.Oauth;
using Fabric.Domain;

namespace Fabric.Operations.Oauth {

	/*================================================================================================*/
	public class OauthLogoutOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthLogout Execute(IOperationContext pOpCtx, 
															IOauthLogoutTasks pTasks, string pToken) {
			OauthAccess oa = pTasks.GetAccessToken(pOpCtx.Data, pToken);
			pTasks.DoLogout(pOpCtx, oa);

			return new FabOauthLogout {
				Success = 1,
				AccessToken = pToken
			};
		}

	}

}