using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Meta {

	/*================================================================================================*/
	public class FabSpecServiceOperationParam : FabSpecValue {

		public string ParamType { get; set; }
		public int Index { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}