using System.Linq;
using Fabric.Api.Objects.Oauth;
using Fabric.Domain;
using Fabric.Operations.Create;

namespace Fabric.Operations.Oauth {

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
					return ExecuteAc(pCode, pSecret, pRedirUri);

				case GrantTypeRt:
					return ExecuteRt(pRefresh, pSecret, pRedirUri);

				case GrantTypeCc:
					return ExecuteCc(pClientId, pSecret, pRedirUri);
			}

			throw vTasks.NewFault(AccessErrors.unsupported_grant_type, AccessErrorDescs.BadGrantType);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteAc(string pCode, string pSecret, string pRedirUri) {
			Validate(pSecret, pRedirUri);

			if ( string.IsNullOrEmpty(pCode) ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoCode);
			}

			OauthMember om = vTasks.GetMemberByGrant(vOpCtx.Data, pCode);

			if ( om == null ) {
				throw vTasks.NewFault(AccessErrors.invalid_grant, AccessErrorDescs.BadCode);
			}

			if ( pRedirUri.ToLower() != om.Member.OauthGrantRedirectUri ) {
				throw vTasks.NewFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
			}

			vTasks.GetApp(vOpCtx.Data, om.AppId, pSecret);
			return vTasks.AddAccess(vOpCtx, new CreateOauthAccessOperation(), om.Member.VertexId);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteRt(string pRefresh, string pSecret, string pRedirUri) {
			Validate(pSecret, pRedirUri);

			if ( string.IsNullOrEmpty(pRefresh) ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoRefresh);
			}

			OauthMember om = vTasks.GetMemberByRefresh(vOpCtx.Data, pRefresh);

			if ( om == null ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.BadRefresh);
			}

			vTasks.GetApp(vOpCtx.Data, om.AppId, pSecret);
			return vTasks.AddAccess(vOpCtx, new CreateOauthAccessOperation(), om.Member.VertexId);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess ExecuteCc(string pClientIdStr, string pSecret, string pRedirUri) {
			Validate(pSecret, pRedirUri);

			long clientId;
			bool parsed = long.TryParse(pClientIdStr, out clientId);

			if ( !parsed || clientId <= 0 ) {
				throw vTasks.NewFault(AccessErrors.invalid_client, AccessErrorDescs.NoClientId);
			}

			string domain = OauthLoginTasks.GetDomainFromRedirUri(pRedirUri);

			if ( domain == null ) {
				throw vTasks.NewFault(AccessErrors.invalid_grant, AccessErrorDescs.BadRedirUri);
			}

			App app = vTasks.GetApp(vOpCtx.Data, clientId, pSecret);
			string[] domains = (app.OauthDomains == null ? null : app.OauthDomains.Split('|'));

			if ( domains == null || !domains.Contains(domain.ToLower()) ) {
				throw vTasks.NewFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
			}

			Member mem = vTasks.GetDataProvMemberByApp(vOpCtx.Data, clientId);
			return vTasks.AddAccess(vOpCtx, new CreateOauthAccessOperation(), mem.VertexId, true);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void Validate(string pSecret, string pRedirUri) {
			if ( string.IsNullOrEmpty(pSecret) ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoClientSecret);
			}

			if ( string.IsNullOrEmpty(pRedirUri) ) {
				throw vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoRedirUri);
			}
		}

	}

}