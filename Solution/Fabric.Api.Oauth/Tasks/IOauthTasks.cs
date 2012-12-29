using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public interface IOauthTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		FabOauthAccess GetAccessToken(string pToken, IApiContext pContext);
		FabOauthAccess DoLogout(FabOauthAccess pAccess, IApiContext pContext);

	}

}