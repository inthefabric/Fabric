using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecServiceOperation : FabDto {

		public string Name { get; set; }
		public string Uri { get; set; }
		public string Method { get; set; }
		public string ReturnType { get; set; }
		public string Description { get; set; }
		public List<FabSpecServiceOperationParam> Parameters { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabSpecServiceOperation() {
			Parameters = new List<FabSpecServiceOperationParam>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}