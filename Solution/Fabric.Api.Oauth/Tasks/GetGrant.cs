using System;
using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Core;
using Weaver.Core.Query;
using Weaver.Core.Steps;

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
			var tx = Weave.Inst.NewTx();
			IWeaverVarAlias listVar;
			IWeaverStepAs<OauthGrant> grantAlias;
			
			////

			var ogUpdate = new OauthGrant { Code = "" };
			var grantUpdater = Weave.Inst.NewUpdates<OauthGrant>();
			grantUpdater.AddUpdate(ogUpdate, x => x.Code); //set to empty string

			tx.AddQuery(
				Weave.Inst.InitListVar(tx, out listVar)
			);

			tx.AddQuery(
				Weave.Inst
				NewPathFromType<OauthGrant>()
					.Has(x => x.Code, WeaverStepHasOp.EqualTo, vCode)
					.Has(x => x.Expires, WeaverStepHasOp.GreaterThan, ApiCtx.UtcNow.Ticks)
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
				.ToQuery()
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
			gr.AppId = data.GetResultAt<App>(1).ArtifactId;
			gr.UserId = data.GetResultAt<User>(2).ArtifactId;
			gr.Code = vCode;
			gr.RedirectUri = og.RedirectUri;
			return gr;
		}

	}
	
}