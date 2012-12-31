using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;

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
	public abstract class OauthAccessBase : ApiFunc<FabOauthAccess> { //TEST: OauthAccessBase

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
		protected OauthAccessBase(string pGrantType, string pRedirectUri, string pClientSecret) {
			vGrantType = pGrantType;
			vRedirectUri = pRedirectUri;
			vClientSecret = pClientSecret;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			RedirectOnParamErrors();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract bool VerifyGrantType();

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void RedirectOnParamErrors() {
			if ( !VerifyGrantType() ) {
				throw GetFault(AccessErrors.unsupported_grant_type, AccessErrorDescs.BadGrantType);
			}

			if ( vClientSecret == null || vClientSecret.Length <= 0 ) {
				throw GetFault(AccessErrors.invalid_request, AccessErrorDescs.NoClientSecret);
			}

			if ( vRedirectUri == null || vRedirectUri.Length <= 0 ) {
				throw GetFault(AccessErrors.invalid_request, AccessErrorDescs.NoRedirUri);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthAccess Execute() {
			try {
				return PerformAccessRequestActions();
			}
			catch ( OauthException ) {
				throw;
			}
			catch ( Exception e ) {
				throw GetFaultOnException(e);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract FabOauthAccess PerformAccessRequestActions();
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabOauthAccess SendAccessCode(long pAppId, long? pUserId, bool pClientMode=false) {
			long appId = VerifyAppWithSecret(pAppId);

			FabOauthAccess oa = new AddAccess(appId, pUserId, 3600, pClientMode).Go(Context);
			
			if ( pClientMode ) {
				oa.RefreshToken = null;
			}
			
			return oa;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected long VerifyAppWithSecret(long pAppId) {
			App app = new GetAppAuth(pAppId, vClientSecret).Go(Context);

			if ( app == null ) {
				throw GetFault(AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
			}

			return app.AppId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected OauthException GetFaultOnException(Exception pEx) {
			Log.Error("FOAuthAccess", pEx);
			return GetFault(AccessErrors.invalid_request, AccessErrorDescs.Unexpected);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected OauthException GetFault(AccessErrors pErr, AccessErrorDescs pDesc) {
			throw new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}