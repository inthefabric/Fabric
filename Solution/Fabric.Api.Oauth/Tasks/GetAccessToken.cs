using System;
using System.Text.RegularExpressions;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Weaver;
using Weaver.Functions;
using Weaver.Items;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetAccessToken : ApiFunc<FabOauthAccess> {
		
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
			if ( !r.IsMatch(vToken) ) { throw new FabArgumentFault("Token must be alpha-numeric."); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthAccess Execute() {
			var getOaPath = new WeaverPath<Root>(new Root());
			getOaPath.BaseNode
				.ContainsOauthAccessList
				.ToOauthAccess
				.Has(oa => oa.Token, WeaverFuncHasOp.EqualTo, vToken)
				.Has(oa => oa.Expires, WeaverFuncHasOp.GreaterThan, DateTime.UtcNow.Ticks);

			//TODO: NEED Weaver functions like List(), Limit(), Single(), Dedup(), etc.

			var getOaQuery = new WeaverQuery(getOaPath.GremlinCode);
			ApiDataAccess access = Context.ExecuteQuery(getOaQuery);

			if ( access.ResultDto == null ) {
				return null;
			}

			var foa = new FabOauthAccess();
			foa.Fill(access.ResultDto);
			return foa;
		}

	}

}