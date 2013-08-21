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

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetRefresh : ApiFunc<RefreshResult> {

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
			IWeaverStepAs<OauthAccess> accessAlias;
			IWeaverVarAlias listVar;
			
			tx.AddQuery(
				WeaverQuery.InitListVar("_V0", out listVar)
			);

			tx.AddQuery(
				Weave.Inst.Graph
				.V.ExactIndex<OauthAccess>(x => x.Refresh, vRefreshToken)
					.Has(x => x.IsClientOnly, WeaverStepHasOp.EqualTo, false)
					.As(out accessAlias)
				.UsesApp.ToApp
					.Aggregate(listVar)
				.Back(accessAlias)
				.UsesUser.ToUser
					.Aggregate(listVar)
					.Iterate()
				.ToQuery()
			);

			tx.Finish(listVar);

			////

			IDataResult data = ApiCtx.Execute(tx, "Oauth-GetRefresh-Get");
			int count = data.GetCommandResultCount();

			if ( count <= 0 ) {
				return null;
			}

			if ( count != 2 ) {
				throw new Exception("Incorrect result count: "+count);
			}

			var rr = new RefreshResult();
			rr.AppId = data.ToElementAt<App>(0, 0).ArtifactId;
			rr.UserId = data.ToElementAt<User>(0, 1).ArtifactId;
			return rr;
		}

	}
	
}