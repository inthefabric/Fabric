using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecServiceOperationParam : FabDto {

		public string ParamType { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
		public bool IsRequired { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}