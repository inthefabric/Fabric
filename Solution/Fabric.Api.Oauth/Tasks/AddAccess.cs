using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class AddAccess : ApiFunc<FabOauthAccess> {

		public enum Query {
			ClearTokens,
			AddAccessTx
		}

		private readonly long vAppId;
		private readonly long? vUserId;
		private readonly int vExpireSec;
		private readonly bool vClientOnly;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AddAccess(long pAppId, long? pUserId, int pExpireSec, bool pClientOnly) {
			vAppId = pAppId;
			vUserId = pUserId;
			vExpireSec = pExpireSec;
			vClientOnly = pClientOnly;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vAppId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("AppId");
			}
			
			if ( vClientOnly && vUserId != null ) {
				throw new FabArgumentOutOfRangeFault("UserId");
			}
			
			if ( !vClientOnly && (vUserId == null || vUserId <= 0) ) {
				throw new FabArgumentOutOfRangeFault("UserId");
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthAccess Execute() {
			ClearOldTokens();
			return AddAccessNodeAndRels();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void ClearOldTokens() {
			//Clear out the Token value of old records instead of removing the row. The rows will
			//provide good historical data about logins and app usage.

			var updates = new WeaverUpdates<OauthAccess>();
			updates.AddUpdate(new OauthAccess(), x => x.Token); //set token to null

			IWeaverFuncAs<OauthAccess> oaAlias;

			IWeaverQuery updateOa = NewPathFromRoot()
				.ContainsOauthAccessList.ToOauthAccess
					.Has(x => x.Token, WeaverFuncHasOp.NotEqualTo, null)
					.As(out oaAlias)
				.UsesApp.ToApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, vAppId)
				.Back(oaAlias)
				.UsesUser.ToUser
					.Has(x => x.UserId, WeaverFuncHasOp.EqualTo, vUserId)
				.Back(oaAlias)
					.UpdateEach(updates)
				.End();

			Context.DbData(Query.ClearTokens+"", updateOa);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess AddAccessNodeAndRels() {
			var oa = new OauthAccess();
			oa.OauthAccessId = Sharpflake.GetId(Sharpflake.SequenceKey.OauthAccess);
			oa.Expires = DateTime.UtcNow.AddSeconds(vExpireSec).Ticks;
			oa.Token = FabricUtil.Code32;
			oa.Refresh = FabricUtil.Code32;
			oa.IsClientOnly = vClientOnly;

			Context.DbData(Query.AddAccessTx+"", BuildAddTx(oa));

			var foa = new FabOauthAccess();
			foa.AccessToken = oa.Token;
			foa.RefreshToken = oa.Refresh;
			foa.ExpiresIn = vExpireSec;
			foa.TokenType = "bearer";
			return foa;
		}

		/*--------------------------------------------------------------------------------------------* /
		private IWeaverTransaction BuildAddTx(OauthAccess pAccess) {
			var tx = new WeaverTransaction();

			// Add node and index it

			IWeaverQuery addAcc = WeaverTasks.AddNode(pAccess);
			IWeaverVarAlias newOaVar;

			tx.AddQuery(
				WeaverTasks.StoreQueryResultAsVar(tx, addAcc, out newOaVar)
			);

			tx.AddQuery(
				WeaverTasks.AddNodeToIndex<OauthAccess>(
					typeof(OauthAccess).Name, newOaVar, x => x.OauthAccessId)
			);

			// Root relationship

			IWeaverQuery getRoot = NewPathFromRoot().End();
			IWeaverVarAlias rootVar;

			tx.AddQuery(
				WeaverTasks.StoreQueryResultAsVar(tx, getRoot, out rootVar)
			);

			tx.AddQuery(
				WeaverTasks.AddRel(rootVar, new RootContainsOauthAccess(), newOaVar)
			);

			// App relationship

			IWeaverQuery getApp = NewPathFromIndex<App>(x => x.AppId, vAppId).End();
			IWeaverVarAlias appVar;

			tx.AddQuery(
				WeaverTasks.StoreQueryResultAsVar(tx, getApp, out appVar)
			);

			tx.AddQuery(
				WeaverTasks.AddRel(newOaVar, new OauthAccessUsesApp(), appVar)
			);

			// User relationship

			if ( vUserId != null ) {
				IWeaverQuery getUser = NewPathFromIndex<User>(x => x.UserId, (long)vUserId).End();
				IWeaverVarAlias userVar;

				tx.AddQuery(
					WeaverTasks.StoreQueryResultAsVar(tx, getUser, out userVar)
				);

				tx.AddQuery(
					WeaverTasks.AddRel(newOaVar, new OauthAccessUsesUser(), userVar)
				);
			}

			tx.Finish(WeaverTransaction.ConclusionType.Success);
			return tx;
		}

		/*--------------------------------------------------------------------------------------------*/
		private IWeaverTransaction BuildAddTx(OauthAccess pAccess) {
			var txBuild = new TxBuilder();

			txBuild.AddNode<OauthAccess, RootContainsOauthAccess>(
				pAccess, "newOa", x => x.OauthAccessId);

			return txBuild.Transaction;
		}

	}

}