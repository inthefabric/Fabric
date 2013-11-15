using System;

namespace Fabric.New.Infrastructure.Spec {

	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class SpecLenAttribute : Attribute {

		public int Min { get; private set; }
		public int Max { get; private set; }

		//public int? NullableMin { get; private set; }
		//public int? NullableMax { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecLenAttribute(int pMin, int pMax) {
			Min = pMin;
			Max = pMax;
		}

		/*--------------------------------------------------------------------------------------------* /
		public int Min {
			get { return (NullableMin ?? -1); }
			set { NullableMin = value; }
		}

		/*--------------------------------------------------------------------------------------------* /
		public int Max {
			get { return (NullableMax ?? -1); }
			set { NullableMax = value; }
		}*/

	}

}