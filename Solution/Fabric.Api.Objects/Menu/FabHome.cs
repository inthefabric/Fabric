using System.Collections.Generic;

namespace Fabric.Api.Objects.Menu {

	/*================================================================================================*/
	public class FabHome : FabObject {

		public string Name { get; set; }
		public string Uri { get; set; }
		public IList<FabService> Services { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabHome() {
			Name = "Fabric API";
			Services = new List<FabService>();
		}

	}

}