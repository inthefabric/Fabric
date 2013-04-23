using System;

namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class VectorUnitPrefix : BaseType<VectorUnitPrefixId> {

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
		public const double Mebi = 1048576;
		public const double Gibi = 1073741824;
		public const double Tebi = 1099511627776;
		public const double Pebi = 1125899906842624;
		public const double Exbi = 1152921504606846976;

		public double Amount { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefix(VectorUnitPrefixId pEnumId, string pName, string pDesc,
														double pAmount) : base(pEnumId, pName, pDesc) {
			Amount = pAmount;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static double GetMult(long pUnitPrefixId) {
			switch ( pUnitPrefixId ) {
				case (long)VectorUnitPrefixId.Base: return Base;
					
				case (long)VectorUnitPrefixId.Kilo: return Kilo;
				case (long)VectorUnitPrefixId.Mega: return Mega;
				case (long)VectorUnitPrefixId.Giga: return Giga;
				case (long)VectorUnitPrefixId.Tera: return Tera;
				case (long)VectorUnitPrefixId.Peta: return Peta;
				case (long)VectorUnitPrefixId.Exa: return Exa;
					
				case (long)VectorUnitPrefixId.Milli: return Milli;
				case (long)VectorUnitPrefixId.Micro: return Micro;
				case (long)VectorUnitPrefixId.Nano: return Nano;
				case (long)VectorUnitPrefixId.Pico: return Pico;
				case (long)VectorUnitPrefixId.Femto: return Femto;
				case (long)VectorUnitPrefixId.Atto: return Atto;
					
				case (long)VectorUnitPrefixId.Kibi: return Kibi;
				case (long)VectorUnitPrefixId.Mebi: return Mebi;
				case (long)VectorUnitPrefixId.Gibi: return Gibi;
				case (long)VectorUnitPrefixId.Tebi: return Tebi;
				case (long)VectorUnitPrefixId.Pebi: return Pebi;
				case (long)VectorUnitPrefixId.Exbi: return Exbi;

				default:
					throw new Exception("Unknown VectorUnitPrefixConst: "+pUnitPrefixId);
			}
		}

	}

}