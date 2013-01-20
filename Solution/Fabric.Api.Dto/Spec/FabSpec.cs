using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpec : FabDto {
		
		public string ApiVersion { get; set; }
		public FabSpecDto ApiResponse { get; set; }
		public List<FabSpecDto> DtoList { get; set; }
		public List<FabSpecFunc> FunctionList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}