using Fabric.Api.Oauth;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public interface IOauthFuncs {
		
		OauthAccessBase Access { get; }
		OauthAccessAuthCode AccessAuthCode { get; }
		OauthAccessClientCred AccessClientCred { get; }
		OauthAccessClientDataProv AccessClientDataProv { get; }
		OauthAccessRefToken AccessRefToken { get; }

		OauthLogout Logout { get; }

	}

}