using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Weaver.Core.Steps.Statements;

namespace Fabric.New.Operations.Web {

	/*================================================================================================*/
	public class WebUpdateMemberTypeOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Member Execute(IOperationContext pOpCtx, long pMemberId, MemberType.Id pTypeId) {
			IWeaverVarAlias<Member> memAlias;

			IWeaverQuery memQ = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, pMemberId)
				.ToQueryAsVar("m", out memAlias);

			IWeaverQuery userQ = Weave.Inst.FromVar(memAlias)
				.DefinedByUser.ToUser
					.Property(x => x.VertexId)
					.ToQuery();

			IWeaverQuery appQ = Weave.Inst.FromVar(memAlias)
				.DefinedByApp.ToApp
					.Property(x => x.VertexId)
					.ToQuery();

			IDataAccess acc = pOpCtx.Data.Build();
			acc.AddSessionStart();
			acc.AddQuery(memQ, true);
			acc.OmitResultsOfLatestCommand();
			acc.AddQuery(userQ, true);
			acc.AddQuery(appQ, true);
			acc.AddSessionClose();
			IDataResult memRes = acc.Execute("Web-GetMemberDetails");

			long userId = memRes.ToLongAt(2, 0);
			long appId = memRes.ToLongAt(3, 0);

			////

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, pMemberId)
					.SideEffect(new WeaverStatementSetProperty<Member>(
						x => x.MemberType, (byte)pTypeId))
				.DefinedByUser.ToUser
				.DefinesMembers
					.Has(x => x.AppId, WeaverStepHasOp.EqualTo, appId)
					.SideEffect(new WeaverStatementSetProperty<UserDefinesMember>(
						x => x.MemberType, (byte)pTypeId))
				.ToMember
				.DefinedByApp.ToApp
				.DefinesMembers
					.Has(x => x.UserId, WeaverStepHasOp.EqualTo, userId)
					.SideEffect(new WeaverStatementSetProperty<AppDefinesMember>(
						x => x.MemberType, (byte)pTypeId))
				.ToMember
				.ToQuery();

			return pOpCtx.Data.Get<Member>(q, "Web-UpdateMemberType");
		}

	}

}