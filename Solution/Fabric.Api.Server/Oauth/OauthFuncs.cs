using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public class OauthFuncs : ModuleFuncBase, IOauthFuncs {

		private const string DbSvcUrl = "http://localhost:9001/";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthFuncs(DynamicDictionary pQuery) : base(new ApiContext(DbSvcUrl), pQuery, null) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBase Access {
			get {
				switch ( GetParamString(FuncOauthAtStep.GrantTypeName) ) {
					case FuncOauthAtStep.GrantTypeCc: return AccessClientCred;
					case FuncOauthAtStep.GrantTypeCdp: return AccessClientDataProv;
					case FuncOauthAtStep.GrantTypeRt: return AccessRefToken;
				}

				return AccessAuthCode;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessAuthCode AccessAuthCode {
			get {
				return new OauthAccessAuthCode(
					FuncOauthAtStep.GrantTypeAc,
					GetParamString(FuncOauthAtStep.RedirectUriName),
					GetParamString(FuncOauthAtStep.ClientSecretName),
					GetParamString(FuncOauthAtStep.CodeName),
					new OauthTasks()
				);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessClientCred AccessClientCred {
			get {
				return new OauthAccessClientCred(
					FuncOauthAtStep.GrantTypeCc,
					GetParamString(FuncOauthAtStep.RedirectUriName),
					GetParamString(FuncOauthAtStep.ClientSecretName),
					GetParamString(FuncOauthAtStep.ClientIdName),
					new OauthTasks()
				);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessClientDataProv AccessClientDataProv {
			get {
				return new OauthAccessClientDataProv(
					FuncOauthAtStep.GrantTypeCdp,
					GetParamString(FuncOauthAtStep.RedirectUriName),
					GetParamString(FuncOauthAtStep.ClientSecretName),
					GetParamString(FuncOauthAtStep.ClientIdName),
					GetParamString(FuncOauthAtStep.DataProvUserIdName),
					new OauthTasks()
				);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessRefToken AccessRefToken {
			get {
				return new OauthAccessRefToken(
					FuncOauthAtStep.GrantTypeRt,
					GetParamString(FuncOauthAtStep.RedirectUriName),
					GetParamString(FuncOauthAtStep.ClientSecretName),
					GetParamString(FuncOauthAtStep.RefreshTokenName),
					new OauthTasks()
				);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthLogout Logout {
			get {
				return new OauthLogout(
					GetParamString(FuncOauthLogoutStep.AccessTokenName),
					new OauthTasks()
				);
			}
		}

	}

}