using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecService : FabDto {

		public string Name { get; set; }
		public string Description { get; set; }
		public string Uri { get; set; }
		public List<FabSpecDto> DtoList { get; set; }
		public List<FabSpecFunc> FunctionList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}