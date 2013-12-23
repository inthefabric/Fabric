using System;
using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;

namespace Fabric.New.Operations.Oauth.Access {

	/*================================================================================================*/
	public class OauthAccessOperation {

		public const string GrantTypeAc = "authorization_code";
		public const string GrantTypeRt = "refresh_token";
		public const string GrantTypeCc = "client_credentials";
		public const string GrantTypeCd = "client_dataprov";

		private IOperationContext vOpCtx;
		private OauthAccessTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess Execute(IOperationContext pOpCtx, OauthAccessTasks pTasks,
									string pGrantType, string pClientId, string pSecret, string pCode,
									string pRefresh, string pRedirUri, string pDataProvId) {
			vOpCtx = pOpCtx;
			vTasks = pTasks;

			switch ( pGrantType ) {
				case GrantTypeAc:
					return ExecuteAt(pCode, pSecret, pRedirUri);

				case GrantTypeRt:
					return ExecuteRt(pRefresh, pSecret, pRedirUri);

				case GrantTypeCc:
					return ExecuteCc(pClientId, pSecret, pRedirUri);

				case GrantTypeCd:
					return ExecuteCd(pDataProvId);
			}

			throw vTasks.NewFault(AccessErrors.unsupported_grant_type, AccessErrorDescs.BadGrantType);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteAt(string pCode, string pSecret, string pRedirUri) {
			ValidateClientSecret(pSecret);
			ValidateRedirUri(pRedirUri);

			if ( pCode == null || pCode.Length <= 0 ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoCode);
			}

			long appId;
			long userId;
			Member m = vTasks.GetMemberByGrant(vOpCtx, pCode, out appId, out userId);

			if ( m == null ) {
				throw vTasks.NewFault(AccessErrors.invalid_grant, AccessErrorDescs.BadCode);
			}

			if ( pRedirUri.ToLower() != m.OauthGrantRedirectUri ) {
				throw vTasks.NewFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
			}

			vTasks.VerifyApp(vOpCtx, appId, pSecret);
			vTasks.ClearOldTokens(vOpCtx, m);
			return vTasks.AddAccess(vOpCtx, m);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteRt(string pRefresh, string pSecret, string pRedirUri) {
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteCc(string pClientId, string pSecret, string pRedirUri) {
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteCd(string pDataProvId) {
			throw new NotImplementedException();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void ValidateClientSecret(string pClientSecret) {
			if ( pClientSecret == null || pClientSecret.Length <= 0 ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoClientSecret);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateRedirUri(string pRedirectUri) {
			if ( pRedirectUri == null || pRedirectUri.Length <= 0 ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoRedirUri);
			}
		}

	}

}