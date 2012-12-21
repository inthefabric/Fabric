namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class AddGrant : SvcFunc<string> {
		
		private readonly FabAppKey vAppKey;
		private readonly FabUserKey vUserKey;
		private readonly string vRedirectUri;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AddGrant(FabAppKey pAppKey, FabUserKey pUserKey, string pRedirectUri) :
																				base(AuthType.None) {
			vAppKey = pAppKey;
			vUserKey = pUserKey;
			vRedirectUri = pRedirectUri;
			AddTransactionFunc(DoGrantAdd);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vAppKey == null ) { throw new FabArgumentNullFault("AppKey"); }
			if ( vUserKey == null ) { throw new FabArgumentNullFault("UserKey"); }
			if ( vRedirectUri == null ) { throw new FabArgumentNullFault("RedirectUri"); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoGrantAdd(ISession pSession) {
			OauthGrant og = pSession.QueryOver<OauthGrant>()
				.Where(g => g.App.Id == vAppKey.Id && g.Usr.Id == vUserKey.Id)
				.Take(1)
				.SingleOrDefault();

			if ( og == null ) {
				og = new OauthGrant();
				og.App = pSession.Load<App>(vAppKey.Id);
				og.Usr = pSession.Load<Usr>(vUserKey.Id);
			}

			og.RedirectUri = vRedirectUri;
			og.Expires = GetDbNow(pSession).AddMinutes(2);
			og.Code = FabricUtil.Code32();
			pSession.SaveOrUpdate(og);

			SetResult(og.Code);
		}

	}
}
