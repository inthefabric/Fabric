using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModEventorsUri, typeof(bool),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class AttachEventor : AttachFactorElement {

		public const string EveTypeParam = "EventorTypeId";
		public const string EvePrecParam = "EventorPrecisionId";
		public const string DateTimeParam = "DateTime";

		[ServiceOpParam(ServiceOpParamType.Form, EveTypeParam, 1, typeof(Factor))]
		private readonly byte vEveTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, EvePrecParam, 2, typeof(Factor))]
		private readonly byte vEvePrecId;

		[ServiceOpParam(ServiceOpParamType.Form, DateTimeParam, 3, typeof(Factor))]
		private readonly long vDateTime;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AttachEventor(IModifyTasks pTasks, long pFactorId, byte pEveTypeId, 
										byte pEvePrecId, long pDateTime) : base(pTasks, pFactorId) {
			vEveTypeId = pEveTypeId; 
			vEvePrecId = pEvePrecId;
			vDateTime = pDateTime;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorEventor_TypeId(vEveTypeId, EveTypeParam);
			Tasks.Validator.FactorEventor_PrecisionId(vEvePrecId, EvePrecParam);
			Tasks.Validator.FactorEventor_DateTime(vDateTime, DateTimeParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AddElementToFactor(Factor pFactor, Member pMember) {
			Tasks.AttachEventor(ApiCtx, pFactor, vEveTypeId, vEvePrecId, vDateTime);
			return true;
		}

	}

}