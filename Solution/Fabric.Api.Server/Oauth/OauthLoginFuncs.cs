using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public class OauthLoginFuncs : ModuleFuncBase, IOauthLoginFuncs {

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
		public OauthLoginFuncs(DynamicDictionary pQuery) : base(pQuery, new ApiContext(DbSvcUrl)) {}
		
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
				return LoginRedirect(oe.OauthError);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response LoginRedirect(string pRedir, string pCode) {
			return NancyUtil.Redirect(pRedir+"?code="+pCode+"&state="+vState);
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response LoginRedirect(FabOauthError pErr) {
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
			//LoginInner(LoginPostInner);
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response LoginGetInner() {
			if ( vIncomingError != null ) {
				return ResponseErrorWithoutRedirect();
			}

			vLoggedUserId = 0; //TODO: obtain via HTTP request data

			var code = new OauthGrantCore(vClientId, vRedirUri, vLoggedUserId);
			var func = new OauthGrantLoginEntry(vRespType, vSwitchMode, code, new OauthTasks());

			FabOauthLogin log = func.Go(ApiCtx);

			if ( log.ShowLoginPage ) {
				return ResponseLoginPage(log);
			}

			if ( log.ScopeCode != null ) {
				return LoginRedirect(log.ScopeRedirect, log.ScopeCode);
			}

			return ResponseScopePage(log);
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response ResponseErrorWithoutRedirect() {
			string desc = GetParamString("error_description", false);
			
			if ( desc != null ) {
				desc = desc.Replace('+', ' ');
			}

			string html = "<b>"+vIncomingError+"</b><br/>"+desc;
			return NancyUtil.BuildHtmlResponse(HttpStatusCode.OK, html);
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
		private Response ResponseLoginPage(FabOauthLogin pLog) {
			string html = 
				"<div>"+
				"	<p>"+
				"		The <b>"+pLog.AppName+"</b> Fabric App would like connect to your account. "+
				"		Please sign in to accept this request for access."+
				"	</p>"+
				"	<div>"+
				"		<form id='LoginForm' method='POST'>"+
				"			<h3>"+
				"				Login"+
				"			</h3>"+
				"			<div>"+
				"				<div class='FormLabel'>"+
				"					Username"+
				"				</div>"+
				"				<div class='FormField'>"+
				"					<input type='text' name='username' value='"+pLog.LoggedUserName+"' />"+
				"				</div>"+
				"				<div class='FormLabel'>"+
				"					Password"+
				"				</div>"+
				"				<div class='FormField'>"+
				"					<input type='password' name='password' />"+
				"				</div>"+
				"				<div class='FormField'>"+
				"					<input type='checkbox' name='rememberMe' value='true' /> Remember me?"+
				"				</div>"+
				"				<p class='ZeroBottom'>"+
				"					<span class='field-validation-error'>"+pLog.LoginErrorText+"</span>"+
				"					<input type='submit' name='LoginAction' value='Login' />"+
				"					<input type='submit' name='CancelAction' value='Cancel' />"+
				"				</p>"+
				"			</div>"+
				"		</form>"+
				"	</div>"+
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