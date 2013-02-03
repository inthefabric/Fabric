﻿using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class CreateLocator : CreateFactorElement<Locator> { //TEST: CreateLocator

		//FAB
		//2/3 10:10am
		//2/3 10:50am
		//Implemented CreateLocator func/tasks and some tests.
		//2/3 1:10pm
		//2/3 x
		//
		
		public const string LocTypeParam = "LocatorTypeId";
		public const string XParam = "ValueX";
		public const string YParam = "ValueY";
		public const string ZParam = "ValueZ";

		private readonly long vLocTypeId;
		private readonly double vX;
		private readonly double vY;
		private readonly double vZ;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateLocator(IModifyTasks pTasks, long pFactorId, long pLocTypeId, 
										double pX, double pY, double pZ) : base(pTasks, pFactorId) {
			vLocTypeId = pLocTypeId; 
			vX = pX;
			vY = pY;
			vZ = pZ;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.LocatorTypeId(vLocTypeId, LocTypeParam);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool FactorHasElement(Factor pFactor) {
			return Tasks.FactorHasLocator(ApiCtx, pFactor);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Locator AddElementToFactor(Factor pFactor, Member pMember) {
			CheckLocatorTypeRange();
			
			////
			
			Locator loc = Tasks.GetLocatorMatch(ApiCtx, vLocTypeId, vX, vY, vZ);

			if ( loc != null ) {
				Tasks.AttachExistingElement<Locator, FactorUsesLocator>(ApiCtx, pFactor, loc);
				return loc;
			}

			////

			IWeaverVarAlias<Locator> locVar;
			var txb = new TxBuilder();

			Tasks.TxAddLocator(ApiCtx, txb, vLocTypeId, vX, vY, vZ, pFactor, out locVar);

			txb.RegisterVarWithTxBuilder(locVar);
			return ApiCtx.DbSingle<Locator>("CreateLocatorTx", txb.Finish(locVar));
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckLocatorTypeRange() {
			LocatorType locType = Tasks.GetLocatorType(ApiCtx, vLocTypeId);
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