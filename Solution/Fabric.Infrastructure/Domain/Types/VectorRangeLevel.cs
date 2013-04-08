namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class VectorRangeLevel : BaseType<VectorRangeLevelId> {

		public float Position { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevel(VectorRangeLevelId pEnumId, string pName, float pPosition) :
																			base(pEnumId, pName, "") {
			Position = pPosition;
		}

	}

}