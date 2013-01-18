using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	public class FabOauthAccess : FabDto {

		[DtoProp("access_token")]
		public string AccessToken { get; set; }

		[DtoProp("token_type")]
		public string TokenType { get; set; }

		[DtoProp("refresh_token")]
		public string RefreshToken { get; set; }

		[DtoProp("expires_in")]
		public int ExpiresIn { get; set; }

		[DtoProp(true)]
		public long OauthAccessId { get; set; }

		[DtoProp(true)]
		public long AppId { get; set; }

		[DtoProp(true)]
		public long? UserId { get; set; }

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) { }

	}

}