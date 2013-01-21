using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpec : FabDto {
		
		public string ApiVersion { get; set; }
		public FabSpecDto ApiResponse { get; set; }
		public FabSpecService TraversalService { get; set; }
		public FabSpecService OauthService { get; set; }
		public FabSpecService SpecService { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}