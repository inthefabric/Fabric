using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Traversal.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("Login", typeof(FabOauthLogin), ResxKey="OauthLogin")]
	public class FuncOauthLoginStep : FuncOauthFinal {

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