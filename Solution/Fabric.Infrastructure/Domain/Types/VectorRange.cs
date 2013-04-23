using System.Collections.Generic;

namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class VectorRange : BaseType<VectorRangeId> {

		public IList<byte> VectorRangeLevelIds { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRange(VectorRangeId pEnumId, string pName, IList<byte> pLevelIds) :
																			base(pEnumId, pName, "") {
			VectorRangeLevelIds = pLevelIds;
		}

	}

}