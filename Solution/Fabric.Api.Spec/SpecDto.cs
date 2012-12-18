using System.Collections.Generic;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public class SpecDto {

		public string Name { get; set; }
		public string Extends { get; set; }
		public string Abstract { get; set; }
		public string Description { get; set; }
		public List<SpecProperty> PropertyList { get; set; }
		public List<SpecLink> LinkList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecDto() {
			PropertyList = new List<SpecProperty>();
			LinkList = new List<SpecLink>();
		}

	}

}