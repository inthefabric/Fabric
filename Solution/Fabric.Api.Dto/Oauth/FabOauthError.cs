using Fabric.Infrastructure;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	public class FabOauthError : IFabDto {

		[DtoProp("error")]
		public string Error { get; set; }

		[DtoProp("error_description")]
		public string ErrorDesc { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Fill(IDbDto pDbDto) {}

	}

}