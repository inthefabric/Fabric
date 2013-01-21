using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Oauth.Functions {
	
	/*================================================================================================*/
	[Func("AccessTokenClientCredentials", typeof(FabOauthAccess), ResxKey="OauthAtcc")]
	public class FuncOauthAtccStep {

		[FuncParam(FuncOauthAtStep.RedirectUriName, FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam(FuncOauthAtStep.ClientSecretName, FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam(FuncOauthAtStep.ClientIdName, FuncResxKey="OauthAt")]
		public string ClientId { get; private set; }

	}

}