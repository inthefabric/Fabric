using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

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
			if ( vAppId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("AppId");
			}
			
			if ( vUserId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("UserId");
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override OauthScope Execute() {
			var tx = new WeaverTransaction();
			IWeaverFuncAs<OauthScope> osAlias;
			IWeaverVarAlias aggVar;
			
			var newOs = new OauthScope();
			newOs.Allow = vAllow;
			newOs.Created = Context.UtcNow.Ticks;
			
			var updates = new WeaverUpdates<OauthScope>();
			updates.AddUpdate(newOs, x => x.Allow);
			updates.AddUpdate(newOs, x => x.Created);

			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out aggVar)
			);

			tx.AddQuery(
				NewPathFromIndex(new User { UserId = vUserId })
					.InOauthScopeListUses.FromOauthScope
					.As(out osAlias)
				.UsesApp.ToApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, vAppId)
				.Back(osAlias)
					.Aggregate(aggVar)
					.UpdateEach(updates)
				.End()
			);

			tx.FinishWithoutStartStop(aggVar);
			
			OauthScope os = Context.DbSingle<OauthScope>(Query.UpdateScopeTx+"", tx);
			
			if ( os != null ) {
				return os;
			}
			
			////
			
			var txb = new TxBuilder();
			newOs.OauthScopeId = Context.GetSharpflakeId<OauthScope>();
			
			var osBuild = new OauthScopeBuilder(txb, newOs);
			osBuild.AddNode();
			osBuild.SetUsesApp(vAppId);
			osBuild.SetUsesUser(vUserId);
			
			txb.Transaction.FinishWithoutStartStop(osBuild.NodeVar);
			newOs = Context.DbSingle<OauthScope>(Query.AddScopeTx+"", txb.Transaction);
			return newOs;
		}

	}
	
}