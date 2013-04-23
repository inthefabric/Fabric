namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class VectorUnitDerived : BaseType<VectorUnitDerivedId> {

		public byte DefinesVectorUnitId { get; private set; }
		public byte RaisesVectorUnitId { get; private set; }
		public int WithExponent { get; private set; }
		public byte RaisesVectorUnitPrefixId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerived(VectorUnitDerivedId pEnumId, byte pUnitId, byte pRaisesId,
												int pExponent, byte pPrefixId) : base(pEnumId, "", "") {
			DefinesVectorUnitId = pUnitId;
			RaisesVectorUnitId = pRaisesId;
			WithExponent = pExponent;
			RaisesVectorUnitPrefixId = pPrefixId;
		}

	}

}