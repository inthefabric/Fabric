using System;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetGrant : ApiFunc<FabOauthGrant> {
		
		private readonly string vCode;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetGrant(string pCode) : base(AuthType.None) {
			vCode = pCode;
			AddTransactionFunc(DoGrantGet);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vCode == null ) { throw new FabArgumentNullFault("Code"); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoGrantGet(ISession pSession) {
			DateTime now = GetDbNow(pSession);

			OauthGrant og = pSession.QueryOver<OauthGrant>()
				.Where(g => g.Code == vCode && g.Expires > now)
				.Take(1)
				.SingleOrDefault();

			if ( og == null ) { return; }
			SetResult(new FabOauthGrant(og));
			pSession.Delete(og);
		}

	}
}
