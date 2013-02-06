using System;

namespace Fabric.Infrastructure.Traversal {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class FuncParamAttribute : Attribute {

		public int ParamIndex { get; set; }
		public int? Min { get; set; }
		public int? Max { get; set; }

		public bool IsRequired { get; set; }
		public string DisplayName { get; set; }
		public string FuncResxKey { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncParamAttribute(int pParamIndex) {
			ParamIndex = pParamIndex;
			IsRequired = true;
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