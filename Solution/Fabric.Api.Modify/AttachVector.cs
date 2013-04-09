﻿using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain.Types;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModVectorsUri, typeof(bool),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class AttachVector : AttachFactorElement {

		public const string VecTypeParam = "VectorTypeId";
		public const string ValueParam = "Value";
		public const string AxisArtParam = "AxisArtifactId";
		public const string UnitParam = "VectorUnitId";
		public const string UnitPrefParam = "VectorUnitPrefixId";

		[ServiceOpParam(ServiceOpParamType.Form, VecTypeParam, 1, typeof(Factor))]
		private readonly byte vVecTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, ValueParam, 2, typeof(Factor))]
		private readonly long vValue;

		[ServiceOpParam(ServiceOpParamType.Form, AxisArtParam, 3, typeof(Artifact),
			DomainPropertyName="ArtifactId")]
		private readonly long vAxisArtId;

		[ServiceOpParam(ServiceOpParamType.Form, UnitParam, 4, typeof(Factor))]
		private readonly byte vVecUnitId;

		[ServiceOpParam(ServiceOpParamType.Form, UnitPrefParam, 5, typeof(Factor))]
		private readonly byte vVecUnitPrefId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AttachVector(IModifyTasks pTasks, long pFactorId, byte pVecTypeId, long pValue,
					long pAxisArtId, byte pVecUnitId, byte pVecUnitPrefId) : base(pTasks, pFactorId) {
			vVecTypeId = pVecTypeId; 
			vValue = pValue;
			vAxisArtId = pAxisArtId;
			vVecUnitId = pVecUnitId;
			vVecUnitPrefId = pVecUnitPrefId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorVector_TypeId(vVecTypeId, VecTypeParam);
			Tasks.Validator.ArtifactId(vAxisArtId, AxisArtParam);
			Tasks.Validator.FactorVector_UnitId(vVecUnitId, UnitParam);
			Tasks.Validator.FactorVector_UnitPrefixId(vVecUnitPrefId, UnitPrefParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AddElementToFactor(Factor pFactor, Member pMember) {
			if ( Tasks.GetArtifact(ApiCtx, vAxisArtId) == null ) {
				throw new FabNotFoundFault(typeof(Artifact), AxisArtParam+"="+vAxisArtId);
			}

			////
			
			VectorType vecType = StaticTypes.VectorTypes[vVecTypeId];
			double baseVal = vValue*VectorUnitPrefix.GetMult(vVecUnitPrefId);
			
			if ( baseVal < vecType.Min ) {
				throw new FabArgumentOutOfRangeFault(ValueParam+" is less than VectorType.Min.");
			}
			
			if ( baseVal > vecType.Max ) {
				throw new FabArgumentOutOfRangeFault(ValueParam+" is greater than VectorType.Max.");
			}
			
			////
			
			Tasks.UpdateFactorVector(ApiCtx, pFactor, vVecTypeId, vValue,
				vAxisArtId, vVecUnitId, vVecUnitPrefId);
			return true;
		}

	}

}