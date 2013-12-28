using System;
using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Operations.Oauth.Access;

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
			new ApiEntryParam(AccessGrantTypeParam, typeof(string), false, AccessLang+"GrantType"),
			new ApiEntryParam(AccessClientIdParam, typeof(long), true, AccessLang+"ClientId"),
			new ApiEntryParam(AccessClientSecretParam, typeof(string), true, AccessLang+"Secret"),
			new ApiEntryParam(AccessCodeParam, typeof(string), true, AccessLang+"Code"),
			new ApiEntryParam(AccessRefreshTokenParam, typeof(string), true, AccessLang+"Refresh"),
			new ApiEntryParam(AccessRedirectUriParam, typeof(string), true, AccessLang+"RedirectUri"),
			new ApiEntryParam(AccessDataProvUserIdParam, typeof(long), true, AccessLang+"DataProvId")
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

		private static readonly IList<ApiEntryParam> AtcdParams = new List<ApiEntryParam> {
			new ApiEntryParam(AccessDataProvUserIdParam, typeof(long), false, AccessLang+"DataProvId")
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
			string grant = pApiReq.GetQueryValue(AccessGrantTypeParam);
			string clientId = pApiReq.GetQueryValue(AccessClientIdParam, true);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam, true);
			string code = pApiReq.GetQueryValue(AccessCodeParam, true);
			string refresh = pApiReq.GetQueryValue(AccessRefreshTokenParam, true);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam, true);
			string dataProvId = pApiReq.GetQueryValue(AccessDataProvUserIdParam, true);

			return ExecuteAcc(pApiReq, grant, clientId, secret, code, refresh, redirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAtac(IApiRequest pApiReq) {
			string code = pApiReq.GetQueryValue(AccessCodeParam);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam);

			return ExecuteAcc(pApiReq, OauthAccessOperation.GrantTypeAc,
				null, secret, code, null, redirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAtr(IApiRequest pApiReq) {
			string refresh = pApiReq.GetQueryValue(AccessRefreshTokenParam);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam);

			return ExecuteAcc(pApiReq, OauthAccessOperation.GrantTypeRt,
				null, secret, null, refresh, redirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetAtcc(IApiRequest pApiReq) {
			string clientId = pApiReq.GetQueryValue(AccessClientIdParam);
			string secret = pApiReq.GetQueryValue(AccessClientSecretParam);
			string redirUri = pApiReq.GetQueryValue(AccessRedirectUriParam);

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
				string cancel = pApiReq.GetFormValue(LoginCancel, true);
				string logout = pApiReq.GetFormValue(LoginLogout, true);
				string login = pApiReq.GetFormValue(LoginLogin, true);
				string allow = pApiReq.GetFormValue(LoginAllow, true);
				string deny = pApiReq.GetFormValue(LoginDeny, true);

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