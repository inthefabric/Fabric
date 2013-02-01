using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class CreateFactor : BaseModifyFunc<Factor> {

		public const string PrimArtParam = "PrimaryArtifactId";
		public const string RelArtParam = "RelatedArtifactId";
		public const string AssertParam = "FactorAssertId";
		public const string IsDefParam = "IsDefining";
		public const string NoteParam = "Note";

		private readonly long vPrimArtId;
		private readonly long vRelArtId;
		private readonly long vAssertId;
		private readonly bool vIsDefining;
		private readonly string vNote;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFactor(IModifyTasks pTasks, long pPrimArtId, long pRelArtId, long pAssertId, 
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
			Tasks.Validator.FactorAssertionId(vAssertId, AssertParam);
			Tasks.Validator.FactorNote(vNote, NoteParam);

			if ( vPrimArtId == vRelArtId ) {
				throw new FabArgumentFault(PrimArtParam+" cannot be equal to "+RelArtParam);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Factor Execute() {
			if ( Tasks.GetArtifact(ApiCtx, vPrimArtId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), PrimArtParam+"="+vPrimArtId);
			}

			if ( Tasks.GetArtifact(ApiCtx, vRelArtId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), RelArtParam+"="+vRelArtId);
			}

			Member m = GetContextMember();

			////

			IWeaverVarAlias<Factor> factorVar;

			var txb = new TxBuilder();

			Tasks.TxAddFactor(ApiCtx, txb, vPrimArtId, vRelArtId, vAssertId, 
				vIsDefining, vNote, m, out factorVar);
			
			txb.RegisterVarWithTxBuilder(factorVar);
			return ApiCtx.DbSingle<Factor>("CreateFactorTx", txb.Finish(factorVar));
		}

	}

}