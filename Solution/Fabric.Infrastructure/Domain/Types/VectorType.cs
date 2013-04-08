namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class VectorType : BaseType<VectorTypeId> {

		public VectorRange Range { get; private set; }
		public long Min { get; private set; }
		public long Max { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorType(VectorTypeId pEnumId, string pName, VectorRange pRange, long pMin, 
															long pMax) : base(pEnumId, pName, "") {
			Range = pRange;
			Min = pMin;
			Max = pMax;
		}

	}

}