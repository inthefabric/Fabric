using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("AccessTokenAuthCode", typeof(FabOauthAccess), ResxKey="OauthAtac")]
	public class FuncOauthAtacStep : FuncOauthFinal { //TEST: FuncOauthAtacStep

		[FuncParam("redirect_uri", FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam("client_secret", FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam("code", FuncResxKey="OauthAt")]
		public string Code { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncOauthAtacStep(Path pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabOauth));
		}

	}

}