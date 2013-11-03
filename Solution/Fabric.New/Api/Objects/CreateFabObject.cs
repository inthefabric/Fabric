using System;
using System.Text.RegularExpressions;

namespace Fabric.New.Api.Objects {

	/*================================================================================================*/
	public abstract class CreateFabObject {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Validate() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void NotNull(string pName, string pValue) {
			if ( pValue == null ) {
				throw new Exception("Property '"+pName+"' cannot be null.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void LenMin(string pName, string pValue, int pLenMin) {
			if ( pValue != null && pValue.Length < pLenMin ) {
				throw new Exception(PropStr(pName, pValue)+"cannot less than "+pLenMin+" characters.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void LenMax(string pName, string pValue, int pLenMax) {
			if ( pValue != null && pValue.Length > pLenMax ) {
				throw new Exception(PropStr(pName, pValue)+"cannot more than "+pLenMax+" characters.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void ValidRegex(string pName, string pValue, string pPattern) {
			if ( !Regex.IsMatch(pValue, pPattern) ) {
				throw new Exception(PropStr(pName, pValue)+"is invalid. "+
					"It must match this regular expression: "+pPattern);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void ValidEnum<T>(string pName, byte pValue) {
			if ( !Enum.IsDefined(typeof(T), pValue) ) {
				throw new Exception(PropStr(pName, pValue)+"is not a valid "+typeof(T).Name+" value.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string PropStr(string pName, object pValue) {
			return "Property '"+pName+"' (with value '"+pValue+"') ";
		}

	}

}