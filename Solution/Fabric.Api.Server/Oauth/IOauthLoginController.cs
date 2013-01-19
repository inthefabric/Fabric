using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public interface IOauthLoginController {

		FabOauthLogin LoginDto { get; }

	}

}