using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;

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
	public class OauthLogout : SvcFunc<FabOauthLogout> {

		public static string[] ErrDescStrings = new[] {
			"The access_token is missing or in an invalid format",
			"No tokens match the provided access_token",
			"The logout request failed",
			"An unexpected error occurred"
		};

		private readonly string vToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthLogout(string pToken) : base(AuthType.None) {
			vToken = pToken;
			AddTransactionFunc(DoLogout);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vToken == null || vToken.Length != 32 ) {
				ThrowFault(LogoutErrors.invalid_request, LogoutErrorDescs.BadToken);
			}
		}
			
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoLogout(ISession pSession) {
			FabOauthAccess acc;
			OAuthAccessResult logoutResult;

			try {
				acc = new GetAccessToken(vToken).Go(Context);
			}
			catch ( Exception e ) {
				ThrowFaultOnException(e);
				return;
			}

			if ( acc == null ) {
				ThrowFault(LogoutErrors.invalid_request, LogoutErrorDescs.NoTokenMatch);
				return;
			}

			try {
				logoutResult = new DoLogout(acc).Go(Context);
			}
			catch ( Exception e ) {
				ThrowFaultOnException(e);
				return;
			}
			
			if ( logoutResult == null ) {
				ThrowFault(LogoutErrors.logout_failure, LogoutErrorDescs.LogoutFailed);
				return;
			}

			var log = new FabOauthLogout();
			log.success = 1;
			log.access_token = vToken;
			SetResult(log);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void ThrowFaultOnException(Exception pEx) {
			Log.Error("FOAuthLogout", pEx);
			ThrowFault(LogoutErrors.invalid_request, LogoutErrorDescs.Unexpected);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected void ThrowFault(LogoutErrors pErr, LogoutErrorDescs pDesc) {
			throw new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}