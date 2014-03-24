namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class VectorUnitSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitSchema() : base("VectorUnit") {
			AddItem(1, "None", "None", "");
			AddItem(2, "Unit", "Unit", "");
			AddItem(3, "Metre", "Metre", "m");
			AddItem(4, "Gram", "Gram", "g");
			AddItem(5, "Second", "Second", "s");
			AddItem(6, "Ampere", "Ampere", "A");
			AddItem(7, "Celsius", "Celsius", "C");
			AddItem(8, "Candela", "Candela", "cd");
			AddItem(9, "Mole", "Mole", "mol");
			AddItem(10, "Bit", "Bit", "b");
			AddItem(11, "Byte", "Byte", "B");
			AddItem(12, "Hertz", "Hertz", "Hz");
			AddItem(13, "Radian", "Radian", "rad");
			AddItem(14, "Newton", "Newton", "N");
			AddItem(15, "Pascal", "Pascal", "Pa");
			AddItem(16, "Joule", "Joule", "J");
			AddItem(17, "Watt", "Watt", "W");
			AddItem(18, "Volt", "Volt", "V");
			AddItem(19, "Ohm", "Ohm", "Ω");
			AddItem(20, "Area", "Area", "m^2");
			AddItem(21, "Volume", "Volume", "m^3");
			AddItem(22, "Speed", "Speed", "m/s");
			AddItem(23, "Acceleration", "Acceleration", "m^3/s");
			AddItem(24, "Point", "Point", "pt");
			AddItem(25, "Item", "Item", "item");
			AddItem(26, "Person", "Person", "person");
			AddItem(27, "Percent", "Percent", "%");
			AddItem(28, "Index", "Index", "index");
			AddItem(29, "Pixel", "Pixel", "pixel");
		}

	}

}