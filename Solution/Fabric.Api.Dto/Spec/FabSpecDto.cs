using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecDto : FabDto {

		public string Name { get; set; }
		public string Extends { get; set; }
		public string Description { get; set; }
		public List<FabSpecDtoProp> Properties { get; set; }
		public List<FabSpecDtoLink> Links { get; set; }
		public List<string> Functions { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabSpecDto() {
			Properties = new List<FabSpecDtoProp>();
			Links = new List<FabSpecDtoLink>();
			Functions = new List<string>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}