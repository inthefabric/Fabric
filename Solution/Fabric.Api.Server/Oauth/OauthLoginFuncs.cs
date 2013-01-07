using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public class OauthLoginFuncs : ModuleFuncBase, IOauthLoginFuncs {

		private const string DbSvcUrl = "http://localhost:9001/";

		/* 
		response_type=code&
		client_id=3&
		redirect_uri=http%3a%2f%2flocalhost:9000&
		state=33ce55b4b5a246f99001a3f75b4fc01a&
		switchMode=0
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

		/*--------------------------------------------------------------------------------------------*/
		private Response ResponseLoginPage(FabOauthLogin pLog) {
			return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, pLog);
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response ResponseScopePage(FabOauthLogin pLog) {
			return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, pLog);
		}

	}

}