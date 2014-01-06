using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Operations.Create;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Weaver.Core.Steps.Statements;

namespace Fabric.New.Operations.Oauth.Access {

	/*================================================================================================*/
	public enum AccessErrors { //from section "5.2. Error Response"
		invalid_request,
		invalid_client,
		invalid_grant,
		unauthorized_client,
		unsupported_grant_type,
		invalid_scope
	};

	/*================================================================================================*/
	public enum AccessErrorDescs {
		BadGrantType = 0,
		NoRedirUri,
		BadRedirUri,
		NoCode,
		NoRefresh,
		NoClientId,
		NoClientSecret,
		BadCode,
		BadRefresh,
		RedirMismatch,
		BadClientSecret,
		Unexpected
	};

	/*================================================================================================*/
	public class OauthAccessTasks : IOauthAccessTasks {

		public static readonly string[] ErrDescStrings = new [] {
			"The grant_type is invalid",
			"The redirect_uri was not supplied",
			"The redirect_uri must be an absolute path",
			"The code was not supplied",
			"The refresh_token was not supplied",
			"The client_id was not supplied",
			"The client_secret was not supplied",
			"The code is invalid or expired",
			"The refresh_token is invalid or expired",
			"The redirect_uri does not match this code",
			"The client_secret does not match the client_id",
			"The data_prov_userid was not supplied.",
			"The data_prov_userid does not match the client_id",
			"An unexpected error occurred"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public App GetApp(IOperationData pData, long pAppId, string pClientSecret) {
			IWeaverQuery getApp = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, pAppId)
					.Has(x => x.Secret, WeaverStepHasOp.EqualTo, pClientSecret)
				.ToQuery();

			App app = pData.Get<App>(getApp, "OauthAccess-GetApp");

			if ( app == null ) {
				throw NewFault(AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
			}

			return app;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthMember GetMemberByGrant(IOperationData pData, string pGrantCode) {
			Member path = Weave.Inst.Graph.V.ExactIndex<Member>(x => x.OauthGrantCode, pGrantCode);
			return GetOauthMember(pData, path, "GetMemberByGrant");
		}

		/*--------------------------------------------------------------------------------------------*/
		public OauthMember GetMemberByRefresh(IOperationData pData, string pGrantCode) {
			Member path = Weave.Inst.Graph.V.ExactIndex<Member>(x => x.OauthGrantCode, pGrantCode);
			return GetOauthMember(pData, path, "GetMemberByRefresh");
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member GetMemberByApp(IOperationData pData, long pAppId) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, pAppId)
				.DefinesMembers
					.Has(x => x.MemberType, WeaverStepHasOp.EqualTo, (byte)MemberType.Id.DataProv)
					.ToMember
				.ToQuery();

			return pData.Get<Member>(q, "OauthAccess-GetMemberByApp");
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthMember GetOauthMember(IOperationData pData, Member pMemPath, string pName) {
			IWeaverVarAlias<Member> memAlias;
			IWeaverQuery memQ = pMemPath.ToQueryAsVar("m", out memAlias);

			IWeaverQuery appQ = Weave.Inst.FromVar(memAlias)
				.DefinedByApp.ToApp
					.Property(x => x.VertexId)
				.ToQuery();

			IDataAccess acc = pData.Build();
			acc.AddQuery(memQ, true);
			acc.AddQuery(appQ, true);

			IDataResult res = acc.Execute("OauthAccess-"+pName);

			var om = new OauthMember();
			om.Member = res.ToElementAt<Member>(0, 0);
			om.AppId = res.ToLongAt(1, 0);
			return om;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess AddAccess(IOperationContext pOpCtx, Member pMember,
																			bool pClientMode=false) {
			ClearOldTokens(pOpCtx.Data, pMember.VertexId);

			const int expireSec = 3600;

			CreateFabOauthAccess coa = new CreateFabOauthAccess();
			coa.Token = pOpCtx.Code32;
			coa.Refresh = (pClientMode ? null : pOpCtx.Code32);
			coa.IsDataProv = pClientMode;
			coa.Expires = pOpCtx.UtcNow.AddSeconds(expireSec).Ticks;
			coa.AuthenticatesMemberId = pMember.VertexId;

			var op = new CreateOauthAccessOperation();
			OauthAccess result = 
				op.Execute(pOpCtx, new CreateOperationBuilder(), new CreateOperationTasks(), coa);

			return new FabOauthAccess {
				AccessToken = result.Token,
				RefreshToken = result.Refresh,
				ExpiresIn = expireSec,
				TokenType = "bearer"
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ClearOldTokens(IOperationData pData, long pMemberId) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, pMemberId)
				.AuthenticatedByOauthAccesses.ToOauthAccess
					.SideEffect(
						new WeaverStatementRemoveProperty<OauthAccess>(x => x.Token),
						new WeaverStatementRemoveProperty<OauthAccess>(x => x.Refresh)
					)
				.ToQuery();

			pData.Execute(q, "OauthAccess-ClearOldTokens");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthException NewFault(AccessErrors pErr, AccessErrorDescs pDesc) {
			return new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}