using System.Collections.Generic;

namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class VectorRange : BaseType<VectorRangeId> {

		public IEnumerable<VectorRangeLevelId> Levels { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRange(VectorRangeId pEnumId, string pName,
								IEnumerable<VectorRangeLevelId> pLevels) : base(pEnumId, pName, "") {
			Levels = pLevels;
		}

	}

}