using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Meta {

	/*================================================================================================*/
	public class FabSpec : FabObject {
		
		public string ApiVersion { get; set; }
		public List<FabSpecObject> Objects { get; set; }
		public List<FabSpecService> Services { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}