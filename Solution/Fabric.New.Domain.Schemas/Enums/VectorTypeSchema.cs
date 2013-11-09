namespace Fabric.New.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class VectorTypeSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeSchema() : base("VectorType") {
			const long min = long.MinValue;
			const long max = long.MaxValue;

			AddItem(1, "FullLong", "Full Bounds", "", "FullNum", min, max);
			AddItem(2, "PosLong", "Positive Bounds", "", "PosNum", 0, max);
			AddItem(3, "NegLong", "Negative Bounds", "", "NegNum", min, 0);
			AddItem(4, "FullPerc", "Full Percentage", "", "FullNum", min, max);
			AddItem(5, "StdPerc", "Standard Percentage", "", "PosNum", 0, 100);
			AddItem(6, "OppPerc", "Opposable Percentage", "", "FullNum", -100, 100);
			AddItem(7, "StdAgree", "Standard Agreement", "", "PosAgree", 0, 100);
			AddItem(8, "OppAgree", "Opposable Agreement", "", "FullAgree", -100, 100);
			AddItem(9, "StdFavor", "Standard Favorability", "", "PosFavor", 0, 100);
			AddItem(10, "OppFavor", "Opposable Favorability", "", "FullFavor", -100, 100);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddItem(byte pId, string pEnumId, string pName, string pDesc,
															string pVectorRange, long pMin, long pMax) {
			Items.Add(new VectorTypeItemSchema(pId, pEnumId, pName, pDesc, pVectorRange, pMin, pMax));
		}

	}


	/*================================================================================================*/
	public class VectorTypeItemSchema : EnumItemSchema {

		[EnumRef("VectorRange")]
		public string VectorRange { get; private set; }

		public long Min { get; private set; }
		public long Max { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeItemSchema(byte pId, string pEnumId, string pName, string pDesc,
						string pVectorRange, long pMin, long pMax) : base(pId, pEnumId, pName, pDesc) {
			VectorRange = pVectorRange;
			Min = pMin;
			Max = pMax;
		}

	}

}