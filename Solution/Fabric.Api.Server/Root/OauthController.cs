using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Api.Server.Common;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public class OauthController : Controller { //TEST: OauthController

		public enum Function {
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

		private readonly Function vFunc;

		private string vRedirUri;
		private string vClientId;
		private string vClientSecret;
		private string vCode;
		private string vDataProvUserId;
		private string vRefreshToken;
		private string vAccessToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthController(Request pRequest, IApiContext pApiCtx, Function pFunc) :
																			base(pRequest, pApiCtx) {
			vFunc = pFunc;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildResponse() {
			vClientId = GetParamString(FuncOauthAtStep.ClientIdName, false);
			vRedirUri = GetParamString(FuncOauthAtStep.RedirectUriName, false);
			vClientSecret = GetParamString(FuncOauthAtStep.ClientSecretName, false);
			vCode = GetParamString(FuncOauthAtStep.CodeName, false);
			vDataProvUserId = GetParamString(FuncOauthAtStep.DataProvUserIdName, false);
			vRefreshToken = GetParamString(FuncOauthAtStep.RefreshTokenName, false);
			vAccessToken = GetParamString(FuncOauthLogoutStep.AccessTokenName, false);

			switch ( vFunc ) {
				case Function.Access:
					FabOauthAccess a = DoAccess();
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, a.ToJson());

				case Function.AuthCode:
					FabOauthAccess ac = DoAccessAuthCode(FuncOauthAtStep.GrantTypeAc);
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, ac.ToJson());

				case Function.ClientCred:
					FabOauthAccess acc = DoAccessClientCred();
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, acc.ToJson());

				case Function.ClientDataProv:
					FabOauthAccess acd = DoAccessClientDataProv();
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, acd.ToJson());

				case Function.RefToken:
					FabOauthAccess art = DoAccessRefToken();
					return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, art.ToJson());

				case Function.Logout:
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
			string grant = GetParamString(FuncOauthAtStep.GrantTypeName, false);

			switch ( grant ) {
				case FuncOauthAtStep.GrantTypeCc: return DoAccessClientCred();
				case FuncOauthAtStep.GrantTypeCdp: return DoAccessClientDataProv();
				case FuncOauthAtStep.GrantTypeRt: return DoAccessRefToken();
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
			AccessClientCred = new OauthAccessClientCred(FuncOauthAtStep.GrantTypeCc,
				vRedirUri, vClientSecret, vClientId, new OauthTasks());
			return AccessClientCred.Go(ApiCtx);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess DoAccessClientDataProv() {
			AccessClientDataProv = new OauthAccessClientDataProv(FuncOauthAtStep.GrantTypeCdp,
				vRedirUri, vClientSecret, vClientId, vDataProvUserId, new OauthTasks());
			return AccessClientDataProv.Go(ApiCtx);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess DoAccessRefToken() {
			AccessRefToken = new OauthAccessRefToken(FuncOauthAtStep.GrantTypeRt,
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