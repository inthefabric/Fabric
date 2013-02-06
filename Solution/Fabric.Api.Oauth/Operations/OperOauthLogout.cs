using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Operations {

	/*================================================================================================*/
	[ServiceOp(FabHome.OauthUri, FabHome.Get, FabHome.OauthLogoutUri, typeof(FabOauthLogout))]
	public class OperOauthLogout {

		public const string AccessTokenParam = "access_token";

		[ServiceOpParam(ServiceOpParamType.Query, AccessTokenParam,
			typeof(OauthAccess), DomainPropertyName="Token", ResxKey="Token")]
		public string Token;

	}

}