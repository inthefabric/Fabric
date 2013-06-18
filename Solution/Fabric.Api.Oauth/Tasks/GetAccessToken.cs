using System;
using System.Text.RegularExpressions;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

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
			Tuple<OauthAccess, long, long?> data = GetData();

			if ( data == null ) {
				return null;
			}

			OauthAccess oa = data.Item1;

			var foa = new FabOauthAccess();
			foa.OauthAccessId = oa.OauthAccessId;
			foa.AccessToken = oa.Token;
			foa.RefreshToken = oa.Refresh;
			foa.TokenType = "bearer";
			foa.ExpiresIn = ExpiresInSec(oa);
			foa.AppId = data.Item2;
			foa.UserId = data.Item3;
			return foa;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private Tuple<OauthAccess, long, long?> GetData() {
			Tuple<OauthAccess, long, long?> tuple = ApiCtx.Cache.Memory.FindOauthAccess(vToken);

			if ( tuple != null ) {
				return tuple;
			}

			////

			var tx = new WeaverTransaction();
			IWeaverVarAlias agg;
			IWeaverStepAs<OauthAccess> oaAlias;

			tx.AddQuery(
				WeaverQuery.InitListVar("_V0", out agg)
			);

			tx.AddQuery(
				Weave.Inst.Graph
				.V.ExactIndex<OauthAccess>(x => x.Token, vToken)
					.Has(x => x.Expires, WeaverStepHasOp.GreaterThan, ApiCtx.UtcNow.Ticks)
					.Aggregate(agg)
					.As(out oaAlias)
				.UsesApp.ToApp
					.Aggregate(agg)
				.Back(oaAlias)
				.UsesUser.ToUser
					.Aggregate(agg)
					.Iterate()
				.ToQuery()
			);

			tx.Finish(agg);

			////

			IApiDataAccess data = ApiCtx.DbData(Query.GetAccessTx+"", tx);
			int count = data.GetResultCount();

			if ( count <= 0 ) {
				return null;
			}

			if ( count != 2 && count != 3 ) {
				throw new Exception("Incorrect result count: "+count);
			}

			////

			OauthAccess oa = data.GetResultAt<OauthAccess>(0);
			long appId = data.GetResultAt<App>(1).ArtifactId;
			long? userId = null;

			if ( count == 3 ) {
				userId = data.GetResultAt<User>(2).ArtifactId;
			}

			tuple = new Tuple<OauthAccess, long, long?>(oa, appId, userId);
			ApiCtx.Cache.Memory.AddOauthAccess(vToken, tuple, ExpiresInSec(oa));
			return tuple;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private int ExpiresInSec(OauthAccess pAcc) {
			return (int)(new TimeSpan(pAcc.Expires-ApiCtx.UtcNow.Ticks).TotalSeconds);
		}

	}

}