using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Batch {

	/*================================================================================================*/
	public class FabBatchNewClass : FabBatchNewObject {

		public string Name { get; set; }
		public string Disamb { get; set; }
		public string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}