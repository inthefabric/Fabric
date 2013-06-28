using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Fabric.Infrastructure.Data;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetAppAuth : ApiFunc<App> {
		
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
			if ( vAppId == 0 ) {
				throw new FabArgumentValueFault("AppId", 0);
			}
			
			if ( vAppSecret == null ) {
				throw new FabArgumentNullFault("AppSecret");
			}
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override App Execute() {
			IWeaverQuery getApp = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.ArtifactId, vAppId)
					.Has(x => x.Secret, WeaverStepHasOp.EqualTo, vAppSecret)
				.ToQuery();
				
			return ApiCtx.Get<App>(getApp);
		}
		
	}

}