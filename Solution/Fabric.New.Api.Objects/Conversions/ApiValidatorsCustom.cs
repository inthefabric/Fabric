using System;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static class ApiValidatorsCustom {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateAppOauthDomains(string pName, string pDomains) {
			//TODO: ApiValidatorsCustom.ValidateAppOauthDomains()
			throw new NotImplementedException();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorEventorYear(string pName, long pYear) {
			//TODO: ApiValidatorsCustom.ValidateFactorEventorYear()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorEventorMonth(string pName,byte? pMonth){
			//TODO: ApiValidatorsCustom.ValidateFactorEventorMonth()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorEventorDay(string pName, byte? pDay) {
			//TODO: ApiValidatorsCustom.ValidateFactorEventorDay()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorEventorHour(string pName, byte? pHour) {
			//TODO: ApiValidatorsCustom.ValidateFactorEventorHour()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorEventorMinute(string pName, byte? pMin){
			//TODO: ApiValidatorsCustom.ValidateFactorEventorMinute()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorEventorSecond(string pName, byte? pSec){
			//TODO: ApiValidatorsCustom.ValidateFactorEventorSecond()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------* /
		protected override void ValidateElementParams() {
			if ( vYear == 0 ) {
				throw new FabArgumentValueFault(YearParam, 0);
			}

			bool allow = true;
			allow = ValidateRange(YearParam, vYear, -100000000000, 100000000000, allow); // +/- 100B
			allow = ValidateRange(MonthParam, vMonth, 1, 12, allow);
			allow = ValidateRange(DayParam, vDay, 1, 31, allow);
			allow = ValidateRange(HourParam, vHour, 0, 23, allow);
			allow = ValidateRange(MinuteParam, vMinute, 0, 59, allow);
			ValidateRange(SecondParam, vSecond, 0, 59, allow);
		}

		/*--------------------------------------------------------------------------------------------* /
		private bool ValidateRange(string pName, long? pValue, long pMin, long pMax, bool pAllow) {
			if ( pValue == null ) {
				return false;
			}

			if ( !pAllow ) {
				throw new FabArgumentValueFault(pName+" cannot be specified without prior parameters.");
			}

			DomainValidator.LongBetween(pName, (long)pValue, pMin, pMax);
			return true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorLocatorValueX(string pName, double pX) {
			//TODO: ApiValidatorsCustom.ValidateFactorLocatorValueX()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorLocatorValueY(string pName, double pY) {
			//TODO: ApiValidatorsCustom.ValidateFactorLocatorValueY()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorLocatorValueZ(string pName, double pZ) {
			//TODO: ApiValidatorsCustom.ValidateFactorLocatorValueZ()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------* /
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorLocator_TypeId(vLocTypeId, LocTypeParam);

			////

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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorVectorValue(string pName, long pValue) {
			//TODO: ApiValidatorsCustom.ValidateFactorVectorValue()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------* /
		protected override void ValidateElementParams() {
			VectorType vecType = StaticTypes.VectorTypes[vVecTypeId];
			double baseVal = vValue*VectorUnitPrefix.GetMult(vVecUnitPrefId);

			if ( baseVal < vecType.Min ) {
				throw new FabArgumentOutOfRangeFault(ValueParam+" is less than VectorType.Min.");
			}

			if ( baseVal > vecType.Max ) {
				throw new FabArgumentOutOfRangeFault(ValueParam+" is greater than VectorType.Max.");
			}
		}*/

	}

}