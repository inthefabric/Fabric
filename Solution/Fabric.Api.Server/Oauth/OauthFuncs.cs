using System;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Api.Server.Common;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public class OauthFuncs : ModuleFuncBase, IOauthFuncs { //TEST: OauthFuncs

		public enum Function {
			Access,
			AuthCode,
			ClientCred,
			ClientDataProv,
			RefToken,
			Logout
		}

		private const string DbSvcUrl = "http://localhost:9001/";

		public OauthAccessAuthCode AccessAuthCode { get; private set; }
		public OauthAccessClientCred AccessClientCred { get; private set; }
		public OauthAccessClientDataProv AccessClientDataProv { get; private set; }
		public OauthAccessRefToken AccessRefToken { get; private set; }
		public OauthLogout Logout { get; private set; }

		private string vRedirUri;
		private string vClientId;
		private string vClientSecret;
		private string vCode;
		private string vDataProvUserId;
		private string vRefreshToken;
		private string vAccessToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthFuncs(DynamicDictionary pQuery) : base(new ApiContext(DbSvcUrl), pQuery, null) {}

		/*--------------------------------------------------------------------------------------------*/
		public Response Execute(Function pFunc) {
			try {
				vClientId = GetParamString(FuncOauthAtStep.ClientIdName, false);
				vRedirUri = GetParamString(FuncOauthAtStep.RedirectUriName, false);
				vClientSecret = GetParamString(FuncOauthAtStep.ClientSecretName, false);
				vCode = GetParamString(FuncOauthAtStep.CodeName, false);
				vDataProvUserId = GetParamString(FuncOauthAtStep.DataProvUserIdName, false);
				vRefreshToken = GetParamString(FuncOauthAtStep.RefreshTokenName, false);
				vAccessToken = GetParamString(FuncOauthLogoutStep.AccessTokenName, false);

				switch ( pFunc ) {
					case Function.Access:
						FabOauthAccess a = DoAccess();
						return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, a.ToJson());

					case Function.AuthCode:
						FabOauthAccess ac = DoAccessAuthCode();
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

					default:
						throw new Exception("Unsupported function: "+pFunc);
				}
			}
			catch ( OauthException oe ) {
				return NancyUtil.BuildJsonResponse(HttpStatusCode.Forbidden, oe.OauthError.ToJson());
			}
			catch ( Exception e ) {
				Log.Error("Oauth Unhandled Exception", e);
				var err = FabError.ForInternalServerError();
				return NancyUtil.BuildJsonResponse(HttpStatusCode.InternalServerError, err.ToJson());
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response Redirect(FabOauthError pErr) {
			return NancyUtil.Redirect(vRedirUri+"?error="+pErr.Error+
				"&error_description="+pErr.ErrorDesc.Replace(' ', '+'));
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess DoAccess() {
			switch ( GetParamString(FuncOauthAtStep.GrantTypeName) ) {
				case FuncOauthAtStep.GrantTypeCc: return DoAccessClientCred();
				case FuncOauthAtStep.GrantTypeCdp: return DoAccessClientDataProv();
				case FuncOauthAtStep.GrantTypeRt: return DoAccessRefToken();
			}

			return DoAccessAuthCode();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess DoAccessAuthCode() {
			AccessAuthCode = new OauthAccessAuthCode(FuncOauthAtStep.GrantTypeAc,
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