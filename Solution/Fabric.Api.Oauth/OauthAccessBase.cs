using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
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
	public abstract class OauthAccessBase : ApiFunc<FabOauthAccess> {

		public static readonly string[] ErrDescStrings = new [] {
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

		protected readonly string vGrantType;
		protected readonly string vRedirectUri;
		protected readonly string vClientSecret;
		protected readonly IOauthTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected OauthAccessBase(string pGrantType, string pRedirectUri, string pClientSecret,
																				IOauthTasks pTasks) {
			vGrantType = pGrantType;
			vRedirectUri = pRedirectUri;
			vClientSecret = pClientSecret;
			vTasks = pTasks;
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
				Log.Error("OAuthAccessBase", e);
				throw GetFault(AccessErrors.invalid_request, AccessErrorDescs.Unexpected);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract FabOauthAccess PerformAccessRequestActions();
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabOauthAccess SendAccessCode(long pAppId, long? pUserId, bool pClientMode=false) {
			long appId = VerifyAppWithSecret(pAppId);

			FabOauthAccess oa = vTasks.AddAccess(appId, pUserId, 3600, pClientMode, Context);
			
			if ( pClientMode ) {
				oa.RefreshToken = null;
			}
			
			return oa;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private long VerifyAppWithSecret(long pAppId) {
			App app = vTasks.GetAppAuth(pAppId, vClientSecret, Context);

			if ( app == null ) {
				throw GetFault(AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
			}

			return app.AppId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected OauthException GetFault(AccessErrors pErr, AccessErrorDescs pDesc) {
			return new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}