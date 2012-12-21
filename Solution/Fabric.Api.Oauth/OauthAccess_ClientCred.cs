using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;

namespace Fabric.Api.Oauth {

	/*================================================================================================*/
	public class OauthAccess_ClientCred : OauthAccess {

		protected string vClientIdStr;
		protected uint vClientId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccess_ClientCred(string pGrantType, string pRedirectUri, string pClientSecret,
									string pClientId) : base(pGrantType, pRedirectUri, pClientSecret) {
			vClientIdStr = pClientId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool VerifyGrantType() {
			return (vGrantType == "client_credentials");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool RedirectOnParamErrors() {
			if ( base.RedirectOnParamErrors() ) {
				return true;
			}

			bool parsed = uint.TryParse(vClientIdStr, out vClientId);

			if ( !parsed || vClientId <= 0 ) {
				ThrowFault(AccessErrors.invalid_client, AccessErrorDescs.NoClientId);
				return true;
			}

			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void PerformAccessRequestActions() {
			if ( RedirectOnBadDomain() ) { return; }
			SendAccessCode(vClientId, null, true);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected bool RedirectOnBadDomain() {
			FabOauthDomain dom;
			
			if ( vRedirectUri.IndexOf("://") <= 0 ) {
				ThrowFault(AccessErrors.invalid_grant, AccessErrorDescs.BadRedirUri);
				return true;
			}

			try {
				dom = new GetDomain(new FabAppKey(vClientId), vRedirectUri).Go(Context);
			}
			catch ( Exception e ) { ThrowFaultOnException(e); return true; }
			
			if ( dom == null ) {
				ThrowFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
				return true;
			}

			return false;
		}

	}

}