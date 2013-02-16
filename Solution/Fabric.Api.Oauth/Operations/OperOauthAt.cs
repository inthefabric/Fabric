using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Operations {

	/*================================================================================================*/
	[ServiceOp(FabHome.OauthUri, FabHome.Get, FabHome.OauthAccessTokenUri, typeof(FabOauthAccess))]
	public class OperOauthAt {

		public const string GrantTypeAc = "authorization_code";
		public const string GrantTypeCc = "client_credentials";
		public const string GrantTypeCdp = "client_dataprov";
		public const string GrantTypeRt = "refresh_token";

		public const string GrantTypeParam = "grant_type";
		public const string RedirectUriParam = "redirect_uri";
		public const string ClientSecretParam = "client_secret";
		public const string CodeParam = "code";
		public const string RefreshTokenParam = "refresh_token";
		public const string ClientIdParam = "client_id";
		public const string DataProvUserIdParam = "data_prov_userid";

		[ServiceOpParam(ServiceOpParamType.Query, GrantTypeParam, 0, null,
			DomainPropertyName="GrantType", ResxKey="GrantType")]
		public string GrantType;

		[ServiceOpParam(ServiceOpParamType.Query, ClientIdParam, 1, typeof(App),
			DomainPropertyName="AppId", ResxKey="ClientId")]
		public string ClientId;

		[ServiceOpParam(ServiceOpParamType.Query, ClientSecretParam, 2, typeof(App),
			DomainPropertyName="Secret", ResxKey="Secret")]
		public string ClientSecret;

		[ServiceOpParam(ServiceOpParamType.Query, CodeParam, 3, typeof(OauthGrant),
			DomainPropertyName="Code", ResxKey="Code")]
		public string Code;

		[ServiceOpParam(ServiceOpParamType.Query, RefreshTokenParam, 4, typeof(OauthAccess),
			DomainPropertyName="Refresh", ResxKey="Refresh")]
		public string RefreshToken;

		[ServiceOpParam(ServiceOpParamType.Query, RedirectUriParam, 5, typeof(OauthGrant),
			DomainPropertyName="RedirectUri", ResxKey="RedirectUri")]
		public string RedirectUri;

		[ServiceOpParam(ServiceOpParamType.Query, DataProvUserIdParam, 6, typeof(User),
			DomainPropertyName="UserId", ResxKey="DataProvUserId")]
		public string DataProvUserId;
		
	}

}