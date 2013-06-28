using Fabric.Infrastructure.Data;

namespace Fabric.Api.Dto.Batch {

	/*================================================================================================*/
	public class FabBatchNewObject : FabObject {

		[DtoProp(IsOptional=false)]
		public long BatchId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) {}

	}

}