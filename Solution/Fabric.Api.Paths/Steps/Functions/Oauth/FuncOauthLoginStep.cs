using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("Login", typeof(FabOauthLogin), ResxKey="OauthLogin")]
	public class FuncOauthLoginStep : FuncOauthFinal { //TEST: FuncOauthLoginStep

		[FuncParam("response_type")]
		public string ResponseType { get; set; }

		[FuncParam("client_id")]
		public string ClientId { get; set; }

		[FuncParam("redirect_uri")]
		public string RedirectUri { get; set; }

		[FuncParam("scope", false)]
		public string Scope { get; set; }

		[FuncParam("state", false)]
		public string State { get; set; }

		[FuncParam("switchMode", false)]
		public string SwitchMode { get; set; }

		//in case someone goes directly to the OAuth page.
		/*[FuncParam(false)]
		public string error { get; set; }

		//Internal: POST vars

		public string loginButton { get; set; }
		public string cancelButton { get; set; }
		public string allowButton { get; set; }
		public string denyButton { get; set; }
		public string logoutButton { get; set; }

		public string username { get; set; }
		public string password { get; set; }
		public bool rememberMe { get; set; }*/


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncOauthLoginStep(Path pPath) : base(pPath) { }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabOauth));
		}

	}

}