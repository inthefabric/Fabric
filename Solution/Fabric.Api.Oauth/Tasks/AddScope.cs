using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Weaver.Core.Steps.Statements;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class AddScope : ApiFunc<OauthScope> {
		
		public enum Query {
			UpdateScopeTx,
			AddScopeTx
		}
		
		private readonly long vAppId;
		private readonly long vUserId;
		private readonly bool vAllow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AddScope(long pAppId, long pUserId, bool pAllow) {
			vAppId = pAppId;
			vUserId = pUserId;
			vAllow = pAllow;
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
		protected override OauthScope Execute() {
			var tx = new WeaverTransaction();
			IWeaverStepAs<OauthScope> osAlias;
			
			var newOs = new OauthScope();
			newOs.Allow = vAllow;
			newOs.Created = ApiCtx.UtcNow.Ticks;

			tx.AddQuery(
				Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.ArtifactId, vUserId)
				.InOauthScopeListUses.FromOauthScope
					.As(out osAlias)
				.UsesApp.ToApp
					.Has(x => x.ArtifactId, WeaverStepHasOp.EqualTo, vAppId)
				.Back(osAlias)
					.SideEffect(
						new WeaverStatementSetProperty<OauthScope>(x => x.Allow, newOs.Allow),
						new WeaverStatementSetProperty<OauthScope>(x => x.Created, newOs.Created)
					)
				.ToQuery()
			);

			tx.Finish();
			OauthScope os = ApiCtx.DbSingle<OauthScope>(Query.UpdateScopeTx+"", tx);
			
			if ( os != null ) {
				return os;
			}
			
			////
			
			var txb = new TxBuilder();

			newOs.OauthScopeId = ApiCtx.GetSharpflakeId<OauthScope>();
			
			var osBuild = new OauthScopeBuilder(txb, newOs);
			osBuild.AddVertex();
			osBuild.SetUsesApp(vAppId);
			osBuild.SetUsesUser(vUserId);
			
			txb.Transaction.Finish(osBuild.VertexVar);
			newOs = ApiCtx.DbSingle<OauthScope>(Query.AddScopeTx+"", txb.Transaction);
			return newOs;
		}

	}
	
}