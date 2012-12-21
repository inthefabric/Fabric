using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("AccessTokenClientDataProv", typeof(FabOauthAccess), ResxKey="OauthAtcd")]
	public class FuncOauthAtcdStep : FuncOauthFinal { //TEST: FuncOauthAtcdStep

		[FuncParam("redirect_uri", FuncResxKey="OauthAt")]
		public string RedirectUri { get; private set; }

		[FuncParam("client_secret", FuncResxKey="OauthAt")]
		public string ClientSecret { get; private set; }

		[FuncParam("client_id", FuncResxKey="OauthAt")]
		public string ClientId { get; private set; }

		[FuncParam("data_prov_userid", FuncResxKey="OauthAt")]
		public string DataProvUserId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncOauthAtcdStep(Path pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabOauth));
		}

	}

}