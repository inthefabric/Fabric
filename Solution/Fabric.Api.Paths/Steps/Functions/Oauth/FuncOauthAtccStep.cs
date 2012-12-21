using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("AccessTokenClientCredentials", typeof(FabOauthAccess), ResxKey="OauthAtcc")]
	public class FuncOauthAtccStep : FuncOauthFinal { //TEST: FuncOauthAtccStep

		[FuncParam("redirect_uri", FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam("client_secret", FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam("client_id", FuncResxKey="OauthAt")]
		public string ClientId { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncOauthAtccStep(Path pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabOauth));
		}

	}

}