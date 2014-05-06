namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class VectorUnitDerivedSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedSchema() : base("VectorUnitDerived") {
			AddItem(1, "HertzSec", "", "", "Hertz", "Second", -1, "Base");
			AddItem(2, "NewtonGram", "", "", "Newton", "Gram", 1, "Kilo");
			AddItem(3, "NewtonMetre", "", "", "Newton", "Metre", 1, "Base");
			AddItem(4, "NewtonSec", "", "", "Newton", "Second", -2, "Base");
			AddItem(5, "PascalGram", "", "", "Pascal", "Gram", 1, "Kilo");
			AddItem(6, "PascalMetre", "", "", "Pascal", "Metre", -1, "Base");
			AddItem(7, "PascalSec", "", "", "Pascal", "Second", -2, "Base");
			AddItem(8, "JouleGram", "", "", "Joule", "Gram", 1, "Kilo");
			AddItem(9, "JouleMetre", "", "", "Joule", "Metre", 2, "Base");
			AddItem(10, "JouleSec", "", "", "Joule", "Second", -2, "Base");
			AddItem(11, "WattGram", "", "", "Watt", "Gram", 1, "Kilo");
			AddItem(12, "WattMetre", "", "", "Watt", "Metre", 2, "Base");
			AddItem(13, "WattSec", "", "", "Watt", "Second", -3, "Base");
			AddItem(14, "VoltGram", "", "", "Volt", "Gram", 1, "Kilo");
			AddItem(15, "VoltMetre", "", "", "Volt", "Metre", 2, "Base");
			AddItem(16, "VoltSec", "", "", "Volt", "Second", -3, "Base");
			AddItem(17, "VoltAmp", "", "", "Volt", "Ampere", -1, "Base");
			AddItem(18, "OhmGram", "", "", "Ohm", "Gram", 1, "Kilo");
			AddItem(19, "OhmMetre", "", "", "Ohm", "Metre", 2, "Base");
			AddItem(20, "OhmSec", "", "", "Ohm", "Second", -3, "Base");
			AddItem(21, "OhmAmp", "", "", "Ohm", "Ampere", -2, "Base");
			AddItem(22, "AreaMetre", "", "", "Area", "Metre", 2, "Base");
			AddItem(23, "VolumeMetre", "", "", "Volume", "Metre", 3, "Base");
			AddItem(24, "SpeedMetre", "", "", "Speed", "Metre", 1, "Base");
			AddItem(25, "SpeedSec", "", "", "Speed", "Second", -1, "Base");
			AddItem(26, "AccelMetre", "", "", "Acceleration", "Metre", 1, "Base");
			AddItem(27, "AccelSec", "", "", "Acceleration", "Second", -2, "Base");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddItem(byte pId, string pEnumId, string pName, string pDesc,
													string pDefinesVectorUnit, string pRaisesVectorUnit, 
													int pWithExponent, string pRaisesVectorUnitPrefix) {
			Items.Add(new VectorUnitDerivedItemSchema(pId, pEnumId, pName, pDesc, pDefinesVectorUnit,
				pRaisesVectorUnit, pWithExponent, pRaisesVectorUnitPrefix));
		}

	}


	/*================================================================================================*/
	public class VectorUnitDerivedItemSchema : EnumItemSchema {

		[EnumRef("VectorUnit")]
		public string DefinesVectorUnit { get; private set; }

		[EnumRef("VectorUnit")]
		public string RaisesVectorUnit { get; private set; }
		
		public int WithExponent { get; private set; }

		[EnumRef("VectorUnitPrefix")]
		public string RaisesVectorUnitPrefix { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedItemSchema(byte pId, string pEnumId, string pName, string pDesc, 
								string pDefinesVectorUnit, string pRaisesVectorUnit, int pWithExponent,
								string pRaisesVectorUnitPrefix) : base(pId, pEnumId, pName, pDesc) {
			DefinesVectorUnit = pDefinesVectorUnit;
			RaisesVectorUnit = pRaisesVectorUnit;
			WithExponent = pWithExponent;
			RaisesVectorUnitPrefix = pRaisesVectorUnitPrefix;
		}
	}

}