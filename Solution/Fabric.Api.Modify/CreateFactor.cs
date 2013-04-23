using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModFactorsUri, typeof(FabFactor),
		Auth=ServiceAuthType.Member)]
	public class CreateFactor : BaseModifyFunc<Factor> {

		public const string PrimArtParam = "PrimaryArtifactId";
		public const string RelArtParam = "RelatedArtifactId";
		public const string AssertParam = "FactorAssertionId";
		public const string IsDefParam = "IsDefining";
		public const string NoteParam = "Note";

		[ServiceOpParam(ServiceOpParamType.Form, PrimArtParam, 0, typeof(Artifact),
			DomainPropertyName="ArtifactId")]
		private readonly long vPrimArtId;

		[ServiceOpParam(ServiceOpParamType.Form, RelArtParam, 1, typeof(Artifact),
			DomainPropertyName="ArtifactId")]
		private readonly long vRelArtId;

		[ServiceOpParam(ServiceOpParamType.Form, AssertParam, 2, typeof(Factor))]
		private readonly byte vAssertId;

		[ServiceOpParam(ServiceOpParamType.Form, IsDefParam, 3, typeof(Factor))]
		private readonly bool vIsDefining;

		[ServiceOpParam(ServiceOpParamType.Form, NoteParam, 4, typeof(Factor), IsRequired=false)]
		private readonly string vNote;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFactor(IModifyTasks pTasks, long pPrimArtId, long pRelArtId, byte pAssertId, 
														bool pIsDefining, string pNote) : base(pTasks) {
			vPrimArtId = pPrimArtId;
			vRelArtId = pRelArtId;
			vAssertId = pAssertId;
			vIsDefining = pIsDefining;
			vNote = pNote;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.ArtifactId(vPrimArtId, PrimArtParam);
			Tasks.Validator.ArtifactId(vRelArtId, RelArtParam);
			Tasks.Validator.FactorFactorAssertionId(vAssertId, AssertParam);
			Tasks.Validator.FactorNote(vNote, NoteParam);

			if ( vPrimArtId == vRelArtId ) {
				throw new FabArgumentValueFault(PrimArtParam+" cannot be equal to "+RelArtParam);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void VerifyRequiredNodes() {
			if ( ApiCtx.DbNodeById<Artifact>(vPrimArtId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), PrimArtParam+"="+vPrimArtId);
			}

			if ( ApiCtx.DbNodeById<Artifact>(vRelArtId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), RelArtParam+"="+vRelArtId);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Factor Execute() {
			VerifyRequiredNodes();
			Member m = GetContextMember();

			IWeaverVarAlias<Factor> factorVar;

			var txb = new TxBuilder();

			Tasks.TxAddFactor(ApiCtx, txb, vPrimArtId, vRelArtId, vAssertId, 
				vIsDefining, vNote, m, out factorVar);
			
			txb.RegisterVarWithTxBuilder(factorVar);
			return ApiCtx.DbSingle<Factor>("CreateFactorTx", txb.Finish(factorVar));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal void ValidateParamsForBatch() {
			ValidateParams();
		}

		/*--------------------------------------------------------------------------------------------*/
		internal void VerifyRequiredNodesForBatch(IApiContext pApiCtx) {
			SetApiCtx(pApiCtx);
			VerifyRequiredNodes();
		}

	}

}