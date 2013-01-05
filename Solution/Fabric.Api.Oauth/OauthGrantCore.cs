using System;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth {

	/*================================================================================================*/
	public enum GrantErrors { //from section "4.1.2.1. Error Response"
		invalid_request,
		unauthorized_client,
		access_denied,
		unsupported_response_type,
		invalid_scope,
		server_error,
		temporarily_unavailable
	};

	/*================================================================================================*/
	public enum GrantErrorDescs {
		LoginCancel = 0,
		AccessDeny,
		BadRespType,
		NoRedirUri,
		BadRedirUri,
		NoClient,
		BadClient,
		RedirMismatch,
		BadSwitch,
		Unexpected
	};

	/*================================================================================================*/
	public class OauthGrantCore : IOauthGrantCore { //TEST: OauthGrantCore

		public static string[] ErrDescStrings = new [] {
			"Login cancelled by user",
			"Access request denied by user",
			"The response_type is invalid",
			"The redirect_uri was not supplied",
			"The redirect_uri must be an absolute path",
			"A numeric client_id was not supplied",
			"The client_id is invalid",
			"The redirect_uri is not valid for the client_id",
			"The optional switch value must be 0 or 1.",
			"An unexpected error occurred"
		};

		public string ClientId { get; private set; }
		public string RedirectUri { get; private set; }
		public long LoggedUserId { get; private set; }

		public long AppId { get; private set; }
		public long? UserId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantCore() {}

		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantCore(string pClientId, string pRedirectUri, long pLoggedUserId) {
			ClientId = pClientId;
			RedirectUri = pRedirectUri;
			LoggedUserId = pLoggedUserId;

			if ( !String.IsNullOrEmpty(ClientId) ) {
				uint appId;
				
				if ( uint.TryParse(ClientId, out appId) ) {
					AppId = appId;
				}
			}

			if ( LoggedUserId > 0 ) {
				UserId = LoggedUserId;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetUserId(long? pUserId) {
			UserId = pUserId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public App GetApp(IApiContext pContext) {
			var app = new App { AppId = AppId };
			app = pContext.DbSingle<App>("GetApp", ApiFunc.NewNodeQuery(app));

			if ( app == null ) {
				throw GetFault(GrantErrors.unauthorized_client, GrantErrorDescs.BadClient);
			}

			return app;
		}

		/*--------------------------------------------------------------------------------------------*/
		public User GetUser(IApiContext pContext) {
			if ( UserId == null || UserId <= 0 ) {
				return null;
			}

			var user = new User { UserId = (long)UserId };
			return pContext.DbSingle<User>("GetUser", ApiFunc.NewNodeQuery(user));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LoginScopeResult GetGrantCodeIfScopeAlreadyAllowed(
															IOauthTasks pTasks, IApiContext pContext) {
			if ( UserId == null ) {
				return null;
			}

			ScopeResult os = pTasks.GetScope(AppId, (long)UserId, pContext);
			
			if ( os == null || !os.Allow ) {
				return null;
			}

			return AddGrantCode(true, pTasks, pContext);
		}

		/*--------------------------------------------------------------------------------------------*/
		public LoginScopeResult AddGrantCode(
									bool pScopeAlreadyAdded, IOauthTasks pTasks, IApiContext pContext) {
			if ( UserId == null ) {
				return null;
			}
			
			pTasks.AddMemberEnsure(AppId, (long)UserId, pContext);

			if ( !pScopeAlreadyAdded ) {
				pTasks.AddScope(AppId, (long)UserId, true, pContext);
			}

			string code = pTasks.AddGrant(AppId, (long)UserId, RedirectUri, pContext);

			var s = new LoginScopeResult();
			s.Redirect = RedirectUri;
			s.Code = code;
			return s;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthException GetFaultOnException(Exception pEx) {
			Log.Error("OauthGrantBase", pEx);
			return GetFault(GrantErrors.invalid_request, GrantErrorDescs.Unexpected);
		}

		/*--------------------------------------------------------------------------------------------*/
		public OauthException GetFault(GrantErrors pErr, GrantErrorDescs pDesc) {
			return new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static OauthException GetFaultStatic(GrantErrors pErr, GrantErrorDescs pDesc) {
			return new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}