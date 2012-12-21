using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("AccessTokenRefresh", typeof(FabOauthAccess), ResxKey="OauthAtr")]
	public class FuncOauthAtrStep : FuncOauthFinal { //TEST: FuncOauthAtrStep

		[FuncParam("redirect_uri", FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam("client_secret", FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam("refresh_token", FuncResxKey="OauthAt")]
		public string RefreshToken { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncOauthAtrStep(Path pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabOauth));
		}

	}

}