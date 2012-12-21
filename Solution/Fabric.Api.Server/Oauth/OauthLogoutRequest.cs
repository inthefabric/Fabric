using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public class OauthLogoutRequest : OauthBase<FabOauthLogout> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IActiveFunc<FabOauthLogout> BuildFunc() {
			return new OauthLogout(
				GetParamString(FuncOauthLogoutStep.AccessTokenName)
			);
		}

	}

}