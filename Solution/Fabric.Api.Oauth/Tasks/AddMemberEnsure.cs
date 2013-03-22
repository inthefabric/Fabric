using System;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

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
			MemberType mt;

			bool hasMember = GetMemberData(out mem, out mta, out mt);

			if ( !hasMember ) {
				AddMember();
				return true;
			}
			
			if ( AcceptableMembershipExists(mt) ) {
				return false;
			}

			UpdateMemberType(mem, mta);
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private bool GetMemberData(out Member pMem, out MemberTypeAssign pMta, out MemberType pType) {
			var tx = new WeaverTransaction();
			IWeaverFuncAs<Member> memberAlias;
			IWeaverVarAlias aggVar;

			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out aggVar)
			);

			tx.AddQuery(
				NewPathFromIndex(new User { UserId = vUserId })
				.DefinesMemberList.ToMember
					.As(out memberAlias)
				.InAppDefines.FromApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, vAppId)
				.Back(memberAlias)
					.Aggregate(aggVar)
				.HasMemberTypeAssign.ToMemberTypeAssign
					.Aggregate(aggVar)
				.UsesMemberType.ToMemberType
					.Aggregate(aggVar)
					.Iterate()
				.End()
			);

			tx.FinishWithoutStartStop(aggVar);

			////
			
			IApiDataAccess data = ApiCtx.DbData(Query.GetMemberTx+"", tx);
			int count = data.GetResultCount();

			if ( count <= 0 ) {
				pMem = null;
				pMta = null;
				pType = null;
				return false;
			}

			if ( count != 3 ) {
				throw new Exception("Incorrect result count: "+count);
			}

			pMem = data.GetResultAt<Member>(0);
			pMta = data.GetResultAt<MemberTypeAssign>(1);
			pType = data.GetResultAt<MemberType>(2);
			return true;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private bool AcceptableMembershipExists(MemberType pType) {
			switch ( pType.MemberTypeId ) {
				case (long)MemberTypeId.None:
				case (long)MemberTypeId.Invite:
				case (long)MemberTypeId.Request:
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
			memBuild.AddNode();
			memBuild.SetInAppDefines(vAppId);
			memBuild.SetInUserDefines(vUserId);

			AddMemberTypeAssignWithTx(txb, memBuild.InRootContains, memBuild.NodeVar);
			ApiCtx.DbData(Query.AddMemberTx+"", txb.Finish());
		}

		/*--------------------------------------------------------------------------------------------*/
		private void UpdateMemberType(Member pMember, MemberTypeAssign pAssign) {
			var txb = new TxBuilder();
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<MemberTypeAssign> mtaVar;
			
			txb.GetRoot(out rootVar);
			
			//Remove original Member-Has-MemberTypeAssign relationship

			txb.Transaction.AddQuery(
				NewPathFromIndex(pAssign)
				.InMemberHas
					.RemoveEach()
				.End()
			);

			//Move original to use Member-HasHistoric-MemberTypeAssign relationship

			txb.GetNode(pMember, out memVar);
			txb.GetNode(pAssign, out mtaVar);
			txb.AddRel<MemberHasHistoricMemberTypeAssign>(memVar, mtaVar);

			//Finish transaction
			
			AddMemberTypeAssignWithTx(txb, rootVar, memVar);
			ApiCtx.DbData(Query.UpdateMemberTx+"", txb.Finish());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberTypeAssignWithTx(TxBuilder pTxBuild, IWeaverVarAlias<Root> pRootVar,
																	IWeaverVarAlias<Member> pMemVar) {
			var newAssign = new MemberTypeAssign();
			newAssign.MemberTypeAssignId = ApiCtx.GetSharpflakeId<MemberTypeAssign>();
			newAssign.Performed = ApiCtx.UtcNow.Ticks;
			newAssign.Note = "First login.";

			var mtaBuild = new MemberTypeAssignBuilder(pTxBuild, newAssign);
			mtaBuild.AddNode(pRootVar);
			mtaBuild.SetInMemberHas(pMemVar);
			mtaBuild.SetUsesMemberType((long)MemberTypeId.Member);
			mtaBuild.SetInMemberCreates((long)MemberId.FabFabData);
		}

	}

}