using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetDomain : ActiveFunc<FabOauthDomain> {
		
		private readonly FabAppKey vAppKey;
		private readonly string vRedirectUri;
		private string vRedirectDomain;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetDomain(FabAppKey pAppKey, string pRedirectUri) : base(AuthType.None) {
			vAppKey = pAppKey;
			vRedirectUri = pRedirectUri;
			AddTransactionFunc(DoValidRedirect);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vAppKey == null ) { throw new FabArgumentNullFault("AppKey"); }
			if ( vRedirectUri == null ) { throw new FabArgumentNullFault("RedirectUri"); }
			
			int protoI = vRedirectUri.IndexOf("://");
			if ( protoI <= 0 ) { throw new FabArgumentFault("RedirectUri"); }

			vRedirectDomain = vRedirectUri.Substring(protoI+3);

			int slashI = vRedirectDomain.IndexOf("/");
			if ( slashI > 0 ) { vRedirectDomain = vRedirectDomain.Substring(0, slashI); }
			
			int wwwI = vRedirectDomain.IndexOf("www.");
			if ( wwwI == 0 ) { vRedirectDomain = vRedirectDomain.Substring(4); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoValidRedirect(ISession pSession) {
			string escRedir = FabricUtil.EscapeIsLikeString(vRedirectDomain);

			OauthDomain domain = pSession.QueryOver<OauthDomain>()
				.Where(d => d.App.Id == vAppKey.Id)
				.WhereRestrictionOn(d => d.Domain).IsInsensitiveLike(escRedir)
				.Take(1)
				.SingleOrDefault();

			if ( domain == null ) { return; }
			SetResult(new FabOauthDomain(domain));
		}

	}
}
