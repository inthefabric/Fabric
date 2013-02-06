using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Operations {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.OauthUri, FabHome.Get, FabHome.OauthAccessTokenClientCredentialsUri,
		typeof(FabOauthAccess), ResxKey="AccessToken")]
	public class OperOauthAtcc {

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.RedirectUriParam, typeof(OauthGrant),
			DomainPropertyName="RedirectUri", ResxKey="RedirectUri")]
		public string RedirectUri;

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.ClientSecretParam, typeof(App),
			DomainPropertyName="Secret", ResxKey="Secret")]
		public string ClientSecret;

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.ClientIdParam, typeof(App),
			DomainPropertyName="AppId", ResxKey="ClientId")]
		public string ClientId;

	}

}