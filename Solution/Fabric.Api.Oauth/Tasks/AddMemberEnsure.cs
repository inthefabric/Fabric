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
	public class AddMemberEnsure : ApiFunc<bool> { //TEST: AddMemberEnsure

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
			/*Member mem = pSession.QueryOver<Member>()
				.Where(g => g.App.Id == vAppId.Id && g.Usr.Id == vUserId.Id)
				.Take(1)
				.SingleOrDefault();

			//only SaveOrUpdate if no membership, or if it's none/invite/request

			if ( mem == null ) {
				mem = new Member();
				mem.App = pSession.Load<App>(vAppId.Id);
				mem.Usr = pSession.Load<Usr>(vUserId.Id);
			}
			else {
				switch ( mem.MemberType.Id ) {
					case (int)MemberTypeIds.None:
					case (int)MemberTypeIds.Invite:
					case (int)MemberTypeIds.Request:
						break;

					default:
						return false;
				}
			}
			
			mem.MemberType = pSession.Load<MemberType>((byte)MemberTypeIds.Member);
			mem.Updated = GetDbNow(pSession);
			pSession.SaveOrUpdate(mem);*/

			IApiDataAccess getData = GetMemberData();

			if ( getData == null ) {
				AddMember();
				return true;
			}

			MemberType mt = getData.ResultDtoList[2].ToNode<MemberType>();

			if ( AcceptableMembershipExists(mt) ) {
				return false;
			}

			Member mem = getData.ResultDtoList[0].ToNode<Member>();
			MemberTypeAssign mta = getData.ResultDtoList[1].ToNode<MemberTypeAssign>();
			UpdateMemberType(mem, mta);
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess GetMemberData() {
			var tx = new WeaverTransaction();
			IWeaverFuncAs<Member> memberAlias;
			IWeaverVarAlias getListVar;

			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out getListVar)
			);

			tx.AddQuery(
				NewPathFromIndex(new User { UserId = vUserId })
				.DefinesMemberList.ToMember
					.As(out memberAlias)
				.InAppDefines.FromApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, vAppId)
				.Back(memberAlias)
					.Aggregate(getListVar)
				.HasMemberTypeAssign.ToMemberTypeAssign
					.Aggregate(getListVar)
				.UsesMemberType.ToMemberType
					.Aggregate(getListVar)
				.End()
			);

			tx.Finish(WeaverTransaction.ConclusionType.Success, getListVar);

			////
			
			IApiDataAccess data = Context.DbData(Query.GetMemberTx+"", tx);

			if ( data.ResultDtoList == null || data.ResultDtoList.Count == 0 ) {
				return null;
			}

			if ( data.ResultDtoList.Count != 3 ) {
				throw new Exception("Incorrect GetMemberData() ResultDtoList.Count.");
			}

			return data;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private bool AcceptableMembershipExists(MemberType pType) {
			switch ( pType.MemberTypeId ) {
				case (byte)MemberTypeId.None:
				case (byte)MemberTypeId.Invite:
				case (byte)MemberTypeId.Request:
					return true;
			}

			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddMember() {
			var tx = new WeaverTransaction();
			AddMemberWithTx(tx);
			tx.Finish(WeaverTransaction.ConclusionType.Success);
			Context.DbData(Query.AddMemberTx+"", tx);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberWithTx(IWeaverTransaction pTx) {
			var txb = new TxBuilder();

			var newMem = new Member();
			newMem.MemberId = Context.GetSharpflakeId<Member>();

			ITxBuilderVar<Root> rootVar;
			ITxBuilderVar<Member> memVar;
			ITxBuilderVar<App> appVar;
			ITxBuilderVar<User> userVar;

			//Add Member node

			txb.AddNode<Member, RootContainsMember>(newMem, out rootVar, out memVar);

			//Add App-Defines-Member relationship

			txb.GetNode(new App { AppId = vAppId }, out appVar);
			txb.AddRel<AppDefinesMember>(appVar, memVar);

			//Add User-Defines-Member relationship

			txb.GetNode(new User { UserId = vUserId }, out userVar);
			txb.AddRel<UserDefinesMember>(userVar, memVar);

			AddMemberTypeAssignWithTx(txb, /*rootVar,*/ memVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberTypeAssignWithTx(TxBuilder pTxBuild, ITxBuilderVar<Member> pMemVar) {
			IWeaverTransaction tx = pTxBuild.Transaction;

			var newAssign = new MemberTypeAssign();
			newAssign.MemberTypeAssignId = Context.GetSharpflakeId<MemberTypeAssign>();

			ITxBuilderVar<Root> rootVar;
			ITxBuilderVar<MemberTypeAssign> mtaVar;
			ITxBuilderVar<MemberType> mtVar;
			ITxBuilderVar<Member> creatorVar;

			//Add MemberTypeAssign node

			pTxBuild.AddNode<MemberTypeAssign, RootContainsMemberTypeAssign>(
				newAssign, out rootVar, out mtaVar);

			//Add Member-Has-MemberTypeAssign relationship

			pTxBuild.AddRel<MemberHasMemberTypeAssign>(pMemVar, mtaVar);

			//Add MemberTypeAssign-Uses-MemberType relationship

			pTxBuild.GetNode(new MemberType { MemberTypeId = (byte)MemberTypeId.Member }, out mtVar);
			pTxBuild.AddRel<MemberTypeAssignUsesMemberType>(mtaVar, mtVar);

			//Add Member-Creates-MemberTypeAssign relationship

			pTxBuild.GetNode(new Member { MemberId = (byte)MemberId.FabFabData }, out creatorVar);
			pTxBuild.AddRel<MemberCreatesMemberTypeAssign>(creatorVar, mtaVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void UpdateMemberType(Member pMember, MemberTypeAssign pAssign) {
			var txb = new TxBuilder();
			ITxBuilderVar<Member> memVar;
			ITxBuilderVar<MemberTypeAssign> mtaVar;

			//Remove original Member-Has-MemberTypeAssign relationship

			txb.Transaction.AddQuery(
				NewPathFromIndex(pAssign).InMemberHas.RemoveEach().End()
			);

			//Move original to use Member-HasHistoric-MemberTypeAssign relationship

			txb.GetNode(pMember, out memVar);
			txb.GetNode(pAssign, out mtaVar);
			txb.AddRel<MemberHasHistoricMemberTypeAssign>(memVar, mtaVar);

			//Finish transaction

			AddMemberTypeAssignWithTx(txb, memVar);
			Context.DbData(Query.UpdateMemberTx+"", txb.Finish());
		}

	}

}