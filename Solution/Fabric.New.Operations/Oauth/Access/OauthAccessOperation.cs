using System.Linq;
using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;

namespace Fabric.New.Operations.Oauth.Access {

	/*================================================================================================*/
	public class OauthAccessOperation {

		public const string GrantTypeAc = "authorization_code";
		public const string GrantTypeRt = "refresh_token";
		public const string GrantTypeCc = "client_credentials";

		private IOperationContext vOpCtx;
		private IOauthAccessTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess Execute(IOperationContext pOpCtx, IOauthAccessTasks pTasks,
									string pGrantType, string pClientId, string pSecret, string pCode,
									string pRefresh, string pRedirUri) {
			vOpCtx = pOpCtx;
			vTasks = pTasks;

			switch ( pGrantType ) {
				case GrantTypeAc:
					return ExecuteAt(pCode, pSecret, pRedirUri);

				case GrantTypeRt:
					return ExecuteRt(pRefresh, pSecret, pRedirUri);

				case GrantTypeCc:
					return ExecuteCc(pClientId, pSecret, pRedirUri);
			}

			throw vTasks.NewFault(AccessErrors.unsupported_grant_type, AccessErrorDescs.BadGrantType);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteAt(string pCode, string pSecret, string pRedirUri) {
			Validate(pSecret, pRedirUri);

			if ( pCode == null || pCode.Length <= 0 ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoCode);
			}

			////

			OauthMember om = vTasks.GetMemberByGrant(vOpCtx, pCode);

			if ( om == null ) {
				throw vTasks.NewFault(AccessErrors.invalid_grant, AccessErrorDescs.BadCode);
			}

			if ( pRedirUri.ToLower() != om.Member.OauthGrantRedirectUri ) {
				throw vTasks.NewFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
			}

			vTasks.GetApp(vOpCtx, om.AppId, pSecret);
			return vTasks.AddAccess(vOpCtx, om.Member);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteRt(string pRefresh, string pSecret, string pRedirUri) {
			Validate(pSecret, pRedirUri);

			if ( pRefresh == null || pRefresh.Length <= 0 ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoRefresh);
			}

			////

			OauthMember om = vTasks.GetMemberByRefresh(vOpCtx, pRefresh);

			if ( om == null ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.BadRefresh);
			}

			vTasks.GetApp(vOpCtx, om.AppId, pSecret);
			return vTasks.AddAccess(vOpCtx, om.Member);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteCc(string pClientIdStr, string pSecret, string pRedirUri) {
			Validate(pSecret, pRedirUri);

			long clientId;
			bool parsed = long.TryParse(pClientIdStr, out clientId);
			int protocolI = pRedirUri.IndexOf("://");

			if ( !parsed || clientId <= 0 ) {
				throw vTasks.NewFault(AccessErrors.invalid_client, AccessErrorDescs.NoClientId);
			}

			if ( protocolI <= 0 ) {
				throw vTasks.NewFault(AccessErrors.invalid_grant, AccessErrorDescs.BadRedirUri);
			}

			////

			var domain = pRedirUri.Substring(protocolI+3);
			int slashI = domain.IndexOf("/");
			int wwwI = domain.IndexOf("www.");
			
			if ( slashI > 0 ) {
				domain = domain.Substring(0, slashI);
			}

			if ( wwwI == 0 ) {
				domain = domain.Substring(4);
			}

			////

			App a = vTasks.GetApp(vOpCtx, clientId, pSecret);
			string[] domains = (a.OauthDomains == null ? new string[0] : a.OauthDomains.Split('|'));

			if ( !domains.Contains(domain.ToLower()) ) {
				throw vTasks.NewFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
			}

			Member m = vTasks.GetMemberByApp(vOpCtx, clientId);
			return vTasks.AddAccess(vOpCtx, m, true);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void Validate(string pSecret, string pRedirUri) {
			if ( pSecret == null || pSecret.Length <= 0 ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoClientSecret);
			}

			if ( pRedirUri == null || pRedirUri.Length <= 0 ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoRedirUri);
			}
		}

	}

}