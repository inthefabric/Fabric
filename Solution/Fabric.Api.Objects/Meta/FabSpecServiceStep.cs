using System.Collections.Generic;

namespace Fabric.Api.Objects.Meta {

	/*================================================================================================*/
	public class FabSpecServiceStep : FabObject {

		public string Name { get; set; }
		public string Description { get; set; }
		public List<FabSpecServiceParam> Parameters { get; set; }
		public List<FabSpecServiceStepRule> Rules { get; set; }

	}

}