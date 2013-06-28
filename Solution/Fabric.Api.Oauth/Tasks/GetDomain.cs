using Fabric.Api.Oauth.Results;
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
	public class GetDomain : ApiFunc<DomainResult> {

		private readonly long vAppId;
		private readonly string vRedirectUri;
		private string vRedirectDomain;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetDomain(long pAppId, string pRedirectUri) {
			vAppId = pAppId;
			vRedirectUri = pRedirectUri;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vAppId == 0 ) {
				throw new FabArgumentValueFault("AppId", 0);
			}
			
			if ( vRedirectUri == null ) {
				throw new FabArgumentNullFault("RedirectUri");
			}

			if ( vRedirectUri.IndexOf('\'') != -1 ) {
				throw new FabArgumentValueFault("RedirectUri");
			}
			
			int protoI = vRedirectUri.IndexOf("://");

			if ( protoI <= 0 ) {
				throw new FabArgumentValueFault("RedirectUri");
			}

			vRedirectDomain = vRedirectUri.Substring(protoI+3);

			int slashI = vRedirectDomain.IndexOf("/");
			if ( slashI > 0 ) { vRedirectDomain = vRedirectDomain.Substring(0, slashI); }
			
			int wwwI = vRedirectDomain.IndexOf("www.");
			if ( wwwI == 0 ) { vRedirectDomain = vRedirectDomain.Substring(4); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override DomainResult Execute() {
			IWeaverQuery q = 
				Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.ArtifactId, vAppId)
				.InOauthDomainListUses.FromOauthDomain
					.Has(x => x.Domain, WeaverStepHasOp.EqualTo, vRedirectDomain.ToLower())
				.ToQuery();

			OauthDomain od = ApiCtx.Get<OauthDomain>(q);
			
			if ( od == null ) {
				return null;
			}

			var dr = new DomainResult();
			dr.AppId = vAppId;
			dr.Domain = vRedirectDomain;
			return dr;
		}

	}

}