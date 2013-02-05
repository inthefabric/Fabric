﻿using System;
using Fabric.Api.Common;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Functions;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Util;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class OauthAccessController : Controller { //TEST: OauthAccessController

		public enum Route {
			Access,
			AuthCode,
			ClientCred,
			ClientDataProv,
			RefToken,
			Logout
		}

		public OauthAccessAuthCode AccessAuthCode { get; private set; }
		public OauthAccessClientCred AccessClientCred { get; private set; }
		public OauthAccessClientDataProv AccessClientDataProv { get; private set; }
		public OauthAccessRefToken AccessRefToken { get; private set; }
		public OauthLogout Logout { get; private set; }

		private readonly Route vFunc;

		private string vRedirUri;
		private string vClientId;
		private string vClientSecret;
		private string vCode;
		private string vDataProvUserId;
		private string vRefreshToken;
		private string vAccessToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessController(Request pRequest, IApiContext pApiCtx, Route pFunc) :
																			base(pRequest, pApiCtx) {
			vFunc = pFunc;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildResponse() {
			vClientId = GetParamString(FuncOauthAt.ClientIdName, false);
			vRedirUri = GetParamString(FuncOauthAt.RedirectUriName, false);
			vClientSecret = GetParamString(FuncOauthAt.ClientSecretName, false);
			vCode = GetParamString(FuncOauthAt.CodeName, false);
			vDataProvUserId = GetParamString(FuncOauthAt.DataProvUserIdName, false);
			vRefreshToken = GetParamString(FuncOauthAt.RefreshTokenName, false);
			vAccessToken = GetParamString(FuncOauthLogout.AccessTokenName, false);

			switch ( vFunc ) {
				case Route.Access:
					FabOauthAccess a = DoAccess();
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, a.ToJson());

				case Route.AuthCode:
					FabOauthAccess ac = DoAccessAuthCode(FuncOauthAt.GrantTypeAc);
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, ac.ToJson());

				case Route.ClientCred:
					FabOauthAccess acc = DoAccessClientCred();
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, acc.ToJson());

				case Route.ClientDataProv:
					FabOauthAccess acd = DoAccessClientDataProv();
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, acd.ToJson());

				case Route.RefToken:
					FabOauthAccess art = DoAccessRefToken();
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, art.ToJson());

				case Route.Logout:
					FabOauthLogout log = DoLogout();
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, log.ToJson());
			}

			throw new Exception("Unsupported function: "+vFunc);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildExceptionResponse(Exception pEx) {
			FabOauthError fabErr;

			if ( pEx is OauthException ) {
				ExceptionIsHandled();
				fabErr = (pEx as OauthException).OauthError;
			}
			else {
				fabErr = FabOauthError.ForInternalServerError();
			}

			return NancyUtil.BuildJsonResponse(HttpStatusCode.Forbidden, fabErr.ToJson());
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response Redirect(FabOauthError pErr) {
			return NancyUtil.Redirect(vRedirUri+"?error="+pErr.Error+
				"&error_description="+pErr.ErrorDesc.Replace(' ', '+'));
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess DoAccess() {
			string grant = GetParamString(FuncOauthAt.GrantTypeName, false);

			switch ( grant ) {
				case FuncOauthAt.GrantTypeCc: return DoAccessClientCred();
				case FuncOauthAt.GrantTypeCdp: return DoAccessClientDataProv();
				case FuncOauthAt.GrantTypeRt: return DoAccessRefToken();
			}

			return DoAccessAuthCode(grant);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess DoAccessAuthCode(string pGrant) {
			AccessAuthCode = new OauthAccessAuthCode(pGrant,
				vRedirUri, vClientSecret, vCode, new OauthTasks());
			return AccessAuthCode.Go(ApiCtx);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess DoAccessClientCred() {
			AccessClientCred = new OauthAccessClientCred(FuncOauthAt.GrantTypeCc,
				vRedirUri, vClientSecret, vClientId, new OauthTasks());
			return AccessClientCred.Go(ApiCtx);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess DoAccessClientDataProv() {
			AccessClientDataProv = new OauthAccessClientDataProv(FuncOauthAt.GrantTypeCdp,
				vRedirUri, vClientSecret, vClientId, vDataProvUserId, new OauthTasks());
			return AccessClientDataProv.Go(ApiCtx);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess DoAccessRefToken() {
			AccessRefToken = new OauthAccessRefToken(FuncOauthAt.GrantTypeRt,
				vRedirUri, vClientSecret, vRefreshToken, new OauthTasks());
			return AccessRefToken.Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthLogout DoLogout() {
			Logout = new OauthLogout(vAccessToken, new OauthTasks());
			return Logout.Go(ApiCtx);
		}

	}

}