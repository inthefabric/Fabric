using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;

namespace Fabric.Api.Oauth {

	/*================================================================================================*/
	public class OauthAccessRefToken : OauthAccessBase {

		private readonly string vRefreshToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessRefToken(string pGrantType, string pRedirectUri, string pClientSecret,
												string pRefreshToken, IOauthTasks pTasks) :
												base(pGrantType, pRedirectUri, pClientSecret, pTasks) {
			vRefreshToken = pRefreshToken;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool VerifyGrantType() {
			return (vGrantType == "refresh_token");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void RedirectOnParamErrors() {
			base.RedirectOnParamErrors();

			//NOTE: Original implementation purposefully skipped RequestUri validation. Why?

			if ( vRefreshToken == null || vRefreshToken.Length <= 0 ) {
				throw GetFault(AccessErrors.invalid_request, AccessErrorDescs.NoRefresh);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthAccess PerformAccessRequestActions() {
			RefreshResult orr = vTasks.GetRefresh(vRefreshToken, Context);

			if ( orr == null ) {
				throw GetFault(AccessErrors.invalid_request, AccessErrorDescs.BadRefresh);
			}

			return SendAccessCode(orr.AppId, orr.UserId);
		}

	}

}