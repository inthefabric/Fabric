using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("Logout", typeof(FabOauthLogout), ResxKey="OauthLogout")]
	public class FuncOauthLogoutStep : FuncOauthFinal {

		public const string AccessTokenName = "access_token";

		[FuncParam(AccessTokenName)]
		public string AccessToken { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncOauthLogoutStep(Path pPath) : base(pPath) { }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabOauth));
		}

	}

}