using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	public class FabOauthLogout : FabDto {

		[DtoProp("success")]
		public int Success { get; set; }

		[DtoProp("access_token")]
		public string AccessToken { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}