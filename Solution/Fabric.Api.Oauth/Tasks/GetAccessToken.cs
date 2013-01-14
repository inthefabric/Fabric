﻿using System.Text.RegularExpressions;
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
			GetAccess
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
			if ( !r.IsMatch(vToken) ) { throw new FabArgumentFault("Token must be alpha-numeric."); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthAccess Execute() {
			IWeaverQuery getOa = NewPathFromRoot()
				.ContainsOauthAccessList.ToOauthAccess
					.Has(x => x.Token, WeaverFuncHasOp.EqualTo, vToken)
					.Has(x => x.Expires, WeaverFuncHasOp.GreaterThan, Context.UtcNow.Ticks)
				.End();

			OauthAccess oa = Context.DbSingle<OauthAccess>(Query.GetAccess+"", getOa);

			if ( oa == null ) {
				return null;
			}

			var foa = new FabOauthAccess();
			foa.OauthAccessId = oa.OauthAccessId;
			foa.AccessToken = oa.Token;
			foa.RefreshToken = oa.Refresh;
			foa.TokenType = "bearer";
			foa.ExpiresIn = 3600;
			return foa;
		}

	}

}