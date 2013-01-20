using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecFuncParam : FabDto {

		public int Index { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }

		public int? Min { get; set; }
		public int? Max { get; set; }

		public bool IsRequired { get; set; }
		public bool UsesQueryString { get; set; }
		public string DisplayName { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}