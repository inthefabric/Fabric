using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Operations {

	/*================================================================================================*/
	[ServiceOp(FabHome.OauthUri, FabHome.Get, FabHome.OauthLoginUri, typeof(FabOauthLogin))]
	public class OperOauthLogin {

		public const string ResponseTypeParam = "response_type";
		public const string ClientIdParam = "client_id";
		public const string RedirectUriParam = "redirect_uri";
		public const string ScopeParam = "scope";
		public const string StateParam = "state";
		public const string SwitchModeParam = "switchMode";

		[ServiceOpParam(ServiceOpParamType.Query, ResponseTypeParam, null,
			DomainPropertyName="ResponseType", ResxKey="ResponseType")]
		public string ResponseType;

		[ServiceOpParam(ServiceOpParamType.Query, SwitchModeParam, null,
			DomainPropertyName="SwitchMode", ResxKey="SwitchMode")]
		public string SwitchMode;

		[ServiceOpParam(ServiceOpParamType.Query, ClientIdParam, typeof(App),
			DomainPropertyName="AppId", ResxKey="ClientId")]
		public string ClientId;

		[ServiceOpParam(ServiceOpParamType.Query, RedirectUriParam, typeof(OauthGrant),
			DomainPropertyName="RedirectUri", ResxKey="RedirectUri")]
		public string RedirectUri;

		[ServiceOpParam(ServiceOpParamType.Query, ScopeParam, null,
			DomainPropertyName="Scope", ResxKey="Scope")]
		public string Scope;

		[ServiceOpParam(ServiceOpParamType.Query, StateParam, null,
			DomainPropertyName="State", ResxKey="State")]
		public string State;

	}

}