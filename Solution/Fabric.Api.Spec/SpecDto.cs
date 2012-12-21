using System.Collections.Generic;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public class SpecDto {

		public string Name { get; set; }
		public string Extends { get; set; }
		public string Abstract { get; set; }
		public string Description { get; set; }
		public List<SpecDtoProp> PropertyList { get; set; }
		public List<SpecDtoLink> LinkList { get; set; }
		public List<string> FunctionList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecDto() {
			PropertyList = new List<SpecDtoProp>();
			LinkList = new List<SpecDtoLink>();
			FunctionList = new List<string>();
		}

	}

}