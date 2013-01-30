using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth {

	/*================================================================================================*/
	public enum LogoutErrors {
		invalid_request,
		logout_failure
	};

	/*================================================================================================*/
	public enum LogoutErrorDescs {
		BadToken = 0,
		NoTokenMatch,
		LogoutFailed,
		Unexpected
	};

	/*================================================================================================*/
	public class OauthLogout : ApiFunc<FabOauthLogout> {

		public static readonly string[] ErrDescStrings = new[] {
			"The access_token is missing or in an invalid format",
			"No tokens match the provided access_token",
			"The logout request failed",
			"An unexpected error occurred"
		};

		private readonly string vToken;
		private readonly IOauthTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthLogout(string pToken, IOauthTasks pTasks) {
			vToken = pToken;
			vTasks = pTasks;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vToken == null || vToken.Length != 32 ) {
				throw GetFault(LogoutErrors.invalid_request, LogoutErrorDescs.BadToken);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthLogout Execute() {
			FabOauthAccess acc = vTasks.GetAccessToken(vToken, ApiCtx);

			if ( acc == null ) {
				throw GetFault(LogoutErrors.invalid_request, LogoutErrorDescs.NoTokenMatch);
			}

			acc = vTasks.DoLogout(acc, ApiCtx);

			if ( acc == null ) {
				throw GetFault(LogoutErrors.logout_failure, LogoutErrorDescs.LogoutFailed);
			}

			var log = new FabOauthLogout();
			log.Success = 1;
			log.AccessToken = vToken;
			return log;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static OauthException GetFault(LogoutErrors pErr, LogoutErrorDescs pDesc) {
			return new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}