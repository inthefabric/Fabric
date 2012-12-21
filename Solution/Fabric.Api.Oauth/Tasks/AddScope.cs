using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class AddScope : ActiveFunc<FabOauthScopeKey> {
		
		private readonly FabAppKey vAppKey;
		private readonly FabUserKey vUserKey;
		private readonly bool vAllow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AddScope(FabAppKey pAppKey, FabUserKey pUserKey, bool pAllow) :
																				base(AuthType.None) {
			vAppKey = pAppKey;
			vUserKey = pUserKey;
			vAllow = pAllow;
			AddTransactionFunc(DoScopeAdd);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vAppKey == null ) { throw new FabArgumentNullFault("AppKey"); }
			if ( vUserKey == null ) { throw new FabArgumentNullFault("UserKey"); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoScopeAdd(ISession pSession) {
			OauthScope os = pSession.QueryOver<OauthScope>()
				.Where(g => g.App.Id == vAppKey.Id && g.Usr.Id == vUserKey.Id)
				.Take(1)
				.SingleOrDefault();

			if ( os == null ) {
				os = new OauthScope();
				os.App = pSession.Load<App>(vAppKey.Id);
				os.Usr = pSession.Load<Usr>(vUserKey.Id);
			}

			os.Allow = vAllow;
			os.Created = GetDbNow(pSession);
			pSession.SaveOrUpdate(os);

			SetResult(new FabOauthScopeKey(os.Id));
		}

	}
}
