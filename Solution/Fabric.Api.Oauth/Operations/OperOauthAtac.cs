using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Operations {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.OauthUri, FabHome.Get, FabHome.OauthAccessTokenAuthCodeUri,
		typeof(FabOauthAccess), ResxKey="AccessToken")]
	public class OperOauthAtac {

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.CodeParam, 0, typeof(OauthGrant),
			DomainPropertyName="Code", ResxKey="Code")]
		public string Code;

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.ClientSecretParam, 1, typeof(App),
			DomainPropertyName="Secret", ResxKey="Secret")]
		public string ClientSecret;

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.RedirectUriParam, 2, typeof(OauthGrant),
			DomainPropertyName="RedirectUri", ResxKey="RedirectUri")]
		public string RedirectUri;

	}

}