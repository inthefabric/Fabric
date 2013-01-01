using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class AddAccess : ApiFunc<FabOauthAccess> {

		public enum Query {
			ClearTokens,
			AddAccess,
			GetApp,
			AddAppRel,
			GetUser,
			AddUserRel
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

			////

			oa = Context.DbAddNode<OauthAccess, RootContainsOauthAccess>(
				Query.AddAccess+"", oa, x => x.OauthAccessId);
			AddAccessUsesApp(oa);
			AddAccessUsesUser(oa);

			////

			var foa = new FabOauthAccess();
			foa.AccessToken = oa.Token;
			foa.RefreshToken = oa.Refresh;
			foa.ExpiresIn = vExpireSec;
			foa.TokenType = "bearer";
			return foa;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddAccessUsesApp(OauthAccess pAccess) {
			App app = Context.DbSingle<App>(
				Query.GetApp+"",
				NewPathFromIndex<App>(x => x.AppId, vAppId).End()
			);

			Context.DbData(
				Query.AddAppRel+"",
				WeaverTasks.AddRel(pAccess, new OauthAccessUsesApp(), app)
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddAccessUsesUser(OauthAccess pAccess) {
			if ( vUserId == null ) {
				return;
			}

			User user = Context.DbSingle<User>(
				Query.GetUser+"",
				NewPathFromIndex<User>(x => x.UserId, (long)vUserId).End()
			);

			Context.DbData(
				Query.AddUserRel+"",
				WeaverTasks.AddRel(pAccess, new OauthAccessUsesUser(), user)
			);
		}

	}

}