using System;

namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class VectorUnitPrefixSchema : EnumSchema {

		public const double Base = 1;

		public const double Kilo = 1E3;
		public const double Mega = 1E6;
		public const double Giga = 1E9;
		public const double Tera = 1E12;
		public const double Peta = 1E15;
		public const double Exa = 1E18;

		public const double Milli = 1E-3;
		public const double Micro = 1E-6;
		public const double Nano = 1E-9;
		public const double Pico = 1E-12;
		public const double Femto = 1E-15;
		public const double Atto = 1E-18;

		public const double Kibi = 1024;
		public readonly static double Mebi = Math.Pow(1024, 2);
		public readonly static double Gibi = Math.Pow(1024, 3);
		public readonly static double Tebi = Math.Pow(1024, 4);
		public readonly static double Pebi = Math.Pow(1024, 5); //truncated precision
		public readonly static double Exbi = Math.Pow(1024, 6); //truncated precision


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixSchema() : base("VectorUnitPrefix") {
			AddItem(1, "Base", "Base", "", Base);
			AddItem(2, "Kilo", "Kilo", "k", Kilo);
			AddItem(3, "Mega", "Mega", "M", Mega);
			AddItem(4, "Giga", "Giga", "G", Giga);
			AddItem(5, "Tera", "Tera", "T", Tera);
			AddItem(6, "Peta", "Peta", "P", Peta);
			AddItem(7, "Exa", "Exa", "E", Exa);
			AddItem(8, "Milli", "Milli", "m", Milli);
			AddItem(9, "Micro", "Micro", "μ", Micro);
			AddItem(10, "Nano", "Nano", "n", Nano);
			AddItem(11, "Pico", "Pico", "p", Pico);
			AddItem(12, "Femto", "Femto", "f", Femto);
			AddItem(13, "Atto", "Atto", "a", Atto);
			AddItem(14, "Kibi", "Kibi", "Ki", Kibi);
			AddItem(15, "Mebi", "Mebi", "Mi", Mebi);
			AddItem(16, "Gibi", "Gibi", "Gi", Gibi);
			AddItem(17, "Tebi", "Tebi", "Ti", Tebi);
			AddItem(18, "Pebi", "Pebi", "Pi", Pebi);
			AddItem(19, "Exbi", "Exbi", "Ei", Exbi);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddItem(byte pId, string pEnumId, string pName, string pDesc, double pAmount) {
			Items.Add(new VectorUnitPrefixItemSchema(pId, pEnumId, pName, pDesc, pAmount));
		}

	}


	/*================================================================================================*/
	public class VectorUnitPrefixItemSchema : EnumItemSchema {

		public double Amount { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixItemSchema(byte pId, string pEnumId, string pName, string pDesc,
													double pAmount) : base(pId, pEnumId, pName, pDesc) {
			Amount = pAmount;
		}

	}

}