using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetScope : ApiFunc<FabOauthScope> {
		
		private readonly FabAppKey vAppKey;
		private readonly FabUserKey vUserKey;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetScope(FabAppKey pAppKey, FabUserKey pUserKey) : base(AuthType.None) {
			vAppKey = pAppKey;
			vUserKey = pUserKey;
			AddTransactionFunc(DoGetScope);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vAppKey == null ) { throw new FabArgumentNullFault("AppKey"); }
			if ( vUserKey == null ) { throw new FabArgumentNullFault("UserKey"); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoGetScope(ISession pSession) {
			OauthScope os = pSession.QueryOver<OauthScope>()
				.Where(d => d.App.Id == vAppKey.Id && d.Usr.Id == vUserKey.Id)
				.Take(1)
				.SingleOrDefault();

			if ( os == null ) { return; }
			SetResult(new FabOauthScope(os));
		}

	}
}
