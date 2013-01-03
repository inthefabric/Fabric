using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetAppAuth : ApiFunc<App> { //TEST: GetAppAuth
		
		public enum Query {
			GetApp
		}
		
		private readonly long vAppId;
		private readonly string vAppSecret;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetAppAuth(long pAppId, string pAppSecret) {
			vAppId = pAppId;
			vAppSecret = pAppSecret;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vAppId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("AppId");
			}
			
			if ( vAppSecret == null ) {
				throw new FabArgumentNullFault("AppSecret");
			}
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override App Execute() {
			IWeaverQuery getApp = 
				NewPathFromIndex<App>(x => x.AppId, vAppId)
					.Has(x => x.Secret, WeaverFuncHasOp.EqualTo, vAppSecret)
				.End();
				
			return Context.DbSingle<App>(Query.GetApp+"", getApp);
		}
		
	}
}
