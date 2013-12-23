using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;

namespace Fabric.Api.Oauth {

	/*================================================================================================*/
	public class OauthAccessClientDataProv : OauthAccessClientCred {

		private readonly string vDataProvIdStr;
		private long vDataProvId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessClientDataProv(string pGrantType, string pRedirectUri, string pClientSecret,
									string pClientId, string pDataProvId, IOauthTasks pTasks) :
									base(pGrantType, pRedirectUri, pClientSecret, pClientId, pTasks) {
			vDataProvIdStr = pDataProvId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool VerifyGrantType() {
			return (vGrantType == "client_dataprov");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void RedirectOnParamErrors() {
			base.RedirectOnParamErrors();

			bool parsed = long.TryParse(vDataProvIdStr, out vDataProvId);

			if ( !parsed || vDataProvId <= 0 ) {
				throw GetFault(AccessErrors.invalid_client, AccessErrorDescs.NoDataProvId);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthAccess PerformAccessRequestActions() {
			RedirectOnBadDomain();

			User dp = vTasks.GetDataProv(vClientId, vDataProvId, ApiCtx);
			
			if ( dp == null ) {
				throw GetFault(AccessErrors.unauthorized_client, AccessErrorDescs.BadDataProvId);
			}

			return SendAccessCode(vClientId, dp.ArtifactId);
		}

	}

}