using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class AddGrant : ApiFunc<string> {
	
		public enum Query {
			UpdateGrantTx,
			AddGrantTx
		}
		
		private readonly long vAppId;
		private readonly long vUserId;
		private readonly string vRedirectUri;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AddGrant(long pAppId, long pUserId, string pRedirectUri) {
			vAppId = pAppId;
			vUserId = pUserId;
			vRedirectUri = pRedirectUri;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vAppId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("AppId");
			}
			
			if ( vUserId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("UserId");
			}
			
			if ( vRedirectUri == null ) {
				throw new FabArgumentNullFault("RedirectUri");
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override string Execute() {
			var tx = new WeaverTransaction();
			IWeaverFuncAs<OauthGrant> ogAlias;
			IWeaverVarAlias aggVar;
			
			var newOg = new OauthGrant();
			newOg.RedirectUri = vRedirectUri;
			newOg.Expires = Context.UtcNow.AddMinutes(2).Ticks;
			newOg.Code = Context.Code32;
			
			var updates = new WeaverUpdates<OauthGrant>();
			updates.AddUpdate(newOg, x => x.RedirectUri);
			updates.AddUpdate(newOg, x => x.Expires);
			updates.AddUpdate(newOg, x => x.Code);
			
			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out aggVar)
			);

			tx.AddQuery(
				NewPathFromIndex(new User { UserId = vUserId })
				.InOauthGrantListUses.FromOauthGrant
					.As(out ogAlias)
				.UsesApp.ToApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, vAppId)
				.Back(ogAlias)
					.Aggregate(aggVar)
					.UpdateEach(updates)
				.End()
			);

			tx.FinishWithoutStartStop(aggVar);
			
			OauthGrant og = Context.DbSingle<OauthGrant>(Query.UpdateGrantTx+"", tx);
			
			if ( og != null ) {
				return newOg.Code;
			}
			
			////
			
			var txb = new TxBuilder();
			newOg.OauthGrantId = Context.GetSharpflakeId<OauthGrant>();
			
			var ogBuild = new OauthGrantBuilder(txb, newOg);
			ogBuild.AddNode();
			ogBuild.SetUsesApp(vAppId);
			ogBuild.SetUsesUser(vUserId);
			
			Context.DbData(Query.AddGrantTx+"", txb.Finish());
			return newOg.Code;
		}

	}
	
}