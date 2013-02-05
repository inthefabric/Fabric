using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabServiceOperation : FabDto {

		public string Name { get; set; }
		public string Uri { get; set; }
		public string Method { get; set; }
		public string ReturnType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}