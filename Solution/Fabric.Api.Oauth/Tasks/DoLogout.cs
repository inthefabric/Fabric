namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class DoLogout : AddAccess {
		
		private readonly FabOauthAccess vAccess;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DoLogout(FabOauthAccess pAccess) :	base(null, null, 0, false) {
			vAccess = pAccess;
			if ( vAccess == null ) { return; }
			vAppKey = pAccess.AppKey;
			if ( vAccess.UserKey == null ) { return; }
			vUserKey = new FabUserKey(pAccess.IsClientOnly ? 1 : pAccess.UserKey.Id);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vAccess == null ) { throw new FabArgumentNullFault("OauthAccess"); }
			base.PreGoChecks();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void DoAccessAdd(ISession pSession) {
			SetResult(new OAuthAccessResult());
		}

	}

}
