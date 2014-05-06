using System;
using System.Text.RegularExpressions;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Faults;

namespace Fabric.Api.Objects.Conversions {

	/*================================================================================================*/
	public static class ApiValidatorsCustom {

		private const string ValidOauthDomainRegex =
			@"^[a-zA-Z0-9]+(:[0-9]+|([\-\.]{1}[a-zA-Z0-9]+)*\.[a-zA-Z]{2,6})$";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateAppOauthDomains(string pName, string pDomains) {
			if ( pDomains == null ) {
				return;
			}

			string[] domainList = pDomains.Split('|');

			foreach ( string dom in domainList ) {
				if ( !Regex.IsMatch(dom, ValidOauthDomainRegex) ) {
					throw new FabPropertyValueFault(pName, dom, "is not a valid OAuth domain.");
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateApp(CreateFabApp pObj) {
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
		public static void ValidateFactorEventor(CreateFabEventor pObj) {
			bool allow = true;
			allow = ValidateFactorEventorItem(CreateFabEventorValidator.MonthName, pObj.Month, allow);
			allow = ValidateFactorEventorItem(CreateFabEventorValidator.DayName, pObj.Day, allow);
			allow = ValidateFactorEventorItem(CreateFabEventorValidator.HourName, pObj.Hour, allow);
			allow = ValidateFactorEventorItem(CreateFabEventorValidator.MinuteName, pObj.Minute, allow);
			allow = ValidateFactorEventorItem(CreateFabEventorValidator.SecondName, pObj.Second, allow);

			string dateStr = pObj.Year+
				(pObj.Month == null ? "" : "-"+pObj.Month)+
				(pObj.Day == null ? "" : "-"+pObj.Day)+
				(pObj.Hour == null ? "" : " "+pObj.Hour)+
				(pObj.Minute == null ? "" : ":"+pObj.Minute)+
				(pObj.Second== null ? "" : ":"+pObj.Second);

			DateTime dt;

			if ( !DateTime.TryParse(dateStr, out dt) ) {
				throw new FabPropertyValueFault(
					typeof(CreateFabEventor).Name+" provides an invalid date/time: "+dateStr);
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
			//do nothing...
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorLocatorValueY(string pName, double pY) {
			//do nothing...
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorLocatorValueZ(string pName, double pZ) {
			//do nothing...
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorLocator(CreateFabLocator pObj) {
			LocatorType.Item lt = LocatorType.Map[(LocatorType.Id)pObj.Type];
			string text = "cannot be %0 than %1 for the '"+lt.Name+"' "+typeof(LocatorType).Name;

			if ( pObj.ValueX < lt.MinX ) {
				throw new FabPropertyOutOfRangeFault(CreateFabLocatorValidator.ValueXName,
					pObj.ValueX, String.Format(text, "less", lt.MinX));
			}

			if ( pObj.ValueX > lt.MaxX ) {
				throw new FabPropertyOutOfRangeFault(CreateFabLocatorValidator.ValueXName,
					pObj.ValueX, String.Format(text, "greater", lt.MaxX));
			}

			if ( pObj.ValueY < lt.MinY ) {
				throw new FabPropertyOutOfRangeFault(CreateFabLocatorValidator.ValueYName,
					pObj.ValueY, String.Format(text, "less", lt.MinY));
			}

			if ( pObj.ValueY > lt.MaxY ) {
				throw new FabPropertyOutOfRangeFault(CreateFabLocatorValidator.ValueYName,
					pObj.ValueY, String.Format(text, "greater", lt.MaxY));
			}

			if ( pObj.ValueZ < lt.MinZ ) {
				throw new FabPropertyOutOfRangeFault(CreateFabLocatorValidator.ValueZName,
					pObj.ValueZ, String.Format(text, "less", lt.MinZ));
			}

			if ( pObj.ValueZ > lt.MaxZ ) {
				throw new FabPropertyOutOfRangeFault(CreateFabLocatorValidator.ValueZName,
					pObj.ValueZ, String.Format(text, "greater", lt.MaxZ));
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorVectorValue(string pName, long pValue) {
			//do nothing...
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidateFactorVector(CreateFabVector pObj) {
			VectorType.Item vt = VectorType.Map[(VectorType.Id)pObj.Type];
			VectorUnitPrefix.Item vup = VectorUnitPrefix.Map[(VectorUnitPrefix.Id)pObj.UnitPrefix];
			double baseVal = pObj.Value*vup.Amount;
			string text = "cannot be %0 than %1 for the '"+vt.Name+"' "+typeof(VectorType).Name;


			if ( baseVal < vt.Min ) {
				throw new FabPropertyOutOfRangeFault(CreateFabVectorValidator.ValueName,
					pObj.Value, String.Format(text, "less", vt.Min));
			}

			if ( baseVal > vt.Max ) {
				throw new FabPropertyOutOfRangeFault(CreateFabVectorValidator.ValueName,
					pObj.Value, String.Format(text, "greater", vt.Max));
			}
		}
		
	}

}