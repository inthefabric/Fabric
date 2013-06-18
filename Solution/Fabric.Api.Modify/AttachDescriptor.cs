using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Modify {

	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModDescriptorsUri, typeof(bool),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class AttachDescriptor : AttachFactorElement {

		public const string DescTypeParam = "DescriptorTypeId";
		public const string PrimArtRefParam = "PrimaryArtifactRefineId";
		public const string EdgeArtRefParam = "RelatedArtifactRefineId";
		public const string DescTypeRefParam = "DescriptorTypeRefineId";

		[ServiceOpParam(ServiceOpParamType.Form, DescTypeParam, 1, typeof(Factor))]
		private readonly byte vDescTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, PrimArtRefParam, 2, typeof(Artifact),
			DomainPropertyName="ArtifactId", IsRequired=false)]
		private readonly long? vPrimArtRefId;

		[ServiceOpParam(ServiceOpParamType.Form, EdgeArtRefParam, 3, typeof(Artifact),
			DomainPropertyName="ArtifactId", IsRequired=false)]
		private readonly long? vEdgeArtRefId;

		[ServiceOpParam(ServiceOpParamType.Form, DescTypeRefParam, 4, typeof(Artifact),
			DomainPropertyName="ArtifactId", IsRequired=false)]
		private readonly long? vDescTypeRefId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AttachDescriptor(IModifyTasks pTasks, long pFactorId, byte pDescTypeId, 
										long? pPrimArtRefId, long? pEdgeArtRefId, long? pDescTypeRefId) : 
										base(pTasks, pFactorId) {
			vDescTypeId = pDescTypeId; 
			vPrimArtRefId = pPrimArtRefId;
			vEdgeArtRefId = pEdgeArtRefId;
			vDescTypeRefId = pDescTypeRefId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorDescriptor_TypeId(vDescTypeId, DescTypeParam);

			if ( vPrimArtRefId != null ) {
				Tasks.Validator.ArtifactId((long)vPrimArtRefId, PrimArtRefParam);
			}

			if ( vEdgeArtRefId != null ) {
				Tasks.Validator.ArtifactId((long)vEdgeArtRefId, EdgeArtRefParam);
			}

			if ( vDescTypeRefId != null ) {
				Tasks.Validator.ArtifactId((long)vDescTypeRefId, DescTypeRefParam);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Dictionary<string, long> GetRequiredArtifactIds() {
			var map = new Dictionary<string, long>();

			if ( vPrimArtRefId != null ) {
				map.Add(PrimArtRefParam, (long)vPrimArtRefId);
			}

			if ( vEdgeArtRefId != null ) {
				map.Add(EdgeArtRefParam, (long)vEdgeArtRefId);
			}

			if ( vDescTypeRefId != null ) {
				map.Add(DescTypeRefParam, (long)vDescTypeRefId);
			}

			return map;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AddElementToFactor(Factor pFactor) {
			Tasks.UpdateFactorDescriptor(ApiCtx, pFactor, 
				vDescTypeId, vPrimArtRefId, vEdgeArtRefId, vDescTypeRefId);
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