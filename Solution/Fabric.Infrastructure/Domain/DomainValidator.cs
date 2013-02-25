﻿using System.Text.RegularExpressions;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Infrastructure.Domain {
	
	/*================================================================================================*/
	public partial class DomainValidator {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void NotNull(string pName, string pValue) {
			if ( pValue == null ) {
				throw new FabArgumentNullFault(pName);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void LengthLessThanOrEqual(string pName, string pValue, int pMax) {
			if ( pValue.Length > pMax ) {
				throw new FabArgumentLengthFault(pName, pMax);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void LengthBetween(string pName, string pValue, int pMin, int pMax) {
			if ( pValue.Length < pMin || pValue.Length > pMax ) {
				throw new FabArgumentLengthFault(pName, pMin, pMax);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void MatchesRegex(string pName, string pValue, string pPattern) {
			if ( !Regex.IsMatch(pValue, pPattern) ) {
				throw new FabArgumentValueFault(
					pName+" has an invalid format. Valid regex pattern: "+pPattern);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void LongGreaterThanOrEqual(string pName, long pValue, long pMin) {
			if ( pValue < pMin ) {
				throw new FabArgumentOutOfRangeFault(pName, pMin);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void LongBetween(string pName, long pValue, long pMin, long pMax) {
			if ( pValue < pMin || pValue > pMax ) {
				throw new FabArgumentOutOfRangeFault(pName, pMin, pMax);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void LongNotEqualTo(string pName, long pValue, long pNotEqualToValue) {
			if ( pValue == pNotEqualToValue ) {
				throw new FabArgumentValueFault(pName, pNotEqualToValue);
			}
		}

	}

}