﻿using System;
using System.Collections.Generic;
using Fabric.New.Api.Executors.Views;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Operations.Oauth;
using Fabric.New.Operations.Oauth.Access;
using Fabric.New.Operations.Oauth.Login;
using Fabric.New.Operations.Oauth.Logout;
using ServiceStack.Text;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class OauthExecutors {

		private static readonly string Uri = ApiMenu.Oauth.Uri;

		private const string AccessLang = "Oauth_AccessToken_";
		private const string LoginLang = "Oauth_Login_";
		private const string LogoutLang = "Oauth_Logout_";

		private const string AccessGrantTypeParam = "grant_type";
		private const string AccessClientIdParam = "client_id";
		private const string AccessClientSecretParam = "client_secret";
		private const string AccessCodeParam = "code";
		private const string AccessRefreshTokenParam = "refresh_token";
		private const string AccessRedirectUriParam = "redirect_uri";

		private const string LoginResponseTypeParam = "response_type";
		private const string LoginClientIdParam = "client_id";
		private const string LoginRedirectUriParam = "redirect_uri";
		private const string LoginScopeParam = "scope";
		private const string LoginStateParam = "state";
		private const string LoginSwitchModeParam = "switchMode";

		public const string LoginCancel = "cancel";
		public const string LoginLogout = "logout";
		public const string LoginLogin = "login";
		public const string LoginAllow = "allow";
		public const string LoginDeny = "deny";

		public const string LoginUsername = "Username";
		public const string LoginPassword = "Password";
		public const string LoginRememberMe = "RememberMe";

		private const string LogoutAccessTokenParam = "access_token";

		/*
		
		localhost:9000/oauth/login?response_type=code&client_id=6
			&redirect_uri=http%3a%2f%2flocalhost:49316%2foauth
			&switchMode=1
		 
		localhost:9000/Oauth/AccessTokenAuthCode?
			client_secret=abcdefghijklmnopqrstuvwxyZ012345
			&code=INSERT&redirect_uri=http%3a%2f%2flocalhost:55555%2foauth
		
		*/

		private static readonly IList<ApiEntryParam> AtParams = new List<ApiEntryParam> {
			new ApiEntryParam(AccessGrantTypeParam, typeof(string), false, AccessLang+"GrantType"),
			new ApiEntryParam(AccessClientIdParam, typeof(long), true, AccessLang+"ClientId"),
			new ApiEntryParam(AccessClientSecretParam, typeof(string), true, AccessLang+"Secret"),
			new ApiEntryParam(AccessCodeParam, typeof(string), true, AccessLang+"Code"),
			new ApiEntryParam(AccessRefreshTokenParam, typeof(string), true, AccessLang+"Refresh"),
			new ApiEntryParam(AccessRedirectUriParam, typeof(string), true, AccessLang+"RedirectUri")
		};

		private static readonly IList<ApiEntryParam> AtacParams = new List<ApiEntryParam> {
			new ApiEntryParam(AccessCodeParam, typeof(string), false, AccessLang+"Code"),
			new ApiEntryParam(AccessClientSecretParam, typeof(string), false, AccessLang+"Secret"),
			new ApiEntryParam(AccessRedirectUriParam, typeof(string), false, AccessLang+"RedirectUri")
		};

		private static readonly IList<ApiEntryParam> AtrParams = new List<ApiEntryParam> {
			new ApiEntryParam(AccessRefreshTokenParam, typeof(string), false, AccessLang+"Refresh"),
			new ApiEntryParam(AccessClientSecretParam, typeof(string), false, AccessLang+"Secret"),
			new ApiEntryParam(AccessRedirectUriParam, typeof(string), false, AccessLang+"RedirectUri")
		};

		private static readonly IList<ApiEntryParam> AtccParams = new List<ApiEntryParam> {
			new ApiEntryParam(AccessClientIdParam, typeof(long), false, AccessLang+"ClientId"),
			new ApiEntryParam(AccessClientSecretParam, typeof(string), false, AccessLang+"Secret"),
			new ApiEntryParam(AccessRedirectUriParam, typeof(string), false, AccessLang+"RedirectUri")
		};

		private static readonly IList<ApiEntryParam> GetLoginParams = new List<ApiEntryParam> {
			new ApiEntryParam(LoginResponseTypeParam, typeof(string), false, LoginLang+"ResponseType"),
			new ApiEntryParam(LoginClientIdParam, typeof(string), false, LoginLang+"ClientId"),
			new ApiEntryParam(LoginRedirectUriParam, typeof(string), false, LoginLang+"RedirUri"),
			new ApiEntryParam(LoginScopeParam, typeof(string), false, LoginLang+"Scope"),
			new ApiEntryParam(LoginStateParam, typeof(string), false, LoginLang+"State"),
			new ApiEntryParam(LoginSwitchModeParam, typeof(string), false, LoginLang+"Switch")
		};

		private static readonly IList<ApiEntryParam> PostLoginParams = new List<ApiEntryParam> {
			new ApiEntryParam(LoginCancel, typeof(string), true),
			new ApiEntryParam(LoginLogout, typeof(string), true),
			new ApiEntryParam(LoginLogin, typeof(string), true),
			new ApiEntryParam(LoginAllow, typeof(string), true),
			new ApiEntryParam(LoginDeny, typeof(string), true)
		};

		private static readonly IList<ApiEntryParam> GetLogoutParams = new List<ApiEntryParam> {
			new ApiEntryParam(LogoutAccessTokenParam, typeof(string), false, LogoutLang+"Token")
		};

		public static readonly ApiEntry[] ApiEntries = new[] {
			ApiEntry.Get(Uri+ApiMenu.OauthAt.Uri, GetAt, typeof(FabOauthAccess), AtParams),
			ApiEntry.Get(Uri+ApiMenu.OauthAtac.Uri, GetAtac, typeof(FabOauthAccess), AtacParams),
			ApiEntry.Get(Uri+ApiMenu.OauthAtr.Uri, GetAtr, typeof(FabOauthAccess), AtrParams),
			ApiEntry.Get(Uri+ApiMenu.OauthAtcc.Uri, GetAtcc, typeof(FabOauthAccess), AtccParams),
			ApiEntry.Get(Uri+ApiMenu.OauthLogin.Uri, GetLogin, typeof(FabOauthLogin), GetLoginParams),
			ApiEntry.Post(Uri+ApiMenu.OauthLogin.Uri, PostLogin,
				typeof(FabOauthLogin), PostLoginParams),
			ApiEntry.Get(Uri+ApiMenu.OauthLogout.Uri, GetLogout,
				typeof(FabOauthLogout), GetLogoutParams),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAt(IApiRequest pApiReq) {
			string grant = pApiReq.GetQueryValue(AccessGrantTypeParam, false);
			string clientId = pApiReq.GetQueryValue(AccessClientIdParam, false);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam, false);
			string code = pApiReq.GetQueryValue(AccessCodeParam, false);
			string refresh = pApiReq.GetQueryValue(AccessRefreshTokenParam, false);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam, false);

			return ExecuteAcc(pApiReq, grant, clientId, secret, code, refresh, redirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAtac(IApiRequest pApiReq) {
			string code = pApiReq.GetQueryValue(AccessCodeParam, false);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam, false);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam, false);

			return ExecuteAcc(pApiReq, OauthAccessOperation.GrantTypeAc,
				null, secret, code, null, redirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAtr(IApiRequest pApiReq) {
			string refresh = pApiReq.GetQueryValue(AccessRefreshTokenParam, false);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam, false);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam, false);

			return ExecuteAcc(pApiReq, OauthAccessOperation.GrantTypeRt,
				null, secret, null, refresh, redirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAtcc(IApiRequest pApiReq) {
			string clientId = pApiReq.GetQueryValue(AccessClientIdParam, false);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam, false);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam, false);

			return ExecuteAcc(pApiReq, OauthAccessOperation.GrantTypeCc,
				clientId, secret, null, null, redirUri);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse ExecuteAcc(IApiRequest pApiReq, string pGrantType, string pClientId,
									string pSecret, string pCode, string pRefresh, string pRedirUri) {
			Func<FabOauthAccess> getResp = (() => {
				var op = new OauthAccessOperation();
				return op.Execute(pApiReq.OpCtx, new OauthAccessTasks(), pGrantType, pClientId,
					pSecret, pCode, pRefresh, pRedirUri);
			});

			var exec = new BasicExecutor<FabOauthAccess>(pApiReq, getResp);
			exec.OnException = OnAccessExecption;
			return exec.Execute();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetLogin(IApiRequest pApiReq) {
			string incomingError = pApiReq.GetQueryValue("error", false);

			if ( incomingError != null ) {
				string errDesc = pApiReq.GetQueryValue("error_description", false);

				return new ApiResponse {
					Html = new LoginErrorView(incomingError, errDesc).ToHtml()
				};
			}

			////

			Func<FabOauthLogin> getResp = (() => {
				string respType = pApiReq.GetQueryValue(LoginResponseTypeParam, false);
				string clientId = pApiReq.GetQueryValue(LoginClientIdParam, false);
				string redirUri = pApiReq.GetQueryValue(LoginRedirectUriParam, false);
				string switchMode = pApiReq.GetQueryValue(LoginSwitchModeParam, false);

				var op = new OauthLoginGetOperation();
				return op.Execute(pApiReq.OpCtx, new OauthLoginTasks(),
					clientId, redirUri, respType, switchMode);
			});

			var exec = new BasicExecutor<FabOauthLogin>(pApiReq, getResp);
			exec.OnException = OnLoginException;
			exec.SkipJson = true;
			IApiResponse apiResp = exec.Execute();
			FabOauthLogin res = exec.Result;

			if ( res.ShowLoginPage ) {
				apiResp.Html = new LoginPageView(res).ToHtml();
			}

			if ( res.ScopeCode != null ) {
				apiResp.RedirectUrl = BuildRedirectUri(res.ScopeRedirect, res.ScopeCode,
					pApiReq.GetQueryValue(LoginStateParam, false));
			}

			apiResp.Html = new LoginScopeView(res).ToHtml();
			return apiResp;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse PostLogin(IApiRequest pApiReq) {
			if ( pApiReq.GetFormValue(LoginCancel, false) != null ) {
				return PostLoginCancel(pApiReq);
			}

			if ( pApiReq.GetFormValue(LoginLogout, false) != null ) {
				return PostLoginLogout(pApiReq);
			}

			if ( pApiReq.GetFormValue(LoginLogin, false) != null ) {
				return PostLoginLogin(pApiReq);
			}

			if ( pApiReq.GetFormValue(LoginAllow, false) != null ) {
				return PostLoginScope(pApiReq, true);
			}

			if ( pApiReq.GetFormValue(LoginDeny, false) != null ) {
				return PostLoginScope(pApiReq, false);
			}

			return null;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse PostLoginCancel(IApiRequest pApiReq) {
			Func<FabOauthLogin> getResp = () => {
				var o = new OauthLoginPostOperation();
				o.ExecuteCancel(new OauthLoginTasks());
				return null;
			};

			var exec = new BasicExecutor<FabOauthLogin>(pApiReq, getResp);
			exec.OnException = OnLoginException;
			exec.SkipJson = true;
			return exec.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse PostLoginLogout(IApiRequest pApiReq) {
			var apiResp = new ApiResponse();
			apiResp.RedirectUrl = pApiReq.Path;
			apiResp.SetUserCookie(null, false);
			return apiResp;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse PostLoginLogin(IApiRequest pApiReq) {
			bool remember = false;

			Func<FabOauthLogin> getResp = () => {
				string user = pApiReq.GetFormValue(LoginUsername, true);
				string pass = pApiReq.GetFormValue(LoginPassword, true);
				remember = (pApiReq.GetFormValue(LoginRememberMe, false) == "1");

				string clientId = pApiReq.GetQueryValue(LoginClientIdParam, false);
				string redirUri = pApiReq.GetQueryValue(LoginRedirectUriParam, false);

				var op = new OauthLoginPostOperation();
				return op.ExecuteLogin(pApiReq.OpCtx, new OauthLoginTasks(),
					clientId, redirUri, user, pass);
			};

			var exec = new BasicExecutor<FabOauthLogin>(pApiReq, getResp);
			exec.OnException = OnLoginException;
			exec.SkipJson = true;
			IApiResponse apiResp = exec.Execute();
			FabOauthLogin res = exec.Result;

			if ( res.ShowLoginPage ) {
				apiResp.Html = new LoginPageView(res).ToHtml();
				return apiResp;
			}

			if ( res.ScopeCode != null ) {
				apiResp.RedirectUrl = BuildRedirectUri(res.ScopeRedirect, res.ScopeCode,
					pApiReq.GetQueryValue(LoginStateParam, false));
			}
			else {
				apiResp.Html = new LoginScopeView(res).ToHtml();
			}

			apiResp.SetUserCookie(res.LoggedUserId, remember);
			return apiResp;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse PostLoginScope(IApiRequest pApiReq, bool pAllow) {
			Func<FabOauthLogin> getResp = () => {
				string client = pApiReq.GetQueryValue(LoginClientIdParam, false);
				string redirUri = pApiReq.GetQueryValue(LoginRedirectUriParam, false);

				var op = new OauthLoginPostOperation();
				return op.ExecuteScope(pApiReq.OpCtx, new OauthLoginTasks(), client, redirUri, pAllow);
			};

			var exec = new BasicExecutor<FabOauthLogin>(pApiReq, getResp);
			exec.OnException = OnLoginException;
			exec.SkipJson = true;
			IApiResponse apiResp = exec.Execute();

			apiResp.RedirectUrl = BuildRedirectUri(
				exec.Result.ScopeRedirect, 
				exec.Result.ScopeCode,
				pApiReq.GetQueryValue(LoginStateParam, false)
			);

			return apiResp;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetLogout(IApiRequest pApiReq) {
			Func<FabOauthLogout> getResp = (() => {
				string token = pApiReq.GetQueryValue(LogoutAccessTokenParam, false);

				var op = new OauthLogoutOperation();
				return op.Execute(pApiReq.OpCtx, new OauthLogoutTasks(), token);
			});

			var exec = new BasicExecutor<FabOauthLogout>(pApiReq, getResp);
			return exec.Execute();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static string BuildRedirectUri(string pRedir, string pCode, string pState) {
			return pRedir+"?code="+pCode+"&state="+pState;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string BuildRedirectUri(FabOauthError pErr, string pRedir, string pState) {
			return pRedir+"?error="+pErr.Error+"&error_description="+
				pErr.ErrorDesc.Replace(' ', '+')+"&state="+pState;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static bool OnLoginException(IApiRequest pReq, IApiResponse pResp, Exception pEx) {
			FabOauthError fabErr;

			if ( pEx is OauthException ) {
				fabErr = (pEx as OauthException).OauthError;
			}
			else {
				fabErr = FabOauthError.ForInternalServerError();
			}

			string redirUri = pReq.GetQueryValue(LoginRedirectUriParam, false);
			string state = pReq.GetQueryValue(LoginStateParam, false);
			pResp.RedirectUrl = BuildRedirectUri(fabErr, redirUri, state);
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static bool OnAccessExecption(IApiRequest pReq, IApiResponse pResp, Exception pEx) {
			FabOauthError fabErr;

			if ( pEx is OauthException ) {
				fabErr = (pEx as OauthException).OauthError;
			}
			else {
				fabErr = FabOauthError.ForInternalServerError();
			}

			pResp.Status = System.Net.HttpStatusCode.Forbidden;
			pResp.Json = fabErr.ToJson();
			return true;
		}

	}

}