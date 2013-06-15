using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Weaver.Titan;
using Weaver.Titan.Steps.Parameters;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetDomain : ApiFunc<DomainResult> {

		public enum Query {
			GetOauthDomain
		}
		
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
				Weave.Inst.TitanGraph()
				.QueryV().ElasticIndex(
					new WeaverParamElastic<OauthDomain>(
						x => x.Domain, WeaverParamElasticOp.Contains, vRedirectDomain)
				)
				.UsesApp.ToApp
					.Has(x => x.ArtifactId, WeaverStepHasOp.EqualTo, vAppId)
				.ToQuery();

			q.AddStringParam(vRedirectDomain.ToLower());
			OauthDomain od = ApiCtx.DbSingle<OauthDomain>(Query.GetOauthDomain+"", q);
			
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