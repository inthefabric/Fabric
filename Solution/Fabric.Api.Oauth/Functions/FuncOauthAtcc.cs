using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Oauth.Functions {
	
	/*================================================================================================*/
	[Func("AccessTokenClientCredentials", typeof(FabOauthAccess), ResxKey="OauthAtcc")]
	public class FuncOauthAtcc {

		[FuncParam(FuncOauthAt.RedirectUriName, FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam(FuncOauthAt.ClientSecretName, FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam(FuncOauthAt.ClientIdName, FuncResxKey="OauthAt")]
		public string ClientId { get; private set; }

	}

}