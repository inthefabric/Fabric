using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecService : FabDto {
		
		public string Name { get; set; }
		public string Uri { get; set; }
		public string Abstract { get; set; }
		public string Description { get; set; }
		public string ResponseWrapper { get; set; }
		public List<FabSpecFunc> Functions { get; set; }
		public List<FabSpecServiceOperation> Operations { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabSpecService() {
			Functions = new List<FabSpecFunc>();
			Operations = new List<FabSpecServiceOperation>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}