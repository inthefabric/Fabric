using System;
using Fabric.Infrastructure.Api;
using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;
using Weaver.Functions;
using Fabric.Infrastructure.Api.Faults;
using System.Linq.Expressions;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetGrant : ApiFunc<GrantResult> { //TEST: GetGrant
		
		public enum Query {
			GetAndUpdateTx
		}
		
		private readonly string vCode;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetGrant(string pCode) {
			vCode = pCode;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vCode == null ) {
				throw new FabArgumentNullFault("Code");
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override GrantResult Execute () {
			var tx = new WeaverTransaction();
			IWeaverListVar listVar;
			OauthGrant grantAlias;
			
			var grantUpdater = new WeaverUpdates<OauthGrant>();
			grantUpdater.AddUpdate(new OauthGrant(), x => x.Code); //set to null
			
			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out listVar)
			);
			
			tx.AddQuery(
				NewPathFromRoot()
				.ContainsOauthGrantList.ToOauthGrant
					.Has(x => x.Code, WeaverFuncHasOp.EqualTo, vCode)
					.Has(x => x.Expires, WeaverFuncHasOp.GreaterThan, Context.UtcNow.Ticks)
					.Aggregate(listVar)
					.UpdateEach(grantUpdater)
					.As(out grantAlias)
				.UsesApp.ToApp
					.Aggregate(listVar)
				.Back(grantAlias)
				.UsesUser.ToUser
					.Aggregate(listVar)
					.Iterate()
				.End()
			);
			
			tx.Finish (WeaverTransaction.ConclusionType.Success, listVar);
				
			IApiDataAccess data = Context.DbData(Query.GetAndUpdateTx+"", tx);
			
			if ( data.ResultDtoList == null ) {
				return null;
			}
			
			OauthGrant og = data.ResultDtoList[0].ToNode<OauthGrant>();
			App app = data.ResultDtoList[1].ToNode<App>();
			
			var gr = new GrantResult();
			gr.GrantId = og.Id;
			gr.AppId = app.AppId;
			gr.Code = vCode;
			gr.RedirectUri = og.RedirectUri;
			
			if ( data.ResultDtoList.Count == 3 ) {
				User user = data.ResultDtoList[2].ToNode<User>();
				gr.UserId = user.UserId;
			}
			
			return gr;
		}

	}
	
}