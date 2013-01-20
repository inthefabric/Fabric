using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecFunc : FabDto {

		public string Name { get; set; }
		public string Description { get; set; }
		public string ReturnType { get; set; }
		public List<FabSpecFuncParam> ParameterList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}