using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
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

			var oa = new OauthAccess();
			oa.Token = "";
			oa.Refresh = "";

			var updates = new WeaverUpdates<OauthAccess>();
			updates.AddUpdate(oa, x => x.Token); //set token to empty string
			updates.AddUpdate(oa, x => x.Refresh); //set refresh to empty string

			IWeaverFuncAs<OauthAccess> oaAlias;

			IWeaverQuery updateOa = NewPathFromIndex(new App { AppId = vAppId })
				.InOauthAccessListUses.FromOauthAccess
					.Has(x => x.Token, WeaverFuncHasOp.NotEqualTo, null)
					.As(out oaAlias)
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
			var txb = new TxBuilder();
		
			var oa = new OauthAccess();
			oa.OauthAccessId = Context.GetSharpflakeId<OauthAccess>();
			oa.Expires = Context.UtcNow.AddSeconds(vExpireSec).Ticks;
			oa.Token = Context.Code32;
			oa.Refresh = Context.Code32;
			oa.IsClientOnly = vClientOnly;
			
			var oaBuild = new OauthAccessBuilder(txb, oa);
			oaBuild.AddNode();
			oaBuild.SetUsesApp(vAppId);
			
			if ( vUserId != null ) {
				oaBuild.SetUsesUser((long)vUserId);
			}

			Context.DbData(Query.AddAccessTx+"", txb.Finish());

			////

			var foa = new FabOauthAccess();
			foa.AccessToken = oa.Token;
			foa.RefreshToken = oa.Refresh;
			foa.ExpiresIn = vExpireSec;
			foa.TokenType = "bearer";
			return foa;
		}

	}

}