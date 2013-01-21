using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Oauth.Functions {
	
	/*================================================================================================*/
	[Func("AccessTokenRefresh", typeof(FabOauthAccess), ResxKey="OauthAtr")]
	public class FuncOauthAtrStep {

		[FuncParam(FuncOauthAtStep.RedirectUriName, FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam(FuncOauthAtStep.ClientSecretName, FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam(FuncOauthAtStep.RefreshTokenName, FuncResxKey="OauthAt")]
		public string RefreshToken { get; private set; }

	}

}