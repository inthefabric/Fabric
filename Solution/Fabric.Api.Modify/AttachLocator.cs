using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain.Types;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModLocatorsUri, typeof(bool),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class AttachLocator : AttachFactorElement {
		
		public const string LocTypeParam = "LocatorTypeId";
		public const string XParam = "ValueX";
		public const string YParam = "ValueY";
		public const string ZParam = "ValueZ";

		[ServiceOpParam(ServiceOpParamType.Form, LocTypeParam, 1, typeof(Factor))]
		private readonly byte vLocTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, XParam, 2, typeof(Factor))]
		private readonly double vX;

		[ServiceOpParam(ServiceOpParamType.Form, YParam, 3, typeof(Factor))]
		private readonly double vY;

		[ServiceOpParam(ServiceOpParamType.Form, ZParam, 4, typeof(Factor))]
		private readonly double vZ;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AttachLocator(IModifyTasks pTasks, long pFactorId, byte pLocTypeId, 
										double pX, double pY, double pZ) : base(pTasks, pFactorId) {
			vLocTypeId = pLocTypeId; 
			vX = pX;
			vY = pY;
			vZ = pZ;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorLocator_TypeId(vLocTypeId, LocTypeParam);
			CheckLocatorTypeRange();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AddElementToFactor(Factor pFactor, Member pMember) {
			Tasks.UpdateFactorLocator(ApiCtx, pFactor, vLocTypeId, vX, vY, vZ);
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckLocatorTypeRange() {
			LocatorType locType = StaticTypes.LocatorTypes[vLocTypeId];
			const string lessThan = " is less than LocatorType.Min";
			const string greaterThan = " is greater than LocatorType.Max";
			
			if ( vX < locType.MinX ) {
				throw new FabArgumentOutOfRangeFault(XParam+lessThan+"X.");
			}
			
			if ( vX > locType.MaxX ) {
				throw new FabArgumentOutOfRangeFault(XParam+greaterThan+".");
			}
			
			if ( vY < locType.MinY ) {
				throw new FabArgumentOutOfRangeFault(YParam+lessThan+"Y.");
			}
			
			if ( vY > locType.MaxY ) {
				throw new FabArgumentOutOfRangeFault(YParam+greaterThan+"Y.");
			}
			
			if ( vZ < locType.MinZ ) {
				throw new FabArgumentOutOfRangeFault(ZParam+lessThan+"Z.");
			}
			
			if ( vZ > locType.MaxZ ) {
				throw new FabArgumentOutOfRangeFault(ZParam+greaterThan+"Z.");
			}
		}
	}

}