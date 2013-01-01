using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Api;
using Fabric.Api.Oauth.Results;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public interface IOauthTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		FabOauthAccess AddAccess(long pAppId, long? pUserId, int pExpireSec, bool pClientOnly,
		                         												IApiContext pContext);
		FabOauthAccess DoLogout(FabOauthAccess pAccess, IApiContext pContext);
		FabOauthAccess GetAccessToken(string pToken, IApiContext pContext);
		GrantResult GetGrant(string pCode, IApiContext pContext);

	}

}