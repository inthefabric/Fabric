using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Oauth;
using Fabric.Infrastructure.Api;
using Nancy;
using System;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public class OauthFuncs : ApiFuncBase {

		private const string DbSvcUrl = "http://localhost:9001/";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthFuncs(DynamicDictionary pQuery) : base(pQuery, new ApiContext(DbSvcUrl)) {}
		
		
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