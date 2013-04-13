﻿using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {

	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModDescriptorsUri, typeof(bool),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class AttachDescriptor : AttachFactorElement {

		public const string DescTypeParam = "DescriptorTypeId";
		public const string PrimArtRefParam = "PrimaryArtifactRefineId";
		public const string RelArtRefParam = "RelatedArtifactRefineId";
		public const string DescTypeRefParam = "DescriptorTypeRefineId";

		[ServiceOpParam(ServiceOpParamType.Form, DescTypeParam, 1, typeof(Factor))]
		private readonly byte vDescTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, PrimArtRefParam, 2, typeof(Artifact),
			DomainPropertyName="ArtifactId", IsRequired=false)]
		private readonly long? vPrimArtRefId;

		[ServiceOpParam(ServiceOpParamType.Form, RelArtRefParam, 3, typeof(Artifact),
			DomainPropertyName="ArtifactId", IsRequired=false)]
		private readonly long? vRelArtRefId;

		[ServiceOpParam(ServiceOpParamType.Form, DescTypeRefParam, 4, typeof(Artifact),
			DomainPropertyName="ArtifactId", IsRequired=false)]
		private readonly long? vDescTypeRefId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AttachDescriptor(IModifyTasks pTasks, long pFactorId, byte pDescTypeId, 
										long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId) : 
										base(pTasks, pFactorId) {
			vDescTypeId = pDescTypeId; 
			vPrimArtRefId = pPrimArtRefId;
			vRelArtRefId = pRelArtRefId;
			vDescTypeRefId = pDescTypeRefId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorDescriptor_TypeId(vDescTypeId, DescTypeParam);

			if ( vPrimArtRefId != null ) {
				Tasks.Validator.ArtifactId((long)vPrimArtRefId, PrimArtRefParam);
			}

			if ( vRelArtRefId != null ) {
				Tasks.Validator.ArtifactId((long)vRelArtRefId, RelArtRefParam);
			}

			if ( vDescTypeRefId != null ) {
				Tasks.Validator.ArtifactId((long)vDescTypeRefId, DescTypeRefParam);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void VerifyRequiredNodes() {
			if ( vPrimArtRefId != null && ApiCtx.DbNodeById<Artifact>((long)vPrimArtRefId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), PrimArtRefParam+"="+vPrimArtRefId);
			}

			if ( vRelArtRefId != null && ApiCtx.DbNodeById<Artifact>((long)vRelArtRefId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), PrimArtRefParam+"="+vRelArtRefId);
			}

			if ( vDescTypeRefId != null && ApiCtx.DbNodeById<Artifact>((long)vDescTypeRefId) == null ){
				throw new FabNotFoundFault(typeof(Artifact), DescTypeRefParam+"="+vDescTypeRefId);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AddElementToFactor(Factor pFactor) {
			Tasks.UpdateFactorDescriptor(ApiCtx, pFactor, 
				vDescTypeId, vPrimArtRefId, vRelArtRefId, vDescTypeRefId);
			return true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override string GetElementName() {
			return "Descriptor";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool FactorHasElement(Factor pFactor) {
			return (pFactor.Descriptor_TypeId != null);
		}

	}

}