using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class CreateDescriptor : CreateFactorElement<Descriptor> { //TEST: CreateDescriptor

		public const string DescTypeParam = "DescriptorTypeId";
		public const string PrimArtRefParam = "PrimaryArtifactRefineId";
		public const string RelArtRefParam = "RelatedArtifactRefineId";
		public const string DescTypeRefParam = "DescriptorTypeRefineId";

		private readonly long vDescTypeId;
		private readonly long? vPrimArtRefId;
		private readonly long? vRelArtRefId;
		private readonly long? vDescTypeRefId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateDescriptor(IModifyTasks pTasks, long pFactorId, long pDescTypeId, 
										long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId) : 
										base(pTasks, pFactorId) {
			vDescTypeId = pDescTypeId; 
			vPrimArtRefId = pPrimArtRefId;
			vRelArtRefId = pRelArtRefId;
			vDescTypeRefId = pDescTypeRefId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			base.ValidateParams();

			Tasks.Validator.DescriptorTypeId(vDescTypeId, DescTypeParam);

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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool FactorHasElement(Factor pFactor) {
			return Tasks.FactorHasDescriptor(ApiCtx, pFactor);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Descriptor AddElementToFactor(Factor pFactor, Member pMember) {
			if ( vPrimArtRefId != null && Tasks.GetArtifact(ApiCtx, (long)vPrimArtRefId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), PrimArtRefParam+"="+vPrimArtRefId);
			}

			if ( vRelArtRefId != null && Tasks.GetArtifact(ApiCtx, (long)vRelArtRefId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), PrimArtRefParam+"="+vRelArtRefId);
			}

			if ( vDescTypeRefId != null && Tasks.GetArtifact(ApiCtx, (long)vDescTypeRefId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), DescTypeRefParam+"="+vDescTypeRefId);
			}

			////

			Descriptor desc = Tasks.GetDescriptorMatch(
				ApiCtx, vDescTypeId, vPrimArtRefId, vRelArtRefId, vDescTypeRefId);

			if ( desc != null ) {
				Tasks.AttachExistingElement<Descriptor, FactorUsesDescriptor>(ApiCtx, pFactor, desc);
				return desc;
			}

			////

			IWeaverVarAlias<Descriptor> descVar;
			var txb = new TxBuilder();

			Tasks.TxAddDescriptor(ApiCtx, txb, vDescTypeId, 
				vPrimArtRefId, vRelArtRefId, vDescTypeRefId, pFactor, out descVar);

			return ApiCtx.DbSingle<Descriptor>("CreateDescriptorTx", txb.Finish(descVar));
		}

	}

}