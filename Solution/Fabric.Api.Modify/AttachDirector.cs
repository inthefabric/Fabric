using System.Collections.Generic;
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
		public const string EdgeActionParam = "RelatedDirectorActionId";

		[ServiceOpParam(ServiceOpParamType.Form, DirTypeParam, 1, typeof(Factor))]
		private readonly byte vDirTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, PrimActionParam, 2, typeof(Factor),
			DomainPropertyName="DirectorActionId")]
		private readonly byte vPrimActId;

		[ServiceOpParam(ServiceOpParamType.Form, EdgeActionParam, 3, typeof(Factor),
			DomainPropertyName="DirectorActionId")]
		private readonly byte vEdgeActId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AttachDirector(IModifyTasks pTasks, long pFactorId, byte pDirTypeId, 
											byte pPrimActId, byte pEdgeActId) : base(pTasks, pFactorId) {
			vDirTypeId = pDirTypeId; 
			vPrimActId = pPrimActId;
			vEdgeActId = pEdgeActId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorDirector_TypeId(vDirTypeId, DirTypeParam);
			Tasks.Validator.FactorDirector_PrimaryActionId(vPrimActId, PrimActionParam);
			Tasks.Validator.FactorDirector_RelatedActionId(vEdgeActId, EdgeActionParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Dictionary<string, long> GetRequiredArtifactIds() { return null; }

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AddElementToFactor(Factor pFactor) {
			Tasks.UpdateFactorDirector(ApiCtx, pFactor, vDirTypeId, vPrimActId, vEdgeActId);
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