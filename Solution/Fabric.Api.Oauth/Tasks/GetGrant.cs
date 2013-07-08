using System;
using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Weaver.Core.Steps.Statements;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetGrant : ApiFunc<GrantResult> {
		
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
			IWeaverStepAs<OauthGrant> grantAlias;
			
			////

			tx.AddQuery(
				WeaverQuery.InitListVar("_V0", out listVar)
			);

			tx.AddQuery(
				Weave.Inst.Graph
				.V.ExactIndex<OauthGrant>(x => x.Code, vCode)
					.Has(x => x.Expires, WeaverStepHasOp.GreaterThan, ApiCtx.UtcNow.Ticks)
					.Aggregate(listVar)
					.As(out grantAlias)
				.UsesApp.ToApp
					.Aggregate(listVar)
				.Back(grantAlias)
				.UsesUser.ToUser
					.Aggregate(listVar)
				.Back(grantAlias)
					.SideEffect(new WeaverStatementRemoveProperty<OauthGrant>(x => x.Code))
					.Iterate()
				.ToQuery()
			);

			tx.Finish(listVar);
			
			////

			IDataResult data = ApiCtx.Execute(tx);
			int count = data.GetCommandResultCount();

			if ( count <= 0 ) {
				return null;
			}

			if ( count != 3 ) {
				throw new Exception("Incorrect result count: "+count);
			}
			
			OauthGrant og = data.ToElementAt<OauthGrant>(0, 0);
			
			var gr = new GrantResult();
			gr.GrantId = og.OauthGrantId;
			gr.AppId = data.ToElementAt<App>(0, 1).ArtifactId;
			gr.UserId = data.ToElementAt<User>(0, 2).ArtifactId;
			gr.Code = vCode;
			gr.RedirectUri = og.RedirectUri;
			return gr;
		}

	}
	
}