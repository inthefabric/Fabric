using System.Collections.Generic;

namespace Fabric.New.Api.Objects.Menu {

	/*================================================================================================*/
	public class FabService : FabObject {

		public string Name { get; set; }
		public string Uri { get; set; }
		public IList<FabServiceOperation> Operations { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabService() {
			Operations = new List<FabServiceOperation>();
		}

	}

}