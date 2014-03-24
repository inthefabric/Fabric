using System;
using System.Text.RegularExpressions;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public abstract class CreateFabObjectValidator {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected CreateFabObjectValidator(CreateFabObject pCreateObj) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void Validate() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void NotNull(string pName, string pValue) {
			if ( pValue == null ) {
				throw new FabPropertyNullFault(pName);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Range(string pName, long? pValue, long pMin, long pMax) {
			if ( pValue != null && (pValue < pMin || pValue > pMax) ) {
				throw new FabPropertyOutOfRangeFault(pName, (long)pValue,
					"cannot be less than "+pMin+" or greater than "+pMax+".");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void LenMin(string pName, string pValue, int pLenMin) {
			if ( pValue != null && pValue.Length < pLenMin ) {
				throw new FabPropertyLengthFault(pName, pValue, true, pLenMin);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void LenMax(string pName, string pValue, int pLenMax) {
			if ( pValue != null && pValue.Length > pLenMax ) {
				throw new FabPropertyLengthFault(pName, pValue, false, pLenMax);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidRegex(string pName, string pValue, string pPattern) {
			if ( pValue != null && !Regex.IsMatch(pValue, pPattern) ) {
				throw new FabPropertyValueFault(pName, pValue, "is invalid. "+
					"It must match this regular expression: "+pPattern);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidEnum<T>(string pName, byte pValue) {
			if ( !Enum.IsDefined(typeof(T), pValue) ) {
				throw new FabPropertyOutOfRangeFault(pName, pValue,
					"is not a valid "+typeof(T).Name+" value.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValidVertexId(string pName, long? pValue) {
			if ( pValue != null && pValue <= 0 ) {
				throw new FabPropertyOutOfRangeFault(pName, (long)pValue, "cannot be less than 1.");
			}
		}

	}

}