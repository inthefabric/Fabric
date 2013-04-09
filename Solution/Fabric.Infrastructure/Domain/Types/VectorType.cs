namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class VectorType : BaseType<VectorTypeId> {

		public byte VectorRangeId { get; private set; }
		public long Min { get; private set; }
		public long Max { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorType(VectorTypeId pEnumId, string pName, byte pRangeId, long pMin, 
															long pMax) : base(pEnumId, pName, "") {
			VectorRangeId = pRangeId;
			Min = pMin;
			Max = pMax;
		}

	}

}