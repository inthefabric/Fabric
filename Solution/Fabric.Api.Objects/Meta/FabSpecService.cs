using System.Collections.Generic;

namespace Fabric.Api.Objects.Meta {

	/*================================================================================================*/
	public class FabSpecService : FabObject {
		
		public string Name { get; set; }
		public string Uri { get; set; }
		public string Summary { get; set; }
		public string Description { get; set; }
		public List<FabSpecServiceOperation> Operations { get; set; }
		public List<FabSpecServiceStep> Steps { get; set; }

	}

}