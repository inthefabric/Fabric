using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class CreateDescriptor : CreateFactorElement<Descriptor> {

		public const string DescTypeParam = "DescriptorTypeId";
		public const string PrimArtRefParam = "PrimaryArtifactRefineId";
		public const string RelArtRefParam = "RelatedArtifactRefineId";
		public const string DescTypeRefParam = "DescriptorTypeRefineId";

		private readonly long vDescTypeId;
		private readonly long? vPrimArtModId;
		private readonly long? vRelArtModId;
		private readonly long? vDescTypeModId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateDescriptor(IModifyTasks pTasks, long pFactorId, long pDescTypeId, 
										long? pPrimArtModId, long? pRelArtModId, long? pDescTypeModId) : 
										base(pTasks, pFactorId) {
			vDescTypeId = pDescTypeId; 
			vPrimArtModId = pPrimArtModId;
			vRelArtModId = pRelArtModId;
			vDescTypeModId = pDescTypeModId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			base.ValidateParams();

			Tasks.Validator.DescriptorTypeId(vDescTypeId, DescTypeParam);

			if ( vPrimArtModId != null ) {
				Tasks.Validator.ArtifactId((long)vPrimArtModId, PrimArtRefParam);
			}

			if ( vRelArtModId != null ) {
				Tasks.Validator.ArtifactId((long)vRelArtModId, RelArtRefParam);
			}

			if ( vDescTypeModId != null ) {
				Tasks.Validator.ArtifactId((long)vDescTypeModId, DescTypeRefParam);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool HasFactorElement(Factor pFactor) {
			return Tasks.HasFactorDescriptor(ApiCtx, pFactor);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Descriptor AddElementToFactor(Factor pFactor, Member pMember) {
			if ( vPrimArtModId != null && Tasks.GetArtifact(ApiCtx, (long)vPrimArtModId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), PrimArtRefParam+"="+vPrimArtModId);
			}

			if ( vRelArtModId != null && Tasks.GetArtifact(ApiCtx, (long)vRelArtModId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), PrimArtRefParam+"="+vRelArtModId);
			}

			if ( vDescTypeModId != null && Tasks.GetArtifact(ApiCtx, (long)vDescTypeModId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), DescTypeRefParam+"="+vDescTypeModId);
			}

			////

			IWeaverVarAlias<Descriptor> descVar;
			var txb = new TxBuilder();

			Tasks.TxAddDescriptor(ApiCtx, txb, vDescTypeId, vPrimArtModId, vRelArtModId, vDescTypeModId,
				pFactor, pMember, out descVar);

			return ApiCtx.DbSingle<Descriptor>("CreateDescriptorTx", txb.Finish(descVar));
		}

	}

}