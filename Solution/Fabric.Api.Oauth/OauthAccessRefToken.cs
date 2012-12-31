namespace Fabric.Api.Oauth {


	/*================================================================================================*/
	public class OauthAccess_RefToken : OauthAccess {

		private readonly string vRefreshToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccess_RefToken(string pGrantType, string pRedirectUri, string pClientSecret,
								string pRefreshToken) : base(pGrantType, pRedirectUri, pClientSecret) {
			vRefreshToken = pRefreshToken;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool VerifyGrantType() {
			return (vGrantType == "refresh_token");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void PerformAccessRequestActions() {
			SendRefreshedAccessToken();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool RedirectOnParamErrors() {
			//do not call base.redirectOnParamErrors()

			if ( !VerifyGrantType() ) {
				ThrowFault(AccessErrors.unsupported_grant_type, AccessErrorDescs.BadGrantType);
				return true;
			}

			if ( vClientSecret == null || vClientSecret.Length <= 0 ) {
				ThrowFault(AccessErrors.invalid_request, AccessErrorDescs.NoClientSecret);
				return true;
			}

			if ( vRefreshToken == null || vRefreshToken.Length <= 0 ) {
				ThrowFault(AccessErrors.invalid_request, AccessErrorDescs.NoRefresh);
				return true;
			}

			return false;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void SendRefreshedAccessToken() {
			OauthRefreshResult orr = new GetRefresh(vRefreshToken).Go(Context);

			if ( orr == null ) {
				ThrowFault(AccessErrors.invalid_request, AccessErrorDescs.BadRefresh);
				return;
			}

			VerifyAppWithSecret(orr.appId);

			var ak = new FabAppKey(orr.appId);
			var pk = new FabUserKey(orr.userId);
			OAuthAccessResult oar = new AddAccess(ak, pk, 3600, false).Go(Context);

			var oa = new FabOauthAccess();
			oa.access_token = oar.Token;
			oa.token_type = "bearer";
			oa.expires_in = oar.ExpireSec+"";
			oa.refresh_token = oar.Refresh;

			SetResult(oa);
		}

	}

}