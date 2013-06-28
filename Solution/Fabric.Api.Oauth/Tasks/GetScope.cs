using System;
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
	public class GetScope : ApiFunc<ScopeResult> {

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
			IWeaverStepAs<OauthScope> scopeAlias;

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.ArtifactId, vUserId)
				.InOauthScopeListUses.FromOauthScope
					.As(out scopeAlias)
				.UsesApp.ToApp
					.Has(x => x.ArtifactId, WeaverStepHasOp.EqualTo, vAppId)
				.Back(scopeAlias)
				.ToQuery();

			OauthScope scope = ApiCtx.Get<OauthScope>(q);

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