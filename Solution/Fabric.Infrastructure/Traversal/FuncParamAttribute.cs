using System;

namespace Fabric.Infrastructure.Traversal {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class FuncParamAttribute : Attribute {

		public int ParamIndex { get; set; }
		public int? Min { get; set; }
		public int? Max { get; set; }
		public int? LenMin { get; set; }
		public int? LenMax { get; set; }
		public string ValidRegex { get; set; }

		public bool IsRequired { get; set; }
		public string FuncResxKey { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncParamAttribute(int pParamIndex) {
			ParamIndex = pParamIndex;
			IsRequired = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FuncParamAttribute(int pParamIndex, int pMin) : this(pParamIndex) {
			Min = pMin;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FuncParamAttribute(int pParamIndex, int pMin, int pMax) : this(pParamIndex, pMin) {
			Max = pMax;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FuncParamAttribute(int pParamIndex, int pLenMin, int pLenMax, string pValidRegex) : 
																					this(pParamIndex) {
			LenMin = pLenMin;
			LenMax = pLenMax;
			ValidRegex = pValidRegex;
		}

	}

}