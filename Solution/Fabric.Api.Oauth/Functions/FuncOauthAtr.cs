using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Oauth.Functions {
	
	/*================================================================================================*/
	[Func("AccessTokenRefresh", typeof(FabOauthAccess), ResxKey="OauthAtr")]
	public class FuncOauthAtr {

		[FuncParam(FuncOauthAt.RedirectUriName, FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam(FuncOauthAt.ClientSecretName, FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam(FuncOauthAt.RefreshTokenName, FuncResxKey="OauthAt")]
		public string RefreshToken { get; private set; }

	}

}