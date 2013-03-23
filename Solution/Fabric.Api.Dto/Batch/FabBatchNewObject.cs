using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Batch {

	/*================================================================================================*/
	public class FabBatchNewObject : FabObject {

		public long BatchId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}