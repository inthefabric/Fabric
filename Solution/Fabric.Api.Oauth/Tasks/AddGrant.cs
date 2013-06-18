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
			var tx = new WeaverTransaction();
			IWeaverStepAs<OauthGrant> ogAlias;
			
			var newOg = new OauthGrant();
			newOg.RedirectUri = vRedirectUri;
			newOg.Code = ApiCtx.Code32;
			newOg.Expires = ApiCtx.UtcNow.AddMinutes(2).Ticks;
			
			tx.AddQuery(
				Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.ArtifactId, vUserId)
				.InOauthGrantListUses.FromOauthGrant
					.As(out ogAlias)
				.UsesApp.ToApp
					.Has(x => x.ArtifactId, WeaverStepHasOp.EqualTo, vAppId)
				.Back(ogAlias)
					.SideEffect(
						new WeaverStatementSetProperty<OauthGrant>(
							x => x.RedirectUri, newOg.RedirectUri),
						new WeaverStatementSetProperty<OauthGrant>(x => x.Expires, newOg.Expires),
						new WeaverStatementSetProperty<OauthGrant>(x => x.Code, newOg.Code)
					)
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
			ogBuild.AddVertex();
			ogBuild.SetUsesApp(vAppId);
			ogBuild.SetUsesUser(vUserId);
			
			ApiCtx.DbData(Query.AddGrantTx+"", txb.Finish());
			return newOg.Code;
		}

	}
	
}