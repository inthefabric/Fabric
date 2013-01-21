using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Traversal.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("AccessTokenAuthCode", typeof(FabOauthAccess), ResxKey="OauthAtac")]
	public class FuncOauthAtacStep : FuncOauthFinal {

		[FuncParam(FuncOauthAtStep.RedirectUriName, FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam(FuncOauthAtStep.ClientSecretName, FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam(FuncOauthAtStep.CodeName, FuncResxKey="OauthAt")]
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