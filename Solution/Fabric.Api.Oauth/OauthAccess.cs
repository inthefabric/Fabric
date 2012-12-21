using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth {

	/*================================================================================================*/
	public enum AccessErrors { //from section "5.2. Error Response"
		invalid_request,
		invalid_client,
		invalid_grant,
		unauthorized_client,
		unsupported_grant_type,
		invalid_scope
	};

	/*================================================================================================*/
	public enum AccessErrorDescs {
		BadGrantType = 0,
		NoRedirUri,
		BadRedirUri,
		NoCode,
		NoRefresh,
		NoClientId,
		NoClientSecret,
		BadCode,
		BadRefresh,
		RedirMismatch,
		BadClientSecret,
		NoDataProvId,
		BadDataProvId,
		Unexpected
	};

	/*================================================================================================*/
	public abstract class OauthAccess : ActiveFunc<FabOauthAccess> {

		public static string[] ErrDescStrings = new [] {
			"The grant_type is invalid",
			"The redirect_uri was not supplied",
			"The redirect_uri must be an absolute path",
			"The code was not supplied",
			"The refresh_token was not supplied",
			"The client_id was not supplied",
			"The client_secret was not supplied",
			"The code is invalid or expired",
			"The refresh_token is invalid or expired",
			"The redirect_uri does not match this code",
			"The app_secret does not match the client_id",
			"The data_prov_userid was not supplied.",
			"The data_prov_userid does not match the client_id",
			"An unexpected error occurred"
		};

		protected string vGrantType;
		protected string vRedirectUri;
		protected string vClientSecret;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected OauthAccess(string pGrantType, string pRedirectUri, string pClientSecret)
																				: base(AuthType.None) {
			vGrantType = pGrantType;
			vRedirectUri = pRedirectUri;
			vClientSecret = pClientSecret;

			AddTransactionFunc(GetAccess);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			RedirectOnParamErrors();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract bool VerifyGrantType();

		/*--------------------------------------------------------------------------------------------*/
		protected virtual bool RedirectOnParamErrors() {
			if ( !VerifyGrantType() ) {
				ThrowFault(AccessErrors.unsupported_grant_type, AccessErrorDescs.BadGrantType);
				return true;
			}

			if ( vClientSecret == null || vClientSecret.Length <= 0 ) {
				ThrowFault(AccessErrors.invalid_request, AccessErrorDescs.NoClientSecret);
				return true;
			}

			if ( vRedirectUri == null || vRedirectUri.Length <= 0 ) {
				ThrowFault(AccessErrors.invalid_request, AccessErrorDescs.NoRedirUri);
				return true;
			}

			return false;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void GetAccess(ISession pSession) {
			try {
				PerformAccessRequestActions();
			}
			catch ( OauthException ) {
				throw;
			}
			catch ( Exception e ) {
				ThrowFaultOnException(e);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void PerformAccessRequestActions();
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void SendAccessCode(uint pAppId, uint? pUserId, bool pClientMode=false) {
			FabAppKey ak = VerifyAppWithSecret(pAppId);

			FabUserKey perKey = (pUserId == null ? null : new FabUserKey((uint)pUserId));
			OAuthAccessResult oar =
				new AddAccess(ak, perKey, 3600, pClientMode).Go(Context);

			var oa = new FabOauthAccess();
			oa.access_token = oar.Token;
			oa.token_type = "bearer";
			oa.expires_in = oar.ExpireSec+"";
			oa.refresh_token = (pClientMode ? null : oar.Refresh);

			SetResult(oa);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected FabAppKey VerifyAppWithSecret(uint pAppId) {
			FabAppKey ak = new FAuthApp_Get(pAppId, vClientSecret).Go(Context);

			if ( ak == null ) {
				ThrowFault(AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
			}

			return ak;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void ThrowFaultOnException(Exception pEx) {
			Log.Error("FOAuthAccess", pEx);
			ThrowFault(AccessErrors.invalid_request, AccessErrorDescs.Unexpected);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected void ThrowFault(AccessErrors pErr, AccessErrorDescs pDesc) {
			throw new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}