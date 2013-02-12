using System;
using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetScope : ApiFunc<ScopeResult> {

		public enum Query {
			GetMatchingScope
		}
		
		private readonly long vAppId;
		private readonly long vUserId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetScope(long pAppId, long pUserId) {
			vAppId = pAppId;
			vUserId = pUserId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vAppId == 0 ) {
				throw new FabArgumentValueFault("AppId", 0);
			}

			if ( vUserId == 0 ) {
				throw new FabArgumentValueFault("UserId", 0);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override ScopeResult Execute() {
			IWeaverFuncAs<OauthScope> scopeAlias;

			IWeaverQuery q =
				NewPathFromIndex(new User { UserId = vUserId })
				.InOauthScopeListUses.FromOauthScope
					.As(out scopeAlias)
				.UsesApp.ToApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, vAppId)
				.Back(scopeAlias)
				.End();

			OauthScope scope = ApiCtx.DbSingle<OauthScope>(Query.GetMatchingScope+"", q);

			if ( scope == null ) {
				return null;
			}

			var sr = new ScopeResult();
			sr.ScopeId = scope.OauthScopeId;
			sr.AppId = vAppId;
			sr.UserId = vUserId;
			sr.Allow = scope.Allow;
			sr.Created = new DateTime(scope.Created);
			return sr;
		}

	}

}