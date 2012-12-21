using System;
using Fabric.Api.Dto;
using Fabric.Infrastructure;

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
	public class OauthGrant_Core {

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
		public uint LoggedUserId { get; private set; }

		public FabAppKey AppKey { get; private set; }
		public FabUserKey UserKey { get; private set; }

		public ISvcContext Context { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrant_Core() {}

		/*--------------------------------------------------------------------------------------------*/
		public OauthGrant_Core(string pClientId, string pRedirectUri, uint pLoggedUserId) {
			ClientId = pClientId;
			RedirectUri = pRedirectUri;
			LoggedUserId = pLoggedUserId;

			if ( !String.IsNullOrEmpty(ClientId) ) {
				uint appId;
				if ( uint.TryParse(ClientId, out appId) ) { AppKey = new FabAppKey(appId); }
			}

			UserKey = (LoggedUserId > 0 ? new FabUserKey(LoggedUserId) : null);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetUserKeyId(uint pUserId) {
			UserKey = new FabUserKey(pUserId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabApp GetApp() {
			//if ( AppKey == null || AppKey.Id <= 0 ) { return null; }
			FabApp app;

			try {
				app = new FApp_Get(AppKey).Go(Context);
			}
			catch ( Exception ) {
				app = null;
			}

			if ( app == null ) {
				ThrowFault(GrantErrors.unauthorized_client, GrantErrorDescs.BadClient);
			}

			return app;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabUser GetUser() {
			if ( UserKey == null || UserKey.Id <= 0 ) { return null; }
			return new FUser_Get(UserKey).Go(Context);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthLoginScope GetGrantCodeIfScopeAlreadyAllowed() {
			if ( UserKey == null ) { return null; }

			FabOauthScope os = new GetScope(AppKey, UserKey).Go(Context);
			if ( os == null || !os.Allow ) { return null; }

			return AddGrantCode(true);
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabOauthLoginScope AddGrantCode(bool pScopeAlreadyAdded) {
			new AddMemberEnsure(AppKey, UserKey).Go(Context);

			if ( !pScopeAlreadyAdded ) {
				new AddScope(AppKey, UserKey, true).Go(Context);
			}

			string code = new AddGrant(AppKey, UserKey, RedirectUri).Go(Context);

			var s = new FabOauthLoginScope();
			s.Redirect = RedirectUri;
			s.Code = code;
			return s;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ThrowFaultOnException(Exception pEx) {
			Log.Error("FOauthGrant", pEx);
			ThrowFault(GrantErrors.invalid_request, GrantErrorDescs.Unexpected);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ThrowFault(GrantErrors pErr, GrantErrorDescs pDesc) {
			throw new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ThrowFaultStatic(GrantErrors pErr, GrantErrorDescs pDesc) {
			throw new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}