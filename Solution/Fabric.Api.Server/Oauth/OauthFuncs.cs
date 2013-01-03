using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public class OauthFuncs : ApiFuncBase {

		private const string DbSvcUrl = "http://localhost:9001/";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthFuncs(DynamicDictionary pQuery) : base(pQuery, new ApiContext(DbSvcUrl)) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessAuthCode OauthAccessAuthCode {
			get {
				return new OauthAccessAuthCode(
					"authorization_code",
					GetParamString(FuncOauthAtacStep.RedirectUriName),
					GetParamString(FuncOauthAtacStep.ClientSecretName),
					GetParamString(FuncOauthAtacStep.CodeName),
					new OauthTasks()
				);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessClientCred OauthAccessClientCred {
			get {
				return new OauthAccessClientCred(
					"client_credentials",
					GetParamString(FuncOauthAtccStep.RedirectUriName),
					GetParamString(FuncOauthAtccStep.ClientSecretName),
					GetParamString(FuncOauthAtccStep.ClientIdName),
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