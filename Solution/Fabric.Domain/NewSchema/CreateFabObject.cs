using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fabric.Domain.NewSchema {

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
				throw new Exception("Property '"+pName+"' cannot less than "+pLenMin+" characters.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void LenMax(string pName, string pValue, int pLenMax) {
			if ( pValue != null && pValue.Length > pLenMax ) {
				throw new Exception("Property '"+pName+"' cannot more than "+pLenMax+" characters.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void ValidRegex(string pName, string pValue, string pPattern) {
			if ( !Regex.IsMatch(pValue, pPattern) ) {
				throw new Exception("Property '"+pName+"' is invalid. "+
					"It must match this regular expression: "+pPattern);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void ValidEnum<T>(string pName, byte pValue) {
			//TODO: ValidEnum
			Type type = typeof(T);
			byte min = Enum.GetValues(type).Cast<byte>().First();
			byte max = Enum.GetValues(type).Cast<byte>().Last();

			if ( pValue < min || pValue > max ) {
				throw new Exception("Property '"+pName+"' is not a valid '"+type.Name+"' value.");
			}
		}

	}

}