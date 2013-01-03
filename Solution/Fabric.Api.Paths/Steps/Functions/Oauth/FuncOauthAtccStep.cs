using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("AccessTokenClientCredentials", typeof(FabOauthAccess), ResxKey="OauthAtcc")]
	public class FuncOauthAtccStep : FuncOauthFinal { //TEST: FuncOauthAtccStep

		public const string RedirectUriName = "redirect_uri";
		public const string ClientSecretName = "client_secret";
		public const string ClientIdName = "client_id";

		[FuncParam(RedirectUriName, FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam(ClientSecretName, FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam(ClientIdName, FuncResxKey="OauthAt")]
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