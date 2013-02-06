using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecDtoProp : FabSpecValue {

		public bool? IsCaseInsensitive { get; set; }
		public bool? IsNullable { get; set; }
		public bool? IsPrimaryKey { get; set; }
		public bool? IsTimestamp { get; set; }
		public bool? IsUnique { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}