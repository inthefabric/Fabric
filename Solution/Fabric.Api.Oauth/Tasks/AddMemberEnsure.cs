using System;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
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
			if ( vAppId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("AppId");
			}

			if ( vUserId <= 0 ) {
				throw new FabArgumentOutOfRangeFault("UserId");
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
			
			IApiDataAccess data = Context.DbData(Query.GetMemberTx+"", tx);

			if ( data.ResultDtoList == null || data.ResultDtoList.Count == 0 ) {
				pMem = null;
				pMta = null;
				pType = null;
				return false;
			}

			if ( data.ResultDtoList.Count != 3 ) {
				throw new Exception("Incorrect GetMemberData() ResultDtoList.Count.");
			}

			pMem = data.ResultDtoList[0].ToNode<Member>();
			pMta = data.ResultDtoList[1].ToNode<MemberTypeAssign>();
			pType = data.ResultDtoList[2].ToNode<MemberType>();
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
			newMem.MemberId = Context.GetSharpflakeId<Member>();
			
			var memBuild = new MemberBuilder(txb, newMem);
			memBuild.AddNode();
			memBuild.SetInAppDefines(vAppId);
			memBuild.SetInUserDefines(vUserId);

			AddMemberTypeAssignWithTx(txb, memBuild.InRootContains, memBuild.NodeVar);
			Context.DbData(Query.AddMemberTx+"", txb.Finish());
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
				NewPathFromIndex(pAssign).InMemberHas.RemoveEach().End()
			);

			//Move original to use Member-HasHistoric-MemberTypeAssign relationship

			txb.GetNode(pMember, out memVar);
			txb.GetNode(pAssign, out mtaVar);
			txb.AddRel<MemberHasHistoricMemberTypeAssign>(memVar, mtaVar);

			//Finish transaction
			
			AddMemberTypeAssignWithTx(txb, rootVar, memVar);
			Context.DbData(Query.UpdateMemberTx+"", txb.Finish());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberTypeAssignWithTx(TxBuilder pTxBuild, IWeaverVarAlias<Root> pRootVar,
																	IWeaverVarAlias<Member> pMemVar) {
			var newAssign = new MemberTypeAssign();
			newAssign.MemberTypeAssignId = Context.GetSharpflakeId<MemberTypeAssign>();
			newAssign.Performed = Context.UtcNow.Ticks;
			newAssign.Note = "First login.";

			var mtaBuild = new MemberTypeAssignBuilder(pTxBuild, newAssign);
			mtaBuild.AddNode(pRootVar);
			mtaBuild.SetInMemberHas(pMemVar);
			mtaBuild.SetUsesMemberType((long)MemberTypeId.Member);
			mtaBuild.SetInMemberCreates((long)MemberId.FabFabData);
		}

	}

}