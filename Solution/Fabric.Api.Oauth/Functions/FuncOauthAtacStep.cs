using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Oauth.Functions {
	
	/*================================================================================================*/
	[Func("AccessTokenAuthCode", typeof(FabOauthAccess), ResxKey="OauthAtac")]
	public class FuncOauthAtacStep {

		[FuncParam(FuncOauthAtStep.RedirectUriName, FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam(FuncOauthAtStep.ClientSecretName, FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam(FuncOauthAtStep.CodeName, FuncResxKey="OauthAt")]
		public string Code { get; private set; }

	}

}