﻿using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
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
			var tx = new WeaverTransaction();
			IWeaverFuncAs<OauthAccess> accessAlias;
			IWeaverVarAlias listVar;
			
			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out listVar)
			);

			tx.AddQuery(
				NewPathFromRoot()
				.ContainsOauthAccessList.ToOauthAccess
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

			tx.Finish(WeaverTransaction.ConclusionType.Success, listVar);

			////
			
			IApiDataAccess data = Context.DbData(Query.GetAppUserTx+"", tx);

			if ( data.ResultDtoList == null || data.ResultDtoList.Count == 0 ) {
				return null;
			}

			var rr = new RefreshResult();
			rr.AppId = data.ResultDtoList[0].ToNode<App>().AppId;
			rr.UserId = data.ResultDtoList[1].ToNode<User>().UserId;
			return rr;
		}

	}
	
}