using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecDtoLink : FabDto {

		public string Name { get; set; }
		public bool IsOutgoing { get; set; }
		public string FromDto { get; set; }
		public string FromDtoConn { get; set; }
		public string Verb { get; set; }
		public string ToDto { get; set; }
		public string ToDtoConn { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}