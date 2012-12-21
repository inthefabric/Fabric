using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Oauth {


	/*================================================================================================*/
	public class OauthAccess_AuthCode : OauthAccess {

		protected string vCode;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccess_AuthCode(string pGrantType, string pRedirectUri, string pClientSecret,
										string pCode) : base(pGrantType, pRedirectUri, pClientSecret) {
			vCode = pCode;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override bool VerifyGrantType() {
			return (vGrantType == "authorization_code");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool RedirectOnParamErrors() {
			if ( base.RedirectOnParamErrors() ) {
				return true;
			}

			if ( vCode == null || vCode.Length <= 0 ) {
				ThrowFault(AccessErrors.invalid_request, AccessErrorDescs.NoCode);
				return true;
			}

			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void PerformAccessRequestActions() {
			FabOauthGrant g = new FOauthGrant_Get(vCode).Go(Context);

			if ( g == null ) {
				ThrowFault(AccessErrors.invalid_grant, AccessErrorDescs.BadCode);
				return;
			}

			if ( vRedirectUri != g.RedirectUri ) {
				ThrowFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
				return;
			}

			SendAccessCode(g.AppKey.Id, g.UserKey.Id);
		}

	}

}