using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class OauthTasks : IOauthTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess AddAccess(long pAppId, long? pUserId, int pExpireSec, bool pClientOnly,
		                                										IApiContext pContext) {
			return new AddAccess(pAppId, pUserId, pExpireSec, pClientOnly).Go(pContext);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess DoLogout(FabOauthAccess pAccess, IApiContext pContext) {
			return new DoLogout(pAccess).Go(pContext);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess GetAccessToken(string pToken, IApiContext pContext) {
			return new GetAccessToken(pToken).Go(pContext);
		}

		/*--------------------------------------------------------------------------------------------*/
		public App GetAppAuth(long pAppId, string pAppSecret, IApiContext pContext) {
			return new GetAppAuth(pAppId, pAppSecret).Go(pContext);
		}

		/*--------------------------------------------------------------------------------------------*/
		public User GetDataProv(long pAppId, long pDataProvUserId, IApiContext pContext) {
			return new GetDataProv(pAppId, pDataProvUserId).Go(pContext);
		}

		/*--------------------------------------------------------------------------------------------*/
		public DomainResult GetDomain(long pAppId, string pRedirectUri, IApiContext pContext) {
			return new GetDomain(pAppId, pRedirectUri).Go(pContext);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public GrantResult GetGrant(string pCode, IApiContext pContext) {
			return new GetGrant(pCode).Go(pContext);
		}

	}

}