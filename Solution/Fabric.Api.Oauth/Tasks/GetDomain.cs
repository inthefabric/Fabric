using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Weaver;
using Weaver.Interfaces;

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

			vRedirectDomain = vRedirectDomain.ToLower();
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override DomainResult Execute() {
			string domainProp = WeaverUtil.GetPropertyName<OauthDomain>(x => x.Domain);
			string filterStep = "filter{it.getProperty('"+domainProp+"').toLowerCase()==_P1}";

			IWeaverQuery q = 
				NewPathFromIndex(new App { AppId = vAppId })
				.InOauthDomainListUses.FromOauthDomain
					.CustomStep(filterStep)
				.End();

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