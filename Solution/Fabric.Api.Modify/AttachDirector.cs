using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModDirectorsUri, typeof(bool),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class AttachDirector : AttachFactorElement {

		public const string DirTypeParam = "DirectorTypeId";
		public const string PrimActionParam = "PrimaryDirectorActionId";
		public const string RelActionParam = "RelatedDirectorActionId";

		[ServiceOpParam(ServiceOpParamType.Form, DirTypeParam, 1, typeof(Factor))]
		private readonly byte vDescTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, PrimActionParam, 2, typeof(Factor),
			DomainPropertyName="DirectorActionId")]
		private readonly byte vPrimActId;

		[ServiceOpParam(ServiceOpParamType.Form, RelActionParam, 3, typeof(Factor),
			DomainPropertyName="DirectorActionId")]
		private readonly byte vRelActId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AttachDirector(IModifyTasks pTasks, long pFactorId, byte pDescTypeId, 
											byte pPrimActId, byte pRelActId) : base(pTasks, pFactorId) {
			vDescTypeId = pDescTypeId; 
			vPrimActId = pPrimActId;
			vRelActId = pRelActId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorDirector_TypeId(vDescTypeId, DirTypeParam);
			Tasks.Validator.FactorDirector_PrimaryActionId(vPrimActId, PrimActionParam);
			Tasks.Validator.FactorDirector_RelatedActionId(vRelActId, RelActionParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AddElementToFactor(Factor pFactor) {
			Tasks.UpdateFactorDirector(ApiCtx, pFactor, vDescTypeId, vPrimActId, vRelActId);
			return true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override string GetElementName() {
			return "Director";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool FactorHasElement(Factor pFactor) {
			return (pFactor.Director_TypeId != null);
		}

	}

}