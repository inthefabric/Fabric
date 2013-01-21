using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Oauth.Functions {
	
	/*================================================================================================*/
	[Func("AccessTokenAuthCode", typeof(FabOauthAccess), ResxKey="OauthAtac")]
	public class FuncOauthAtac {

		[FuncParam(FuncOauthAt.RedirectUriName, FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam(FuncOauthAt.ClientSecretName, FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam(FuncOauthAt.CodeName, FuncResxKey="OauthAt")]
		public string Code { get; private set; }

	}

}