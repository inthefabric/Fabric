using System.Collections.Generic;
using Fabric.Infrastructure.Data;

namespace Fabric.Api.Dto.Meta {

	/*================================================================================================*/
	public class FabSpecTravFunc : FabObject {

		public string Name { get; set; }
		public string Description { get; set; }
		public string Uri { get; set; }
		public bool ReturnsPreviousType { get; set; }
		public bool ReturnsAliasType { get; set; }
		public string ReturnsObjectType { get; set; }
		public List<FabSpecTravFuncParam> Parameters { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) {}

	}

}