using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("AccessTokenAuthCode", typeof(FabOauthAccess), ResxKey="OauthAtac")]
	public class FuncOauthAtacStep : FuncOauthFinal { //TEST: FuncOauthAtacStep

		public const string RedirectUriName = "redirect_uri";
		public const string ClientSecretName = "client_secret";
		public const string CodeName = "code";

		[FuncParam(RedirectUriName, FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam(ClientSecretName, FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam(CodeName, FuncResxKey="OauthAt")]
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