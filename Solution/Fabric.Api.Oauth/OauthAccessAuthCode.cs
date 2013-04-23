using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;

namespace Fabric.Api.Oauth {

	/*================================================================================================*/
	public class OauthAccessAuthCode : OauthAccessBase {

		private readonly string vCode;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessAuthCode(string pGrantType, string pRedirectUri, string pClientSecret,
												string pCode, IOauthTasks pTasks) : 
												base(pGrantType, pRedirectUri, pClientSecret, pTasks) {
			vCode = pCode;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override bool VerifyGrantType() {
			return (vGrantType == "authorization_code");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void RedirectOnParamErrors() {
			base.RedirectOnParamErrors();

			if ( vCode == null || vCode.Length <= 0 ) {
				throw GetFault(AccessErrors.invalid_request, AccessErrorDescs.NoCode);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthAccess PerformAccessRequestActions() {
			GrantResult g = vTasks.GetGrant(vCode, ApiCtx);

			if ( g == null ) {
				throw GetFault(AccessErrors.invalid_grant, AccessErrorDescs.BadCode);
			}

			if ( vRedirectUri != g.RedirectUri ) {
				throw GetFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
			}

			return SendAccessCode(g.AppId, g.UserId);
		}

	}

}