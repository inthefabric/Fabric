namespace Fabric.Api.Oauth {

	/*================================================================================================*/
	public class OauthAccess_ClientDataProv : OauthAccess_ClientCred {

		protected string vDataProvIdStr;
		protected int vDataProvId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccess_ClientDataProv(string pGrantType, string pRedirectUri,
										string pClientSecret, string pClientId, string pDataProvId)
											: base(pGrantType, pRedirectUri, pClientSecret, pClientId) {
			vDataProvIdStr = pDataProvId;
		}


		/*--------------------------------------------------------------------------------------------*/
		protected override bool VerifyGrantType() {
			return (vGrantType == "client_dataprov");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool RedirectOnParamErrors() {
			if ( base.RedirectOnParamErrors() ) {
				return true;
			}

			bool parsed = int.TryParse(vDataProvIdStr, out vDataProvId);

			if ( !parsed || vDataProvId <= 0 ) {
				ThrowFault(AccessErrors.invalid_client, AccessErrorDescs.NoDataProvId);
				return true;
			}

			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void PerformAccessRequestActions() {
			if ( RedirectOnBadDomain() ) { return; }

			Usr dp = Context.CurrentSession.QueryOver<Usr>()
			   .Where(p => p.Id == vDataProvId)
			   .JoinQueryOver<Member>(p => p.Members, JoinType.InnerJoin)
			   .Where(m => m.App.Id == vClientId && m.MemberType.Id == (int)MemberTypeIds.DataProvider)
			   .Take(1)
			   .SingleOrDefault();

			if ( dp == null ) {
				ThrowFault(AccessErrors.unauthorized_client, AccessErrorDescs.BadDataProvId);
				return;
			}

			SendAccessCode(vClientId, dp.Id);
		}

	}

}