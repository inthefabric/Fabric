using Fabric.Api.Oauth;
using Nancy;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public interface IOauthFuncs {
		
		OauthAccessAuthCode AccessAuthCode { get; }
		OauthAccessClientCred AccessClientCred { get; }
		OauthAccessClientDataProv AccessClientDataProv { get; }
		OauthAccessRefToken AccessRefToken { get; }
		OauthLogout Logout { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		Response Execute(OauthFuncs.Function pFunc);

	}

}