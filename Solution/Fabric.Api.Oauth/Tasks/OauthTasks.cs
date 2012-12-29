using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class OauthTasks : IOauthTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess GetAccessToken(string pToken, IApiContext pContext) {
			return new GetAccessToken(pToken).Go(pContext);
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess DoLogout(FabOauthAccess pAccess, IApiContext pContext) {
			return new DoLogout(pAccess).Go(pContext);
		}

	}

}