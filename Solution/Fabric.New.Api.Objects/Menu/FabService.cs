using System.Collections.Generic;

namespace Fabric.New.Api.Objects.Menu {

	/*================================================================================================*/
	public class FabService : FabObject {

		public string Name { get; set; }
		public string Uri { get; set; }
		public IList<FabServiceOperation> Operations { get; internal set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabService() {
			Operations = new List<FabServiceOperation>();
		}

	}

}