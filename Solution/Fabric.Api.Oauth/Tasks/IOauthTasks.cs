using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public interface IOauthTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		FabOauthAccess AddAccess(long pAppId, long? pUserId, int pExpireSec, bool pClientOnly,
		                         												IApiContext pContext);
		FabOauthAccess DoLogout(FabOauthAccess pAccess, IApiContext pContext);
		FabOauthAccess GetAccessToken(string pToken, IApiContext pContext);
		App GetAppAuth(long pAppId, string pAppSecret, IApiContext pContext);
		User GetDataProv(long pAppId, long pDataProvUserId, IApiContext pContext);
		DomainResult GetDomain(long pAppId, string pRedirectUri, IApiContext pContext);
		GrantResult GetGrant(string pCode, IApiContext pContext);
		RefreshResult GetRefresh(string pRefreshToken, IApiContext pContext);

	}

}