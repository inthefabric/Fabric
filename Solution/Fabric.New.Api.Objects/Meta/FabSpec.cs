using System.Collections.Generic;

namespace Fabric.New.Api.Objects.Meta {

	/*================================================================================================*/
	public class FabSpec : FabObject {

		public string BuildVersion { get; set; }
		public int BuildYear { get; set; }
		public int BuildMonth { get; set; }
		public int BuildDay { get; set; }
		public List<FabSpecObject> Objects { get; set; }
		public List<FabSpecService> Services { get; set; }
		public List<FabSpecEnum> Enums { get; set; }

	}

}