using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;
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
		NoDataProvId,
		BadDataProvId,
		Unexpected
	};

	/*================================================================================================*/
	public class OauthAccessTasks {

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
		public void VerifyApp(IOperationContext pOpCtx, long pAppId, string pClientSecret) {
			IWeaverQuery getApp = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, pAppId)
					.Has(x => x.Secret, WeaverStepHasOp.EqualTo, pClientSecret)
				.ToQuery();

			App app = pOpCtx.Data.Get<App>(getApp, "OauthAccess-VerifyApp");

			if ( app == null ) {
				throw NewFault(AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member GetMemberByGrant(IOperationContext pOpCtx, string pGrantCode, 
																out long pAppId, out long pUserId) {
			IWeaverVarAlias<Member> memAlias;

			IWeaverQuery memQ = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.OauthGrantCode, pGrantCode)
				.ToQueryAsVar("m", out memAlias);

			IWeaverQuery appQ = Weave.Inst.FromVar(memAlias)
				.DefinedByApp.ToApp
					.Property(x => x.VertexId)
				.ToQuery();

			IWeaverQuery userQ = Weave.Inst.FromVar(memAlias)
				.DefinedByUser.ToUser
					.Property(x => x.VertexId)
				.ToQuery();

			IDataAccess acc = pOpCtx.Data.Build();
			acc.AddQuery(memQ, true);
			acc.AddQuery(appQ, true);
			acc.AddQuery(userQ, true);

			IDataResult res = acc.Execute("OauthAccess-GetMemberByGrant");
			pAppId = res.ToLongAt(1, 0);
			pUserId = res.ToLongAt(2, 0);
			return res.ToElementAt<Member>(0, 0);
		} 

		/*--------------------------------------------------------------------------------------------* /
		public Member FindMember(IOperationContext pOpCtx, long pAppId, long pUserId) {
			Member m = pOpCtx.Cache.Memory.FindMember(pAppId, pUserId);

			if ( m != null ) {
				return m;
			}

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.VertexId, pUserId)
				.DefinesMembers
					.Has(x => x.AppId, WeaverStepHasOp.EqualTo, pAppId)
					.ToMember
				.ToQuery();

			m = pOpCtx.Data.Get<Member>(q, "OauthAccess-GetMember");
			pOpCtx.Cache.Memory.AddMember(pAppId, pUserId, m);
			return m;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess AddAccess(IOperationContext pOpCtx, Member pMember,
																			bool pClientMode=false) {
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
		public void ClearOldTokens(IOperationContext pOpCtx, Member pMember) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, pMember.VertexId)
				.AuthenticatedByOauthAccesses.ToOauthAccess
					.SideEffect(
						new WeaverStatementRemoveProperty<OauthAccess>(x => x.Token),
						new WeaverStatementRemoveProperty<OauthAccess>(x => x.Refresh)
					)
				.ToQuery();

			pOpCtx.Data.Execute(q, "OauthAccess-ClearOldTokens");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthException NewFault(AccessErrors pErr, AccessErrorDescs pDesc) {
			return new OauthException(pErr.ToString(), ErrDescStrings[(int)pDesc]);
		}

	}

}