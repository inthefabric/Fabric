using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("access_token", typeof(FabOauthAccess), ResxKey="OauthAt")]
	public class FuncOauthAtStep : FuncOauthFinal { //TEST: FuncOauthAtStep

		[FuncParam("grant_type", FuncResxKey="OauthAt")]
		public string GrantType { get; private set; }
		
		[FuncParam("redirect_uri", FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }
		
		[FuncParam("client_secret", FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }
		
		[FuncParam("code", false, FuncResxKey="OauthAt")]
		public string Code { get; private set; }
		
		[FuncParam("refresh_token", false, FuncResxKey="OauthAt")]
		public string RefreshToken { get; private set; }
		
		[FuncParam("client_id", false, FuncResxKey="OauthAt")]
		public string ClientId { get; private set; }
		
		[FuncParam("data_prov_userid", false, FuncResxKey="OauthAt")]
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