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

			//TODO: determine if the no-User scenario is necessary

			tx.AddQuery(
				NewPathFromRoot()
				.ContainsOauthGrantList.ToOauthGrant
					.Has(x => x.Code, WeaverFuncHasOp.EqualTo, vCode)
					.Has(x => x.Expires, WeaverFuncHasOp.GreaterThan, Context.UtcNow.Ticks)
					.Aggregate(listVar)
					.As(out grantAlias)
				.UsesApp.ToApp
					.Aggregate(listVar)
				.Back(grantAlias)
				.UsesUser.ToUser
					.Aggregate(listVar)
				.Back(grantAlias)
					.UpdateEach(grantUpdater)
				.End()
			);

			tx.FinishWithoutStartStop(listVar);
			
			////

			IApiDataAccess data = Context.DbData(Query.GetAndUpdateTx+"", tx);
			
			if ( data.ResultDtoList == null || data.ResultDtoList.Count == 0 ) {
				return null;
			}

			if ( data.ResultDtoList.Count != 2 && data.ResultDtoList.Count != 3 ) {
				throw new Exception("Incorrect ResultDtoList.Count.");
			}
			
			OauthGrant og = data.ResultDtoList[0].ToNode<OauthGrant>();
			App app = data.ResultDtoList[1].ToNode<App>();
			
			var gr = new GrantResult();
			gr.GrantId = og.OauthGrantId;
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