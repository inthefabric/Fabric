using System;

namespace Fabric.Api.Paths.Steps.Functions {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class FuncParamAttribute : Attribute {

		public int ParamIndex { get; set; }
		public int? Min { get; set; }
		public int? Max { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncParamAttribute(int pParamIndex) {
			ParamIndex = pParamIndex;
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