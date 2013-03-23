using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Batch {

	/*================================================================================================*/
	public class FabBatchResult : FabObject {

		public long BatchId { get; set; }
		public long ResultId { get; set; }
		public FabError Error { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}