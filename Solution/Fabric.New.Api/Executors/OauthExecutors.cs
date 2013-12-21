﻿using System;
using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Operations.Oauth;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class OauthExecutors {

		private static readonly string Uri = ApiMenu.Oauth.Uri;

		private const string AccessGrantTypeAc = "authorization_code";
		private const string AccessGrantTypeCc = "client_credentials";
		private const string AccessGrantTypeCd = "client_dataprov";
		private const string AccessGrantTypeR = "refresh_token";

		private const string AccessGrantTypeParam = "grant_type";
		private const string AccessClientIdParam = "client_id";
		private const string AccessClientSecretParam = "client_secret";
		private const string AccessCodeParam = "code";
		private const string AccessRefreshTokenParam = "refresh_token";
		private const string AccessRedirectUriParam = "redirect_uri";
		private const string AccessDataProvUserIdParam = "data_prov_userid";

		private const string LoginResponseTypeParam = "response_type";
		private const string LoginClientIdParam = "client_id";
		private const string LoginRedirectUriParam = "redirect_uri";
		private const string LoginScopeParam = "scope";
		private const string LoginStateParam = "state";
		private const string LoginSwitchModeParam = "switchMode";

		private const string LoginCancel = "cancel";
		private const string LoginLogout = "logout";
		private const string LoginLogin = "login";
		private const string LoginAllow = "allow";
		private const string LoginDeny = "deny";

		private const string LogoutAccessTokenParam = "access_token";

		private static readonly IList<ApiEntryParam> AtParams = new List<ApiEntryParam> {
			new ApiEntryParam(AccessGrantTypeParam, typeof(string)),
			new ApiEntryParam(AccessClientIdParam, typeof(long), true),
			new ApiEntryParam(AccessClientSecretParam, typeof(string), true),
			new ApiEntryParam(AccessCodeParam, typeof(string), true),
			new ApiEntryParam(AccessRefreshTokenParam, typeof(string), true),
			new ApiEntryParam(AccessRedirectUriParam, typeof(string), true),
			new ApiEntryParam(AccessDataProvUserIdParam, typeof(long), true)
		};

		private static readonly IList<ApiEntryParam> AtacParams = new List<ApiEntryParam> {
			new ApiEntryParam(AccessCodeParam, typeof(string)),
			new ApiEntryParam(AccessClientSecretParam, typeof(string)),
			new ApiEntryParam(AccessRedirectUriParam, typeof(string))
		};

		private static readonly IList<ApiEntryParam> AtrParams = new List<ApiEntryParam> {
			new ApiEntryParam(AccessRefreshTokenParam, typeof(string)),
			new ApiEntryParam(AccessClientSecretParam, typeof(string)),
			new ApiEntryParam(AccessRedirectUriParam, typeof(string))
		};

		private static readonly IList<ApiEntryParam> AtccParams = new List<ApiEntryParam> {
			new ApiEntryParam(AccessClientIdParam, typeof(long)),
			new ApiEntryParam(AccessClientSecretParam, typeof(string)),
			new ApiEntryParam(AccessRedirectUriParam, typeof(string))
		};

		private static readonly IList<ApiEntryParam> AtcdParams = new List<ApiEntryParam> {
			new ApiEntryParam(AccessDataProvUserIdParam, typeof(long))
		};

		private static readonly IList<ApiEntryParam> GetLoginParams = new List<ApiEntryParam> {
			new ApiEntryParam(LoginResponseTypeParam, typeof(string)),
			new ApiEntryParam(LoginClientIdParam, typeof(string)),
			new ApiEntryParam(LoginRedirectUriParam, typeof(string)),
			new ApiEntryParam(LoginScopeParam, typeof(string)),
			new ApiEntryParam(LoginStateParam, typeof(string)),
			new ApiEntryParam(LoginSwitchModeParam, typeof(string))
		};

		private static readonly IList<ApiEntryParam> PostLoginParams = new List<ApiEntryParam> {
			new ApiEntryParam(LoginCancel, typeof(string), true),
			new ApiEntryParam(LoginLogout, typeof(string), true),
			new ApiEntryParam(LoginLogin, typeof(string), true),
			new ApiEntryParam(LoginAllow, typeof(string), true),
			new ApiEntryParam(LoginDeny, typeof(string), true)
		};

		private static readonly IList<ApiEntryParam> GetLogoutParams = new List<ApiEntryParam> {
			new ApiEntryParam(LogoutAccessTokenParam, typeof(string))
		};

		public static readonly ApiEntry[] ApiEntries = new[] {
			ApiEntry.Get(Uri+ApiMenu.OauthAt.Uri, GetAt, typeof(FabOauthAccess), AtParams),
			ApiEntry.Get(Uri+ApiMenu.OauthAtac.Uri, GetAtac, typeof(FabOauthAccess), AtacParams),
			ApiEntry.Get(Uri+ApiMenu.OauthAtr.Uri, GetAtr, typeof(FabOauthAccess), AtrParams),
			ApiEntry.Get(Uri+ApiMenu.OauthAtcc.Uri, GetAtcc, typeof(FabOauthAccess), AtccParams),
			ApiEntry.Get(Uri+ApiMenu.OauthAtcd.Uri, GetAtcd, typeof(FabOauthAccess), AtcdParams),
			ApiEntry.Get(Uri+ApiMenu.OauthLogin.Uri, GetLogin, typeof(FabOauthLogin), GetLoginParams),
			ApiEntry.Post(Uri+ApiMenu.OauthLogin.Uri, PostLogin,
				typeof(FabOauthLogin), PostLoginParams),
			ApiEntry.Get(Uri+ApiMenu.OauthLogout.Uri, GetLogout,
				typeof(FabOauthLogout), GetLogoutParams),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAt(IApiRequest pApiReq) {
			string grant = pApiReq.GetQueryValue(AccessGrantTypeParam);
			string clientId = pApiReq.GetQueryValue(AccessClientIdParam);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam);
			string code = pApiReq.GetQueryValue(AccessCodeParam);
			string refresh = pApiReq.GetQueryValue(AccessRefreshTokenParam);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam);
			string dataProvId = pApiReq.GetQueryValue(AccessDataProvUserIdParam);

			return ExecuteAcc(pApiReq, grant, clientId, secret, code, refresh, redirUri, dataProvId);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAtac(IApiRequest pApiReq) {
			string code = pApiReq.GetQueryValue(AccessCodeParam);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam);

			return ExecuteAcc(pApiReq, AccessGrantTypeAc, null, secret, code, null, redirUri, null);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAtr(IApiRequest pApiReq) {
			string refresh = pApiReq.GetQueryValue(AccessRefreshTokenParam);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam);

			return ExecuteAcc(pApiReq, AccessGrantTypeR, null, secret, null, refresh, redirUri, null);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAtcc(IApiRequest pApiReq) {
			string clientId = pApiReq.GetQueryValue(AccessClientIdParam);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam);

			return ExecuteAcc(pApiReq, AccessGrantTypeCc, clientId, secret, null, null, redirUri, null);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAtcd(IApiRequest pApiReq) {
			string dataProvId = pApiReq.GetQueryValue(AccessDataProvUserIdParam);

			return ExecuteAcc(pApiReq, AccessGrantTypeCd, null, null, null, null, null, dataProvId);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse ExecuteAcc(IApiRequest pApiReq, string pGrantType, string pClientId,
														string pSecret, string pCode, string pRefresh,
														string pRedirUri, string pDataProvId) {
			Func<FabOauthAccess> getResp = (() => {
				var o = new OauthAccessOperation();
				return o.Execute(pApiReq.OpCtx, pGrantType, pClientId,
					pSecret, pCode, pRefresh, pRedirUri, pDataProvId);
			});

			var exec = new BasicExecutor<FabOauthAccess>(pApiReq, getResp);
			return exec.Execute();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetLogin(IApiRequest pApiReq) {
			string respType = pApiReq.GetQueryValue(LoginResponseTypeParam);
			string clientId = pApiReq.GetQueryValue(LoginClientIdParam);
			string redirUri = pApiReq.GetQueryValue(LoginRedirectUriParam);
			string scope = pApiReq.GetQueryValue(LoginScopeParam);
			string state = pApiReq.GetQueryValue(LoginStateParam);
			string switchMode = pApiReq.GetQueryValue(LoginSwitchModeParam);

			return null; //TODO: return HTML login page
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse PostLogin(IApiRequest pApiReq) {
			Func<FabOauthLogin> getResp = (() => {
				string cancel = pApiReq.GetFormValue(LoginCancel);
				string logout = pApiReq.GetFormValue(LoginLogout);
				string login = pApiReq.GetFormValue(LoginLogin);
				string allow = pApiReq.GetFormValue(LoginAllow);
				string deny = pApiReq.GetFormValue(LoginDeny);

				//var o = new OauthLoginOperation();
				//return o.Execute(pApiReq.OpCtx, cancel, logout, login, allow, deny);
				return new FabOauthLogin();
			});

			var exec = new BasicExecutor<FabOauthLogin>(pApiReq, getResp);
			return exec.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetLogout(IApiRequest pApiReq) {
			Func<FabOauthLogout> getResp = (() => {
				string token = pApiReq.GetQueryValue(LogoutAccessTokenParam);

				//var o = new OauthLogoutOperation();
				//return o.Execute(pApiReq.OpCtx, token);
				return new FabOauthLogout();
			});

			var exec = new BasicExecutor<FabOauthLogout>(pApiReq, getResp);
			return exec.Execute();
		}

	}

}