using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("AccessToken", typeof(FabOauthAccess), ResxKey="OauthAt")]
	public class FuncOauthAtStep : FuncOauthFinal {

		public const string GrantTypeAc = "authorization_code";
		public const string GrantTypeCc = "client_credentials";
		public const string GrantTypeCdp = "client_dataprov";
		public const string GrantTypeRt = "refresh_token";

		public const string GrantTypeName = "grant_type";
		public const string RedirectUriName = "redirect_uri";
		public const string ClientSecretName = "client_secret";
		public const string CodeName = "code";
		public const string RefreshTokenName = "refresh_token";
		public const string ClientIdName = "client_id";
		public const string DataProvUserIdName = "data_prov_userid";

		[FuncParam(GrantTypeName, FuncResxKey="OauthAt")]
		public string GrantType { get; private set; }

		[FuncParam(RedirectUriName, FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam(ClientSecretName, FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam(CodeName, false, FuncResxKey="OauthAt")]
		public string Code { get; private set; }

		[FuncParam(RefreshTokenName, false, FuncResxKey="OauthAt")]
		public string RefreshToken { get; private set; }

		[FuncParam(ClientIdName, false, FuncResxKey="OauthAt")]
		public string ClientId { get; private set; }
		
		[FuncParam(DataProvUserIdName, false, FuncResxKey="OauthAt")]
		public string DataProvUserId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncOauthAtStep(Path pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabOauth));
		}

	}

}