using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Db.Data;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class CreateVector : CreateFactorElement<Vector> {

		public const string VecTypeParam = "VectorTypeId";
		public const string ValueParam = "Value";
		public const string AxisArtParam = "AxisArtifactId";
		public const string UnitParam = "VectorUnitId";
		public const string UnitPrefParam = "VectorUnitPrefixId";

		private readonly long vVecTypeId;
		private readonly long vValue;
		private readonly long vAxisArtId;
		private readonly long vVecUnitId;
		private readonly long vVecUnitPrefId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateVector(IModifyTasks pTasks, long pFactorId, long pVecTypeId, long pValue,
					long pAxisArtId, long pVecUnitId, long pVecUnitPrefId) : base(pTasks, pFactorId) {
			vVecTypeId = pVecTypeId; 
			vValue = pValue;
			vAxisArtId = pAxisArtId;
			vVecUnitId = pVecUnitId;
			vVecUnitPrefId = pVecUnitPrefId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.VectorTypeId(vVecTypeId, VecTypeParam);
			Tasks.Validator.ArtifactId(vAxisArtId, AxisArtParam);
			Tasks.Validator.VectorUnitId(vVecUnitId, UnitParam);
			Tasks.Validator.VectorUnitPrefixId(vVecUnitPrefId, UnitPrefParam);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool FactorHasElement(Factor pFactor) {
			return Tasks.FactorHasVector(ApiCtx, pFactor);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Vector AddElementToFactor(Factor pFactor, Member pMember) {
			if ( Tasks.GetArtifact(ApiCtx, vAxisArtId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), AxisArtParam+"="+vAxisArtId);
			}
			
			////
			
			VectorType vecType = Tasks.GetVectorType(ApiCtx, vVecTypeId);
			double baseVal = vValue*VectorUnitPrefixConst.GetMult(vVecUnitPrefId);
			
			if ( baseVal < vecType.Min ) {
				throw new FabArgumentOutOfRangeFault(ValueParam+" is less than VectorType.Min.");
			}
			
			if ( baseVal > vecType.Max ) {
				throw new FabArgumentOutOfRangeFault(ValueParam+" is greater than VectorType.Max.");
			}
			
			////
			
			Vector vec = Tasks.GetVectorMatch(ApiCtx, vVecTypeId,
				vValue, vAxisArtId, vVecUnitId, vVecUnitPrefId);

			if ( vec != null ) {
				Tasks.AttachExistingElement<Vector, FactorUsesVector>(ApiCtx, pFactor, vec);
				return vec;
			}

			////

			IWeaverVarAlias<Vector> vecVar;
			var txb = new TxBuilder();

			Tasks.TxAddVector(ApiCtx, txb, vVecTypeId, vValue,
				vAxisArtId, vVecUnitId, vVecUnitPrefId, pFactor, out vecVar);

			txb.RegisterVarWithTxBuilder(vecVar);
			return ApiCtx.DbSingle<Vector>("CreateVectorTx", txb.Finish(vecVar));
		}

	}

}