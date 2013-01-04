using System;
using Fabric.Api.Dto.Oauth;
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
			GetScopeTx
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
			if ( vAppId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("AppId");
			}

			if ( vUserId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("UserId");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override ScopeResult Execute() {
			var tx = new WeaverTransaction();
			IWeaverFuncAs<OauthScope> scopeAlias;
			IWeaverVarAlias listVar;

			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out listVar)
			);

			tx.AddQuery(
				NewPathFromIndex(new User { UserId = vUserId })
					.Aggregate(listVar)
				.InOauthScopeListUses.FromOauthScope
					.As(out scopeAlias)
				.UsesApp.ToApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, vAppId)
					.Aggregate(listVar)
				.Back(scopeAlias)
					.Aggregate(listVar)
					.Iterate()
				.End()
			);

			tx.Finish(WeaverTransaction.ConclusionType.Success, listVar);

			////

			IApiDataAccess data = Context.DbData(Query.GetScopeTx+"", tx);

			if ( data.ResultDtoList == null || data.ResultDtoList.Count == 0 ) {
				return null;
			}

			if ( data.ResultDtoList.Count != 3 ) {
				throw new Exception("Incorrect ResultDtoList.Count.");
			}

			User user = data.ResultDtoList[0].ToNode<User>();
			App app = data.ResultDtoList[1].ToNode<App>();
			OauthScope scope = data.ResultDtoList[2].ToNode<OauthScope>();

			var sr = new ScopeResult();
			sr.ScopeId = scope.OauthScopeId;
			sr.AppId = app.AppId;
			sr.UserId = user.UserId;
			sr.Allow = scope.Allow;
			sr.Created = new DateTime(scope.Created);
			return sr;
		}

	}

}