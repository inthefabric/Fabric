using System;
using Fabric.Domain;
using Fabric.Infrastructure.Query;
using Weaver.Core.Query;

namespace Fabric.Operations.Oauth {

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
	public class OauthLogoutTasks : IOauthLogoutTasks {

		public static readonly string[] ErrDescStrings = new[] {
			"The access_token is missing or in an invalid format",
			"No tokens match the provided access_token",
			"The logout request failed",
			"An unexpected error occurred"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccess GetAccessToken(IOperationData pData, string pToken) {
			if ( pToken == null || pToken.Length != 32 ) {
				throw NewFault(LogoutErrors.invalid_request, LogoutErrorDescs.BadToken);
			}

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<OauthAccess>(x => x.Token, pToken)
				.ToQuery();

			OauthAccess oa = pData.Get<OauthAccess>(q, "OauthLogout-GetAccessToken");

			if ( oa == null ) {
				throw NewFault(LogoutErrors.invalid_request, LogoutErrorDescs.NoTokenMatch);
			}

			return oa;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DoLogout(IOperationData pData, OauthAccess pAccess) {
			try {
				//OPTIMIZE: don't make a query to get Member (ClearOldTokens does the reverse)

				IWeaverQuery q = Weave.Inst.Graph
					.V.ExactIndex<OauthAccess>(x => x.VertexId, pAccess.VertexId)
					.AuthenticatesMember.ToMember
					.ToQuery();

				Member m = pData.Get<Member>(q, "OauthLogout-GetMember");
				OauthAccessTasks.ClearOldTokens(pData, m.VertexId);
			}
			catch ( Exception ) {
				throw NewFault(LogoutErrors.logout_failure, LogoutErrorDescs.LogoutFailed);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private OauthException NewFault(LogoutErrors pErr, LogoutErrorDescs pDesc) {
			return new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}