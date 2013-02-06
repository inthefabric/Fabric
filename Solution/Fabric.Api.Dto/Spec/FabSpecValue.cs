using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecValue : FabObject {

		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }

		public bool IsRequired { get; set; }
		public int? Len { get; set; }
		public int? LenMax { get; set; }
		public int? LenMin { get; set; }
		public int? Min { get; set; }
		public int? Max { get; set; }
		public string ValidRegex { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}