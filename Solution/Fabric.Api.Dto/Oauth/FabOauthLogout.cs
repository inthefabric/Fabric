using Fabric.Infrastructure;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	public class FabOauthLogout : IFabDto {

		[DtoProp("success")]
		public int Success { get; set; }

		[DtoProp("access_token")]
		public string AccessToken { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Fill(IDbDto pDbDto) {}

	}

}