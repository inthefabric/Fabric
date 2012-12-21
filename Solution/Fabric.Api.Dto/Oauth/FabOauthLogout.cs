using Fabric.Infrastructure;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	public class FabOauthLogout : IFabDto {

		[DtoProp("success")]
		public int Success { get; set; }

		[DtoProp("access_token")]
		public string AccessToken { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Fill(DbDto pDbDto) {}

	}

}