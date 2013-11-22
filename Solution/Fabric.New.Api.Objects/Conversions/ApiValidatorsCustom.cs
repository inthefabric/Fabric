using System;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static class ApiValidatorsCustom {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateAppOauthDomains(string pName, string pDomains) {
			//TODO: ApiValidatorsCustom.ValidateAppOauthDomains()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateApp(CreateFabApp pCreateObj) {
			//do nothing...
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorEventorYear(string pName, long pYear) {
			if ( pYear == 0 ) {
				throw new FabPropertyValueFault(pName, pYear+"", "cannot be zero.");
			}

			CreateFabObjectValidator.Range(pName, pYear, -100000000000, 100000000000);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorEventor(CreateFabEventor pCreateObj) {
			bool allow = true;
			allow = ValidateFactorEventorItem("Month", pCreateObj.Month, allow);
			allow = ValidateFactorEventorItem("Day", pCreateObj.Day, allow);
			allow = ValidateFactorEventorItem("Hour", pCreateObj.Hour, allow);
			allow = ValidateFactorEventorItem("Minute", pCreateObj.Minute, allow);
			allow = ValidateFactorEventorItem("Second", pCreateObj.Second, allow);

			string dateStr = pCreateObj.Year+
				(pCreateObj.Month == null ? "" : "-"+pCreateObj.Month)+
				(pCreateObj.Day == null ? "" : "-"+pCreateObj.Day)+
				(pCreateObj.Hour == null ? "" : "-"+pCreateObj.Hour)+
				(pCreateObj.Minute == null ? "" : "-"+pCreateObj.Minute)+
				(pCreateObj.Second== null ? "" : "-"+pCreateObj.Second);

			DateTime dt;

			if ( !DateTime.TryParse(dateStr, out dt) ) {
				throw new FabPropertyValueFault(
					"The Eventor does not specify a valid date/time: "+dateStr);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static bool ValidateFactorEventorItem(string pName, long? pValue, bool pAllow) {
			if ( pValue == null ) {
				return false;
			}

			if ( !pAllow ) {
				throw new FabPropertyValueFault(pName, pValue+"",
					"cannot be specified without prior parameters.");
			}

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

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorLocator(CreateFabLocator pCreateObj) {
			throw new NotImplementedException();

			/*LocatorType locType = StaticTypes.LocatorTypes[vLocTypeId];
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
			}*/
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorVectorValue(string pName, long pValue) {
			//TODO: ApiValidatorsCustom.ValidateFactorVectorValue()
			throw new NotImplementedException();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorVector(CreateFabVector pCreateObj) {
			throw new NotImplementedException();

			/*VectorType vecType = StaticTypes.VectorTypes[vVecTypeId];
			double baseVal = vValue*VectorUnitPrefix.GetMult(vVecUnitPrefId);

			if ( baseVal < vecType.Min ) {
				throw new FabArgumentOutOfRangeFault(ValueParam+" is less than VectorType.Min.");
			}

			if ( baseVal > vecType.Max ) {
				throw new FabArgumentOutOfRangeFault(ValueParam+" is greater than VectorType.Max.");
			}*/
		}
		
	}

}