using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Operations {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.OauthUri, FabHome.Get, FabHome.OauthAccessTokenAuthCodeUri,
		typeof(FabOauthAccess), ResxKey="AccessToken")]
	public class OperOauthAtac {

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.RedirectUriParam, typeof(OauthGrant),
			DomainPropertyName="RedirectUri")]
		public string RedirectUri;

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.ClientSecretParam, typeof(App),
			DomainPropertyName="Secret")]
		public string ClientSecret;

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.CodeParam, typeof(OauthGrant),
			DomainPropertyName="Code")]
		public string Code;

	}

}