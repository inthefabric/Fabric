using System;
using System.Text.RegularExpressions;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetAccessToken : ApiFunc<FabOauthAccess> {
		
		public enum Query {
			GetAccessTx
		}

		private readonly string vToken;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetAccessToken(string pToken) {
			vToken = pToken;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vToken == null ) { throw new FabArgumentNullFault("Token"); }
			if ( vToken.Length != 32 ) { throw new FabArgumentLengthFault("Token", 32, 32); }

			var r = new Regex("^[a-zA-Z0-9]*$");
			
			if ( !r.IsMatch(vToken) ) {
				throw new FabArgumentValueFault("Token must be alpha-numeric.");
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthAccess Execute() {
			IWeaverTransaction tx = new WeaverTransaction();
			IWeaverVarAlias agg;
			IWeaverFuncAs<OauthAccess> oaAlias;

			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out agg)
			);

			tx.AddQuery(
				NewPathFromRoot()
				.ContainsOauthAccessList.ToOauthAccess
					.Has(x => x.Token, WeaverFuncHasOp.EqualTo, vToken)
					.Has(x => x.Expires, WeaverFuncHasOp.GreaterThan, ApiCtx.UtcNow.Ticks)
					.Aggregate(agg)
					.As(out oaAlias)
				.UsesApp.ToApp
					.Aggregate(agg)
				.Back(oaAlias)
				.UsesUser.ToUser
					.Aggregate(agg)
					.Iterate()
				.End()
			);

			tx.FinishWithoutStartStop(agg);

			IApiDataAccess data = ApiCtx.DbData(Query.GetAccessTx+"", tx);
			int count = data.GetResultCount();

			if ( count <= 0 ) {
				return null;
			}

			if ( count != 2 && count != 3 ) {
				throw new Exception("Incorrect result count: "+count);
			}

			OauthAccess oa = data.GetResultAt<OauthAccess>(0);

			var foa = new FabOauthAccess();
			foa.OauthAccessId = oa.OauthAccessId;
			foa.AccessToken = oa.Token;
			foa.RefreshToken = oa.Refresh;
			foa.TokenType = "bearer";
			foa.ExpiresIn = 3600;
			foa.AppId = data.GetResultAt<App>(1).AppId;

			if ( count == 3 ) {
				foa.UserId = data.GetResultAt<User>(2).UserId;
			}

			return foa;
		}

	}

}