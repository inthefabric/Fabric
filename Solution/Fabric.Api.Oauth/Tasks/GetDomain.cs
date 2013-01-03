using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetDomain : ApiFunc<DomainResult> { //TEST: GetDomain

		public enum Query {
			GetDomain
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
			if ( vAppId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("AppId");
			}
			
			if ( vRedirectUri == null ) {
				throw new FabArgumentNullFault("RedirectUri");
			}

			if ( vRedirectUri.IndexOf('\'') != 0 ) {
				throw new FabArgumentFault("RedirectUri");
			}
			
			int protoI = vRedirectUri.IndexOf("://");

			if ( protoI <= 0 ) {
				throw new FabArgumentFault("RedirectUri");
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
			string domainProp = WeaverUtil.GetPropertyName<OauthDomain>(x => x.Domain);

			IWeaverQuery q = 
				NewPathFromIndex<App>(x => x.AppId, vAppId)
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, vAppId)
				.InOauthDomainListUses.FromOauthDomain
					.CustomStep("filter{it."+domainProp+".toLowerCase()=='"+vRedirectDomain+"'}")
				.End();

			OauthDomain od = Context.DbSingle<OauthDomain>(Query.GetDomain+"", q);
			
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
