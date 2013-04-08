namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class VectorUnitDerived : BaseType<VectorUnitDerivedId> {

		public VectorUnit Defines { get; private set; }
		public VectorUnit Raises { get; private set; }
		public int Exponent { get; private set; }
		public VectorUnitPrefix Prefix { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerived(VectorUnitDerivedId pEnumId, VectorUnit pUnit, VectorUnit pRaises,
									int pExponent, VectorUnitPrefix pPrefix) : base(pEnumId, "", "") {
			Defines = pUnit;
			Raises = pRaises;
			Exponent = pExponent;
			Prefix = pPrefix;
		}

	}

}