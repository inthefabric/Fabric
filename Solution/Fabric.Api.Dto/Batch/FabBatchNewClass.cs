using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Batch {

	/*================================================================================================*/
	public class FabBatchNewClass : FabBatchNewObject {

		[DtoProp(IsOptional=false)]
		public string Name { get; set; }

		[DtoProp(IsOptional=true)]
		public string Disamb { get; set; }

		[DtoProp(IsOptional=true)]
		public string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}