using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModFactorsUri, typeof(FabFactor),
		Auth=ServiceAuthType.Member)]
	public class CreateFactor : BaseModifyFunc<Factor> {

		public const string PrimArtParam = "PrimaryArtifactId";
		public const string EdgeArtParam = "RelatedArtifactId";
		public const string AssertParam = "FactorAssertionId";
		public const string IsDefParam = "IsDefining";
		public const string NoteParam = "Note";

		[ServiceOpParam(ServiceOpParamType.Form, PrimArtParam, 0, typeof(Artifact),
			DomainPropertyName="ArtifactId")]
		private readonly long vPrimArtId;

		[ServiceOpParam(ServiceOpParamType.Form, EdgeArtParam, 1, typeof(Artifact),
			DomainPropertyName="ArtifactId")]
		private readonly long vEdgeArtId;

		[ServiceOpParam(ServiceOpParamType.Form, AssertParam, 2, typeof(Factor))]
		private readonly byte vAssertId;

		[ServiceOpParam(ServiceOpParamType.Form, IsDefParam, 3, typeof(Factor))]
		private readonly bool vIsDefining;

		[ServiceOpParam(ServiceOpParamType.Form, NoteParam, 4, typeof(Factor), IsRequired=false)]
		private readonly string vNote;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFactor(IModifyTasks pTasks, long pPrimArtId, long pEdgeArtId, byte pAssertId, 
														bool pIsDefining, string pNote) : base(pTasks) {
			vPrimArtId = pPrimArtId;
			vEdgeArtId = pEdgeArtId;
			vAssertId = pAssertId;
			vIsDefining = pIsDefining;
			vNote = pNote;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.ArtifactId(vPrimArtId, PrimArtParam);
			Tasks.Validator.ArtifactId(vEdgeArtId, EdgeArtParam);
			Tasks.Validator.FactorFactorAssertionId(vAssertId, AssertParam);
			Tasks.Validator.FactorNote(vNote, NoteParam);

			if ( vPrimArtId == vEdgeArtId ) {
				throw new FabArgumentValueFault(PrimArtParam+" cannot be equal to "+EdgeArtParam);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void VerifyRequiredVertices() {
			if ( ApiCtx.GetVertexById<Artifact>(vPrimArtId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), PrimArtParam+"="+vPrimArtId);
			}

			if ( ApiCtx.GetVertexById<Artifact>(vEdgeArtId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), EdgeArtParam+"="+vEdgeArtId);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Factor Execute() {
			VerifyRequiredVertices();
			Member m = GetContextMember();

			IWeaverVarAlias<Factor> factorVar;
			var txb = new TxBuilder();

			Tasks.TxAddFactor(ApiCtx, txb, vPrimArtId, vEdgeArtId, vAssertId, 
				vIsDefining, vNote, m, out factorVar);
			
			txb.RegisterVarWithTxBuilder(factorVar);
			return ApiCtx.Get<Factor>(txb.Finish(factorVar));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal void ValidateParamsForBatch() {
			ValidateParams();
		}

		/*--------------------------------------------------------------------------------------------*/
		internal Dictionary<string, long> GetRequiredArtifactIdsForBatch() {
			var map = new Dictionary<string, long>();
			map.Add(PrimArtParam, vPrimArtId);
			map.Add(EdgeArtParam, vEdgeArtId);
			return map;
		}

	}

}