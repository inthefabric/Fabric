using System;
using Fabric.Infrastructure.Api;
using Fabric.Api.Oauth.Results;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;
using Weaver.Functions;
using Fabric.Infrastructure.Api.Faults;
using System.Linq.Expressions;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetGrant : ApiFunc<GrantResult> { //TEST: GetGrant
		
		public enum Query {
			GetGrant,
			GetApp,
			GetUser,
			UpdateGrant
		}
		
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
			IWeaverQuery getGrant = 
				NewPathFromRoot()
				.ContainsOauthGrantList.ToOauthGrant
					.Has(x => x.Code, WeaverFuncHasOp.EqualTo, vCode)
					.Has(x => x.Expires, WeaverFuncHasOp.GreaterThan, Context.UtcNow.Ticks)
				.End();
			
			OauthGrant og = Context.DbSingle<OauthGrant>(Query.GetGrant+"", getGrant);
			
			if ( og == null ) {
				return null;
			}
			
			IWeaverQuery getApp = 
				NewPathFromIndex<OauthGrant>(x => x.OauthGrantId, og.OauthGrantId)
				.UsesApp.ToApp
				.End();
			
			IWeaverQuery getUser = 
				NewPathFromIndex<OauthGrant>(x => x.OauthGrantId, og.OauthGrantId)
				.UsesUser.ToUser
				.End();
			
			App app = Context.DbSingle<App>(Query.GetApp+"", getApp);
			User user = Context.DbSingle<User>(Query.GetUser+"", getUser);
			
			var gr = new GrantResult();
			gr.GrantId = og.Id;
			gr.AppId = app.AppId;
			gr.Code = og.Code;
			gr.RedirectUri = og.RedirectUri;
			
			if ( user != null ) {
				gr.UserId = user.UserId;
			}
			
			//Previous implementations deleted the OauthGrant (and related relationships)
			
			var updates = new WeaverUpdates<OauthGrant>();
			updates.AddUpdate(new OauthGrant(), x => x.Code); //set to null
			
			IWeaverQuery updateGrant = 
				NewPathFromIndex<OauthGrant>(x => x.OauthGrantId, og.OauthGrantId)
					.UpdateEach(updates)
				.End();
			
			Context.DbData(Query.UpdateGrant+"", updateGrant); 
			
			return gr;
		}

	}
	
}