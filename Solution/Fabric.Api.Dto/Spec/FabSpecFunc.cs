using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecFunc : FabDto {

		public string Name { get; set; }
		public string Description { get; set; }
		public string Uri { get; set; }
		public List<FabSpecFuncParam> Parameters { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}