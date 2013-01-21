using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Oauth.Functions {
	
	/*================================================================================================*/
	[Func("Logout", typeof(FabOauthLogout), ResxKey="OauthLogout")]
	public class FuncOauthLogout {

		public const string AccessTokenName = "access_token";

		[FuncParam(AccessTokenName)]
		public string AccessToken { get; set; }

	}

}