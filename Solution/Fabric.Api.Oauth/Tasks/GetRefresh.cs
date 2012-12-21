namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetRefresh : SvcFunc<OauthRefreshResult> {
		
		private readonly string vRefreshToken;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetRefresh(string pRefreshToken) : base(AuthType.None) {
			vRefreshToken = pRefreshToken;
			AddTransactionFunc(DoRefreshGet);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vRefreshToken == null ) { throw new FabArgumentNullFault("RefreshToken"); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoRefreshGet(ISession pSession) {
			OauthAccess oa = pSession.QueryOver<OauthAccess>()
				.Where(a => a.Refresh == vRefreshToken && a.IsClientOnly == false)
				.Take(1)
				.SingleOrDefault();

			if ( oa == null ) { return; }

			if ( oa.Token.Length < 32 ) {
				//FUTURE: could record the use of an expired refresh token as a potential abuse
				return;
			}

			OauthRefreshResult res = new OauthRefreshResult();
			res.appId = oa.App.Id;
			res.userId = oa.Usr.Id;
			SetResult(res);
		}

	}
	
	/*================================================================================================*/
	public class OauthRefreshResult {

		public uint appId;
		public uint userId;

	}
	
}