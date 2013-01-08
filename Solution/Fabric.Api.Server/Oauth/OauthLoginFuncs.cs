using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public class OauthLoginFuncs : ModuleFuncBase, IOauthLoginFuncs {
		
		public const string CancelAction = "CancelAction";
		public const string LogoutAction = "LogoutAction";
		public const string LoginAction = "LoginAction";
		public const string AllowAction = "AllowAction";
		public const string DenyAction = "DenyAction";

		public const string Username = "Username";
		public const string Password = "Password";
		public const string RememberMe = "RememberMe";

		private const string DbSvcUrl = "http://localhost:9001/";

		/*
		localhost:9000/api/oauth/login?
			response_type=code&client_id=2&redirect_uri=http%3a%2f%2flocalhost:49316
		*/

		private string vIncomingError;
		private string vClientId;
		private string vRedirUri;
		private long vLoggedUserId;
		private string vRespType;
		private string vScope;
		private string vSwitchMode;
		private string vState;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthLoginFuncs(DynamicDictionary pQuery, DynamicDictionary pForm) :
														base(new ApiContext(DbSvcUrl), pQuery, pForm) {}
		
		/*--------------------------------------------------------------------------------------------*/
		private Response LoginInner(Func<Response> pFunc) {
			try {
				vIncomingError = GetParamString("error", false);
				vClientId = GetParamString(FuncOauthLoginStep.ClientIdName);
				vRedirUri = GetParamString(FuncOauthLoginStep.RedirectUriName);
				vRespType = GetParamString(FuncOauthLoginStep.ResponseTypeName);
				vScope = GetParamString(FuncOauthLoginStep.ScopeName, false);
				vSwitchMode = GetParamString(FuncOauthLoginStep.SwitchModeName, false);
				vState = GetParamString(FuncOauthLoginStep.SwitchModeName, false);
				vLoggedUserId = 0;

				return pFunc();
			}
			catch ( OauthException oe ) {
				return Redirect(oe.OauthError);
			}
		}

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
		public Response LoginGet() {
			return LoginInner(LoginGetInner);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response LoginPost() {
			return LoginInner(LoginPostInner);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response LoginGetInner() {
			if ( vIncomingError != null ) {
				return ResponseErrorPage();
			}

			vLoggedUserId = 0; //TODO: obtain via HTTP request data

			var core = new OauthGrantCore(vClientId, vRedirUri, vLoggedUserId);
			var func = new OauthGrantLoginEntry(vRespType, vSwitchMode, core, new OauthTasks());
			FabOauthLogin log = func.Go(ApiCtx);

			if ( log.ShowLoginPage ) {
				return ResponseLoginPage(log);
			}

			if ( log.ScopeCode != null ) {
				return Redirect(log.ScopeRedirect, log.ScopeCode);
			}

			return ResponseScopePage(log);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response LoginPostInner() {
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
			//TODO: r.SetUserHeader(r, null, false);
			return r;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response PerformLogin() {
			string user = GetPostString("username", false);
			string pass = GetPostString("password", false);

			var core = new OauthGrantCore(vClientId, vRedirUri, vLoggedUserId);
			var func = new OauthGrantLoginAction(user, pass, core, new OauthTasks());
			FabOauthLogin log = func.Go(ApiCtx);

			if ( log.ShowLoginPage ) {
				return ResponseLoginPage(log);
			}

			bool scopeAllowed = (log.ScopeCode != null);

			Response r = (scopeAllowed ?
				Redirect(log.ScopeRedirect, log.ScopeCode) : ResponseScopePage(log));
			//TODO: AuthUtil.SetUserHeader(r, log.LoggedUserId, Req.rememberMe);
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string BuildHtmlPage(string pTitle, string pHtmlContent) {
			return
				"<html>\n"+
				"	<head>\n"+
				"		<title>"+pTitle+"</title>\n"+
				"	</head>\n"+
				"	<body>\n"+
				"		"+pHtmlContent+"\n"+
				"	</body>\n"+
				"</html>";
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response ResponseErrorPage() {
			string desc = GetParamString("error_description", false);

			if ( desc != null ) {
				desc = desc.Replace('+', ' ');
			}

			string html = "<b>"+vIncomingError+"</b><br/>"+desc;
			html = BuildHtmlPage("Fabric Login Page Error", html);
			return NancyUtil.BuildHtmlResponse(HttpStatusCode.OK, html);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private Response ResponseLoginPage(FabOauthLogin pLog) {
			string err = pLog.LoginErrorText;

			if ( err != null ) {
				err += "<br/>";
			}

			string html = 
				"<div>"+
				"	<p>"+
				"		The <b>"+pLog.AppName+"</b> Fabric App would like connect to your account. "+
				"		Please sign in to accept this request for access."+
				"	</p>"+
				"	<form id='LoginForm' method='POST'>"+
				"		<h3>"+
				"			Login"+
				"		</h3>"+
				"		<div>"+
				"			<div class='label'>"+
				"				Username"+
				"			</div>"+
				"			<div class='field'>"+
				"				<input type='text' name='"+Username+"' value='"+pLog.LoggedUserName+"' />"+
				"			</div>"+
				"			<div class='label'>"+
				"				Password"+
				"			</div>"+
				"			<div class='field'>"+
				"				<input type='password' name='"+Password+"' />"+
				"			</div>"+
				"			<div class='field'>"+
				"				<input type='checkbox' name='"+RememberMe+"' value='1' /> Remember me?"+
				"			</div>"+
				"			<p>"+
				"				<span class='fieldError'>"+err+"</span>"+
				"				<input type='submit' name='"+LoginAction+"' value='Login' />"+
				"				<input type='submit' name='"+CancelAction+"' value='Cancel' />"+
				"			</p>"+
				"		</div>"+
				"	</form>"+
				"</div>";

			html = BuildHtmlPage("Fabric Login", html);
			return NancyUtil.BuildHtmlResponse(HttpStatusCode.OK, html);
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response ResponseScopePage(FabOauthLogin pLog) {
			return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, pLog);
		}

	}

}