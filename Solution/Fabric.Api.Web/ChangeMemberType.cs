using Fabric.Api.Web.Results;
using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public class ChangeMemberType : BaseWebFunc<SuccessResult> {

		public const string AppIdParam = "AppId";
		public const string AssigningMemberIdParam = "AssigningMemberId";
		public const string MemberIdParam = "MemberId";
		public const string MemberTypeIdParam = "MemberTypeId";

		private readonly long vAppId;
		private readonly long vAssigningMemberId;
		private readonly long vMemberId;
		private readonly byte vMemberTypeId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ChangeMemberType(IWebTasks pTasks, long pAppId, long pAssigningMemberId, long pMemberId,
																	byte pMemberTypeId) : base(pTasks) {
			vAppId = pAppId;
			vAssigningMemberId = pAssigningMemberId;
			vMemberId = pMemberId;
			vMemberTypeId = pMemberTypeId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.AppId(vAppId, AppIdParam);
			Tasks.Validator.MemberId(vAssigningMemberId, AssigningMemberIdParam);
			Tasks.Validator.MemberId(vMemberId, MemberIdParam);
			Tasks.Validator.MemberTypeAssignMemberTypeId(vMemberTypeId, MemberTypeIdParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override SuccessResult Execute() {
			ConfirmTargetMember();
			ConfirmAssigningMember();
			
			MemberTypeAssign newMta = Tasks.AddMemberTypeAssign(
				ApiCtx, vAssigningMemberId, vMemberId, vMemberTypeId);
			return new SuccessResult(newMta != null);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void ConfirmTargetMember() {
			Member mem = Tasks.GetMemberOfApp(ApiCtx, vAppId, vMemberId);

			if ( mem == null ) {
				throw new FabNotFoundFault(typeof(Member),
					AppIdParam+"="+vAppId+"&"+MemberIdParam+"="+vMemberId);
			}

			MemberTypeAssign mta = Tasks.GetMemberTypeAssignByMember(ApiCtx, vMemberId);

			if ( mta.MemberTypeId == (byte)MemberTypeId.DataProvider ) {
				throw new FabPreventedFault(FabFault.Code.ActionNotPermitted,
					"The DataProvider's "+typeof(MemberType).Name+" cannot be changed.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ConfirmAssigningMember() {
			Member assignMem = Tasks.GetMemberOfApp(ApiCtx, vAppId, vAssigningMemberId);

			if ( assignMem == null ) {
				throw new FabNotFoundFault(typeof(Member),
					AppIdParam+"="+vAppId+"&"+AssigningMemberIdParam+"="+vAssigningMemberId);
			}

			MemberTypeAssign assignMta = Tasks.GetMemberTypeAssignByMember(ApiCtx, vAssigningMemberId);

			switch ( assignMta.MemberTypeId ) {
				case (byte)MemberTypeId.DataProvider:
				case (byte)MemberTypeId.Admin:
				case (byte)MemberTypeId.Owner:
				case (byte)MemberTypeId.Staff:
					break;

				default:
					throw new FabPreventedFault(FabFault.Code.ActionNotPermitted,
						"The DataProvider's "+typeof(MemberType).Name+" cannot be changed.");
			}
		}

	}

}