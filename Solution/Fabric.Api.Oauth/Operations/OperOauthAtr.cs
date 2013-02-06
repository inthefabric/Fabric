using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Operations {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.OauthUri, FabHome.Get,FabHome.OauthAccessTokenRefreshUri,
		typeof(FabOauthAccess), ResxKey="AccessToken")]
	public class OperOauthAtr {

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.RedirectUriParam, typeof(OauthGrant),
			DomainPropertyName="RedirectUri")]
		public string RedirectUri;

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.ClientSecretParam, typeof(App),
			DomainPropertyName="Secret")]
		public string ClientSecret;

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.RefreshTokenParam, typeof(OauthAccess),
			DomainPropertyName="Refresh")]
		public string RefreshToken;

	}

}