using System;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class AddMemberEnsure : ApiFunc<bool> {

		public enum Query {
			GetMemberTx,
			AddMemberTx,
			UpdateMemberTx
		}
		
		private readonly long vAppId;
		private readonly long vUserId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AddMemberEnsure(long pAppId, long pUserId) {
			vAppId = pAppId;
			vUserId = pUserId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vAppId == 0 ) {
				throw new FabArgumentValueFault("AppId", 0);
			}

			if ( vUserId == 0 ) {
				throw new FabArgumentValueFault("UserId", 0);
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool Execute() {
			Member mem;
			MemberTypeAssign mta;

			bool hasMember = GetMemberData(out mem, out mta);

			if ( !hasMember ) {
				AddMember();
				return true;
			}
			
			if ( AcceptableMembershipExists(mta) ) {
				return false;
			}

			UpdateMemberType(mem, mta);
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private bool GetMemberData(out Member pMem, out MemberTypeAssign pMta) {
			var tx = new WeaverTransaction();
			IWeaverStepAs<Member> memberAlias;
			IWeaverVarAlias aggVar;

			tx.AddQuery(
				WeaverQuery.InitListVar("_V0", out aggVar)
			);

			tx.AddQuery(
				Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.ArtifactId, vUserId)
				.DefinesMemberList.ToMember
					.As(out memberAlias)
				.InAppDefines.FromApp
					.Has(x => x.ArtifactId, WeaverStepHasOp.EqualTo, vAppId)
				.Back(memberAlias)
					.Aggregate(aggVar)
				.HasMemberTypeAssign.ToMemberTypeAssign
					.Aggregate(aggVar)
					.Iterate()
				.ToQuery()
			);

			tx.Finish(aggVar);

			////
			
			IApiDataAccess data = ApiCtx.DbData(Query.GetMemberTx+"", tx);
			int count = data.GetResultCount();

			if ( count <= 0 ) {
				pMem = null;
				pMta = null;
				return false;
			}

			if ( count != 2 ) {
				throw new Exception("Incorrect result count: "+count);
			}

			pMem = data.GetResultAt<Member>(0);
			pMta = data.GetResultAt<MemberTypeAssign>(1);
			return true;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private bool AcceptableMembershipExists(MemberTypeAssign pMemTypeAssn) {
			switch ( pMemTypeAssn.MemberTypeId ) {
				case (byte)MemberTypeId.None:
				case (byte)MemberTypeId.Invite:
				case (byte)MemberTypeId.Request:
					return false;
			}
			
			return true;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddMember() {
			var txb = new TxBuilder();
			
			var newMem = new Member();
			newMem.MemberId = ApiCtx.GetSharpflakeId<Member>();
			
			var memBuild = new MemberBuilder(txb, newMem);
			memBuild.AddVertex();
			memBuild.SetInAppDefines(vAppId);
			memBuild.SetInUserDefines(vUserId);

			AddMemberTypeAssignWithTx(txb, memBuild.VertexVar);
			ApiCtx.DbData(Query.AddMemberTx+"", txb.Finish());
		}

		/*--------------------------------------------------------------------------------------------*/
		private void UpdateMemberType(Member pMember, MemberTypeAssign pAssign) {
			var txb = new TxBuilder();
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<MemberTypeAssign> mtaVar;

			txb.GetVertex(pAssign, out mtaVar);
			
			//Remove original Member-Has-MemberTypeAssign relationship

			txb.Transaction.AddQuery(
				Weave.Inst.FromVar(mtaVar)
				.InMemberHas
					.Remove()
				.ToQuery()
			);

			//Move original to use Member-HasHistoric-MemberTypeAssign relationship

			txb.GetVertex(pMember, out memVar);
			txb.AddRel<MemberHasHistoricMemberTypeAssign>(memVar, mtaVar);

			//Finish transaction
			
			AddMemberTypeAssignWithTx(txb, memVar);
			ApiCtx.DbData(Query.UpdateMemberTx+"", txb.Finish());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberTypeAssignWithTx(TxBuilder pTxBuild, IWeaverVarAlias<Member> pMemVar) {
			var newAssign = new MemberTypeAssign();
			newAssign.MemberTypeAssignId = ApiCtx.GetSharpflakeId<MemberTypeAssign>();
			newAssign.MemberTypeId = (byte)MemberTypeId.Member;
			newAssign.Performed = ApiCtx.UtcNow.Ticks;
			newAssign.Note = "First login.";

			var mtaBuild = new MemberTypeAssignBuilder(pTxBuild, newAssign);
			mtaBuild.AddVertex();
			mtaBuild.SetInMemberHas(pMemVar);
			mtaBuild.SetInMemberCreates((long)MemberId.FabFabData);
		}

	}

}