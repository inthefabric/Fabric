﻿using Fabric.Api.Web.Results;
using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public class ChangeMemberType : BaseWebFunc<SuccessResult> { //TEST: ChangeMemberType

		public const string AppIdParam = "AppId";
		public const string AssigningMemberIdParam = "AssigningMemberId";
		public const string MemberIdParam = "MemberId";
		public const string MemberTypeIdParam = "MemberTypeId";

		private readonly long vAppId;
		private readonly long vAssigningMemberId;
		private readonly long vMemberId;
		private readonly long vMemberTypeId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ChangeMemberType(IWebTasks pTasks, long pAppId, long pAssigningMemberId, long pMemberId,
																	long pMemberTypeId) : base(pTasks) {
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
			Tasks.Validator.MemberTypeId(vMemberTypeId, MemberTypeIdParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override SuccessResult Execute() {
			Member mem = Tasks.GetMemberOfApp(ApiCtx, vMemberId, vAppId);
			
			if ( mem == null ) {
				throw new FabNotFoundFault(typeof(Member),
					AppIdParam+"="+vAppId+"&"+MemberIdParam+"="+vMemberId);
			}
			
			Member assigningMem = Tasks.GetMemberOfApp(ApiCtx, vAssigningMemberId, vAppId);
			
			if ( assigningMem == null ) {
				throw new FabNotFoundFault(typeof(Member),
					AppIdParam+"="+vAppId+"&"+AssigningMemberIdParam+"="+vAssigningMemberId);
			}
			
			////
			
			MemberTypeAssign mta = Tasks.AddMemberTypeAssign(
				ApiCtx, vAppId, vAssigningMemberId, vMemberId, vMemberTypeId);
			return new SuccessResult(mta != null);
		}

	}

}