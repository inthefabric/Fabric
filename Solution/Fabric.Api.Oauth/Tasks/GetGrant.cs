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
	public class GetGrant : ApiFunc<GrantResult> {
		
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
		protected override GrantResult Execute() {
			var tx = new WeaverTransaction();
			IWeaverVarAlias listVar;
			IWeaverFuncAs<OauthGrant> grantAlias;
			
			////

			var ogUpdate = new OauthGrant { Code = "" };
			var grantUpdater = new WeaverUpdates<OauthGrant>();
			grantUpdater.AddUpdate(ogUpdate, x => x.Code); //set to empty string

			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out listVar)
			);

			tx.AddQuery(
				NewPathFromType<OauthGrant>()
					.Has(x => x.Code, WeaverFuncHasOp.EqualTo, vCode)
					.Has(x => x.Expires, WeaverFuncHasOp.GreaterThan, ApiCtx.UtcNow.Ticks)
					.Aggregate(listVar)
					.As(out grantAlias)
				.UsesApp.ToApp
					.Aggregate(listVar)
				.Back(grantAlias)
				.UsesUser.ToUser
					.Aggregate(listVar)
				.Back(grantAlias)
					.UpdateEach(grantUpdater)
					.Iterate()
				.End()
			);

			tx.Finish(listVar);
			
			////

			IApiDataAccess data = ApiCtx.DbData(Query.GetAndUpdateTx+"", tx);
			int count = data.GetResultCount();

			if ( count <= 0 ) {
				return null;
			}

			if ( count != 3 ) {
				throw new Exception("Incorrect result count: "+count);
			}
			
			OauthGrant og = data.GetResultAt<OauthGrant>(0);
			
			var gr = new GrantResult();
			gr.GrantId = og.OauthGrantId;
			gr.AppId = data.GetResultAt<App>(1).AppId;
			gr.UserId = data.GetResultAt<User>(2).UserId;
			gr.Code = vCode;
			gr.RedirectUri = og.RedirectUri;
			return gr;
		}

	}
	
}