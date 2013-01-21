using System;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class FuncParamAttribute : Attribute {

		public int ParamIndex { get; set; }
		public int? Min { get; set; }
		public int? Max { get; set; }

		public bool IsRequired { get; set; }
		public bool UsesQueryString { get; set; }
		public string DisplayName { get; set; }
		public string FuncResxKey { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncParamAttribute(string pQueryStringName, bool pIsRequired=true) {
			UsesQueryString = true;
			DisplayName = pQueryStringName;
			IsRequired = pIsRequired;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FuncParamAttribute(int pParamIndex) {
			ParamIndex = pParamIndex;
			UsesQueryString = false;
			DisplayName = null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FuncParamAttribute(int pParamIndex, int pMin) : this(pParamIndex) {
			Min = pMin;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FuncParamAttribute(int pParamIndex, int pMin, int pMax) : this(pParamIndex, pMin) {
			Max = pMax;
		}

	}

}