using System;
using System.Collections.Generic;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Api.Server.Common;
using Fabric.Api.Server.Oauth.Views;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	//TEST: OauthLoginFuncs unit tests. Move flows (like OauthGrantLoginEntry) into an interface.
	public class OauthLoginController : ControllerBase {

		public enum Method {
			Get,
			Post
		}
		
		public const string CancelAction = "CancelAction";
		public const string LogoutAction = "LogoutAction";
		public const string LoginAction = "LoginAction";
		public const string AllowAction = "AllowAction";
		public const string DenyAction = "DenyAction";

		public const string Username = "Username";
		public const string Password = "Password";
		public const string RememberMe = "RememberMe";

		/*
		
		localhost:9000/api/oauth/login?
			response_type=code&client_id=2&redirect_uri=http%3a%2f%2flocalhost:49316
		 
		localhost:9000/api/Oauth/AccessTokenAuthCode?
			client_secret=0123456789abcdefghijkLMNOPqrstuv&code=INSERT&
			redirect_uri=http%3a%2f%2flocalhost:49316
		
		*/

		public FabOauthLogin LoginDto { get; private set; }

		private readonly IDictionary<string, string> vCookies;
		private readonly Method vMethod;

		private string vIncomingError;
		private long vLoggedUserId;

		private string vClientId;
		private string vRedirUri;
		private string vRespType;
		private string vScope;
		private string vSwitchMode;
		private string vState;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthLoginController(IApiContext pApiCtx, DynamicDictionary pQuery,
										DynamicDictionary pForm, IDictionary<string, string> pCookies,
										Method pMethod) : base(pApiCtx, pQuery, pForm) {
			vCookies = pCookies;
			vMethod = pMethod;
		}


		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildResponse() {
			try {
				vIncomingError = GetParamString("error", false);
				vLoggedUserId = NancyUtil.GetUserIdFromCookies(vCookies);

				vClientId = GetParamString(FuncOauthLoginStep.ClientIdName, false);
				vRedirUri = GetParamString(FuncOauthLoginStep.RedirectUriName, false);
				vRespType = GetParamString(FuncOauthLoginStep.ResponseTypeName, false);
				vScope = GetParamString(FuncOauthLoginStep.ScopeName, false);
				vSwitchMode = GetParamString(FuncOauthLoginStep.SwitchModeName, false);
				vState = GetParamString(FuncOauthLoginStep.StateName, false);

				switch ( vMethod ) {
					case Method.Get: return LoginGet();
					case Method.Post: return LoginPost();
					default: throw new Exception("Unknown Method: "+vMethod);
				}
			}
			catch ( OauthException oe ) {
				return Redirect(oe.OauthError);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response Redirect(string pRedir, string pCode) {
			return NancyUtil.Redirect(pRedir+"?code="+pCode+"&state="+vState);
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response Redirect(FabOauthError pErr) {
			return NancyUtil.Redirect(vRedirUri+"?error="+pErr.Error+
				"&error_description="+pErr.ErrorDesc.Replace(' ', '+')+"&state="+vState);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response LoginGet() {
			if ( vIncomingError != null ) {
				string errDesc = GetParamString("error_description", false);
				return new LoginErrorView(vIncomingError, errDesc).ToResponse();
			}

			var core = new OauthGrantCore(vClientId, vRedirUri, vLoggedUserId);
			var func = new OauthGrantLoginEntry(vRespType, vSwitchMode, core, new OauthTasks());
			LoginDto = func.Go(ApiCtx);

			if ( LoginDto.ShowLoginPage ) {
				return new LoginPageView(LoginDto).ToResponse();
			}

			if ( LoginDto.ScopeCode != null ) {
				return Redirect(LoginDto.ScopeRedirect, LoginDto.ScopeCode);
			}

			return new LoginScopeView(LoginDto).ToResponse();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response LoginPost() {
			if ( GetPostString(CancelAction, false) != null ) { return PerformCancel(); }
			if ( GetPostString(LogoutAction, false) != null ) { return PeformLogout(); }
			if ( GetPostString(LoginAction, false) != null ) { return PerformLogin(); }
			if ( GetPostString(AllowAction, false) != null ) { return PerformAllow(); }
			if ( GetPostString(DenyAction, false) != null ) { return PerformDeny(); }
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response PerformCancel() {
			throw OauthGrantCore.GetFaultStatic(GrantErrors.access_denied, GrantErrorDescs.LoginCancel);
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response PeformLogout() {
			Response r = NancyUtil.Redirect(vRedirUri);
			NancyUtil.SetUserCookie(r, null, false);
			return r;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response PerformLogin() {
			string user = GetPostString(Username, false);
			string pass = GetPostString(Password, false);
			bool rem = (GetPostString(RememberMe, false) == "1");

			var core = new OauthGrantCore(vClientId, vRedirUri, vLoggedUserId);
			var func = new OauthGrantLoginAction(user, pass, core, new OauthTasks());
			LoginDto = func.Go(ApiCtx);

			if ( LoginDto.ShowLoginPage ) {
				return new LoginPageView(LoginDto).ToResponse();
			}

			bool scopeAllowed = (LoginDto.ScopeCode != null);

			Response r = (scopeAllowed ?
				Redirect(LoginDto.ScopeRedirect, LoginDto.ScopeCode) : 
				new LoginScopeView(LoginDto).ToResponse()
			);

			NancyUtil.SetUserCookie(r, LoginDto.LoggedUserId, rem);
			return r;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response PerformAllow() {
			var core = new OauthGrantCore(vClientId, vRedirUri, vLoggedUserId);
			var func = new OauthGrantScopeAction(true, core, new OauthTasks());
			LoginScopeResult ls = func.Go(ApiCtx);
			return Redirect(ls.Redirect, ls.Code);
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response PerformDeny() {
			var core = new OauthGrantCore(vClientId, vRedirUri, vLoggedUserId);
			var func = new OauthGrantScopeAction(false, core, new OauthTasks());
			func.Go(ApiCtx); //throws fault
			return null;
		}

	}

}