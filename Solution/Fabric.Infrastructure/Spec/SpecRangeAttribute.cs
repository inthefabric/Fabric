using System;

namespace Fabric.Infrastructure.Spec {

	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class SpecRangeAttribute : Attribute {

		public long Min { get; private set; }
		public long Max { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecRangeAttribute(long pMin, long pMax) {
			Min = pMin;
			Max = pMax;
		}

	}

}