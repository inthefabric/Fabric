using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;

namespace Fabric.Api.Oauth {

	/*================================================================================================*/
	public class OauthAccessClientCred : OauthAccessBase {

		protected readonly string vClientIdStr;
		protected long vClientId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessClientCred(string pGrantType, string pRedirectUri, string pClientSecret,
												string pClientId, IOauthTasks pTasks) : 
												base(pGrantType, pRedirectUri, pClientSecret, pTasks) {
			vClientIdStr = pClientId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool VerifyGrantType() {
			return (vGrantType == "client_credentials");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void RedirectOnParamErrors() {
			base.RedirectOnParamErrors();

			bool parsed = long.TryParse(vClientIdStr, out vClientId);

			if ( !parsed || vClientId <= 0 ) {
				throw GetFault(AccessErrors.invalid_client, AccessErrorDescs.NoClientId);
			}

			if ( vRedirectUri.IndexOf("://") <= 0 ) {
				throw GetFault(AccessErrors.invalid_grant, AccessErrorDescs.BadRedirUri);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthAccess PerformAccessRequestActions() {
			RedirectOnBadDomain();
			return SendAccessCode(vClientId, null, true);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void RedirectOnBadDomain() {
			DomainResult dom = vTasks.GetDomain(vClientId, vRedirectUri, ApiCtx);

			if ( dom == null ) {
				throw GetFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
			}
		}

	}

}