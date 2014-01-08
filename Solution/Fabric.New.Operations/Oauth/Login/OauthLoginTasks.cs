using System.Linq;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Operations.Create;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Weaver.Core.Steps.Statements;

namespace Fabric.New.Operations.Oauth.Login {

	/*================================================================================================*/
	public enum LoginErrors { //from section "4.1.2.1. Error Response"
		invalid_request,
		unauthorized_client,
		access_denied,
		unsupported_response_type,
		invalid_scope,
		server_error,
		temporarily_unavailable
	};

	/*================================================================================================*/
	public enum LoginErrorDescs {
		LoginCancel = 0,
		AccessDeny,
		BadRespType,
		NoRedirUri,
		BadRedirUri,
		NoClient,
		BadClient,
		RedirMismatch,
		BadSwitch,
		Unexpected
	};

	/*================================================================================================*/
	public class OauthLoginTasks : IOauthLoginTasks {
		
		public static string[] ErrDescStrings = new [] {
			"Login cancelled by user",
			"Access request denied by user",
			"The response_type is invalid",
			"The redirect_uri was not supplied",
			"The redirect_uri must be an absolute path",
			"A numeric client_id was not supplied",
			"The client_id is invalid",
			"The redirect_uri is not valid for the client_id",
			"The optional switch value must be 0 or 1.",
			"An unexpected error occurred"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public long AppIdToLong(string pAppId) {
			long appId;

			if ( long.TryParse(pAppId, out appId) ) {
				if ( appId > 0 ) {
					return appId;
				}
			}

			throw NewFault(LoginErrors.unauthorized_client, LoginErrorDescs.NoClient);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VerifyAppDomain(App pApp, string pRedirectUri) {
			string domain = GetDomainFromRedirUri(pRedirectUri);

			if ( domain == null ) {
				throw NewFault(LoginErrors.invalid_request, LoginErrorDescs.BadRedirUri);
			}

			string[] domains = (pApp.OauthDomains == null ? null : pApp.OauthDomains.Split('|'));

			if ( domains == null || !domains.Contains(domain.ToLower()) ) {
				throw NewFault(LoginErrors.invalid_request, LoginErrorDescs.RedirMismatch);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetDomainFromRedirUri(string pRedirectUri) {
			int protocolI = pRedirectUri.IndexOf("://");

			if ( protocolI <= 0 ) {
				return null;
			}

			var dom = pRedirectUri.Substring(protocolI+3);
			int slashI = dom.IndexOf("/");
			int wwwI = dom.IndexOf("www.");

			if ( slashI > 0 ) {
				dom = dom.Substring(0, slashI);
			}

			if ( wwwI == 0 ) {
				dom = dom.Substring(4);
			}

			return dom;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public App GetApp(IOperationData pData, long pAppId) {
			App app = pData.GetVertexById<App>(pAppId);

			if ( app == null ) {
				throw NewFault(LoginErrors.unauthorized_client, LoginErrorDescs.BadClient);
			}

			return app;
		}

		/*--------------------------------------------------------------------------------------------*/
		public User GetUser(IOperationData pData, long pUserId) {
			return pData.GetVertexById<User>(pUserId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public User GetUserByCredentials(IOperationData pData, string pUsername, string pPassword) {
			IWeaverQuery q = 
				Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.NameKey, pUsername.ToLower())
					.Has(x => x.Password, WeaverStepHasOp.EqualTo, DataUtil.HashPassword(pPassword))
				.ToQuery();

			return pData.Get<User>(q, "OauthGrant-GetUserByCredentials");
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member GetMember(IOperationData pData, long pAppId, long pUserId) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.VertexId, pUserId)
					.DefinesMembers
						.Has(x => x.AppId, WeaverStepHasOp.EqualTo, pAppId)
						.ToMember
				.ToQuery();

			return pData.Get<Member>(q, "OauthGrant-GetMember");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Member AddMember(IOperationContext pOpCtx, long pAppId, long pUserId) {
			var m = new CreateFabMember();
			m.DefinedByAppId = pAppId;
			m.DefinedByUserId = pUserId;
			m.Type = (byte)MemberType.Id.Member;

			var op = new CreateMemberOperation();
			return op.Execute(pOpCtx, new CreateOperationBuilder(), new CreateOperationTasks(), m);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void DenyScope(IOperationData pData, Member pMember) {
			pMember.OauthScopeAllow = false;

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, pMember.VertexId)
					.SideEffect(
						new WeaverStatementSetProperty<Member>(
							x => x.OauthScopeAllow, pMember.OauthScopeAllow)
					)
				.ToQuery();

			pData.Execute(q, "OauthGrant-DenyScope");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void UpdateGrant(IOperationContext pOpCtx, Member pMember, string pRedirectUri) {
			pMember.OauthScopeAllow = true;
			pMember.OauthGrantCode = pOpCtx.Code32;
			pMember.OauthGrantExpires = pOpCtx.UtcNow.AddMinutes(2).Ticks;
			pMember.OauthGrantRedirectUri = pRedirectUri.ToLower();

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, pMember.VertexId)
					.SideEffect(
						new WeaverStatementSetProperty<Member>(
							x => x.OauthScopeAllow, pMember.OauthScopeAllow),
						new WeaverStatementSetProperty<Member>(
							x => x.OauthGrantCode, pMember.OauthGrantCode),
						new WeaverStatementSetProperty<Member>(
							x => x.OauthGrantExpires, pMember.OauthGrantExpires),
						new WeaverStatementSetProperty<Member>(
							x => x.OauthGrantRedirectUri, pMember.OauthGrantRedirectUri)
					)
				.ToQuery();

			pOpCtx.Data.Execute(q, "OauthGrant-UpdateGrant");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthException NewFault(LoginErrors pErr, LoginErrorDescs pDesc) {
			return new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}