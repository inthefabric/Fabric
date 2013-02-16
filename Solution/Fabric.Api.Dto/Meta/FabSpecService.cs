using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Meta {

	/*================================================================================================*/
	public class FabSpecService : FabObject {
		
		public string Name { get; set; }
		public string Uri { get; set; }
		public string Abstract { get; set; }
		public string Description { get; set; }
		public string ResponseWrapper { get; set; }
		public List<FabSpecTravFunc> TraversalFunctions { get; set; }
		public List<FabSpecServiceOperation> Operations { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}