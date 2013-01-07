using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("Login", typeof(FabOauthLogin), ResxKey="OauthLogin")]
	public class FuncOauthLoginStep : FuncOauthFinal { //TEST: FuncOauthLoginStep

		public const string ResponseTypeName = "response_type";
		public const string ClientIdName = "client_id";
		public const string RedirectUriName = "redirect_uri";
		public const string ScopeName = "scope";
		public const string StateName = "state";
		public const string SwitchModeName = "switchMode";

		[FuncParam(ResponseTypeName)]
		public string ResponseType { get; set; }

		[FuncParam(ClientIdName)]
		public string ClientId { get; set; }

		[FuncParam(RedirectUriName)]
		public string RedirectUri { get; set; }

		[FuncParam(ScopeName, false)]
		public string Scope { get; set; }

		[FuncParam(StateName, false)]
		public string State { get; set; }

		[FuncParam(SwitchModeName, false)]
		public string SwitchMode { get; set; }

		//in case someone goes directly to the OAuth page.

		public string Error { get; set; }

		//Internal: POST vars

		public string LoginAction { get; set; }
		public string CancelAction { get; set; }
		public string AllowAction { get; set; }
		public string DenyAction { get; set; }
		public string LogoutAction { get; set; }

		public string Username { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }


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