﻿using System;
using System.Text.RegularExpressions;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Api.Objects {

	/*================================================================================================*/
	public abstract class CreateFabElement : FabObject {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Validate() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void NotNull(string pName, string pValue) {
			if ( pValue == null ) {
				throw new FabPropertyNullFault(pName);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void LenMin(string pName, string pValue, int pLenMin) {
			if ( pValue != null && pValue.Length < pLenMin ) {
				throw new FabPropertyLengthFault(pName, pValue, true, pLenMin);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void LenMax(string pName, string pValue, int pLenMax) {
			if ( pValue != null && pValue.Length > pLenMax ) {
				throw new FabPropertyLengthFault(pName, pValue, false, pLenMax);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void ValidRegex(string pName, string pValue, string pPattern) {
			if ( pValue != null && !Regex.IsMatch(pValue, pPattern) ) {
				throw new FabPropertyValueFault(pName, pValue, "is invalid. "+
					"It must match this regular expression: "+pPattern);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void ValidEnum<T>(string pName, byte pValue) {
			if ( !Enum.IsDefined(typeof(T), pValue) ) {
				throw new FabPropertyOutOfRangeFault(pName, pValue,
					"is not a valid "+typeof(T).Name+" value.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void ValidVertexId(string pName, long? pValue) {
			if ( pValue != null && pValue <= 0 ) {
				throw new FabPropertyOutOfRangeFault(pName, (long)pValue, "cannot be less than 1.");
			}
		}

	}

}