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
			if ( vAppId == 0 ) {
				throw new FabArgumentValueFault("AppId", 0);
			}
			
			if ( vUserId == 0 ) {
				throw new FabArgumentValueFault("UserId", 0);
			}
			
			if ( vRedirectUri == null ) {
				throw new FabArgumentNullFault("RedirectUri");
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override string Execute() {
			var tx = Weave.Inst.NewTx();
			IWeaverFuncAs<OauthGrant> ogAlias;
			
			var newOg = new OauthGrant();
			newOg.RedirectUri = vRedirectUri;
			newOg.Expires = ApiCtx.UtcNow.AddMinutes(2).Ticks;
			newOg.Code = ApiCtx.Code32;
			
			var updates = Weave.Inst.NewUpdates<OauthGrant>();
			updates.AddUpdate(newOg, x => x.RedirectUri);
			updates.AddUpdate(newOg, x => x.Expires);
			updates.AddUpdate(newOg, x => x.Code);
			
			tx.AddQuery(
				NewPathFromIndex(new User { ArtifactId = vUserId })
				.InOauthGrantListUses.FromOauthGrant
					.As(out ogAlias)
				.UsesApp.ToApp
					.Has(x => x.ArtifactId, WeaverFuncHasOp.EqualTo, vAppId)
				.Back(ogAlias)
					.UpdateEach(updates)
				.ToQuery()
			);

			tx.Finish();
			OauthGrant og = ApiCtx.DbSingle<OauthGrant>(Query.UpdateGrantTx+"", tx);
			
			if ( og != null ) {
				return newOg.Code;
			}
			
			////
			
			var txb = new TxBuilder();
			newOg.OauthGrantId = ApiCtx.GetSharpflakeId<OauthGrant>();
			
			var ogBuild = new OauthGrantBuilder(txb, newOg);
			ogBuild.AddNode();
			ogBuild.SetUsesApp(vAppId);
			ogBuild.SetUsesUser(vUserId);
			
			ApiCtx.DbData(Query.AddGrantTx+"", txb.Finish());
			return newOg.Code;
		}

	}
	
}