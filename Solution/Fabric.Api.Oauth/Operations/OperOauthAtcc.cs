﻿using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Operations {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.OauthUri, FabHome.Get, FabHome.OauthAccessTokenClientCredentialsUri,
		typeof(FabOauthAccess), ResxKey="AccessToken")]
	public class OperOauthAtcc {

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.ClientIdParam, 0, typeof(App),
			DomainPropertyName="AppId", ResxKey="ClientId")]
		public string ClientId;

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.ClientSecretParam, 1, typeof(App),
			DomainPropertyName="Secret", ResxKey="Secret")]
		public string ClientSecret;

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.RedirectUriParam, 2, typeof(OauthGrant),
			DomainPropertyName="RedirectUri", ResxKey="RedirectUri")]
		public string RedirectUri;

	}

}