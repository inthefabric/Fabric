using System;
using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetRefresh : ApiFunc<RefreshResult> {

		public enum Query {
			GetAppUserTx
		}
		
		private readonly string vRefreshToken;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetRefresh(string pRefreshToken) {
			vRefreshToken = pRefreshToken;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vRefreshToken == null ) {
				throw new FabArgumentNullFault("RefreshToken");
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override RefreshResult Execute() {
			var tx = Weave.Inst.NewTx();
			IWeaverFuncAs<OauthAccess> accessAlias;
			IWeaverVarAlias listVar;
			
			tx.AddQuery(
				Weave.Inst.InitListVar(tx, out listVar)
			);

			tx.AddQuery(
				NewPathFromType<OauthAccess>()
					.Has(x => x.Refresh, WeaverFuncHasOp.EqualTo, vRefreshToken)
					.Has(x => x.IsClientOnly, WeaverFuncHasOp.EqualTo, false)
					.As(out accessAlias)
				.UsesApp.ToApp
					.Aggregate(listVar)
				.Back(accessAlias)
				.UsesUser.ToUser
					.Aggregate(listVar)
					.Iterate()
				.End()
			);

			tx.Finish(listVar);

			////

			IApiDataAccess data = ApiCtx.DbData(Query.GetAppUserTx+"", tx);
			int count = data.GetResultCount();

			if ( count <= 0 ) {
				return null;
			}

			if ( count != 2 ) {
				throw new Exception("Incorrect result count: "+count);
			}

			var rr = new RefreshResult();
			rr.AppId = data.GetResultAt<App>(0).AppId;
			rr.UserId = data.GetResultAt<User>(1).UserId;
			return rr;
		}

	}
	
}