using Fabric.Infrastructure;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	public class FabOauthAccess : IFabDto {

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

		//[DtoProp(true)]
		//public bool IsClientOnly { get; set; }

		/*--------------------------------------------------------------------------------------------* /
		public FabOauthAccessKey Key { get; set; }
		public FabAppKey AppKey { get; set; }
		public FabUserKey UserKey { get; set; }
		public DateTime Expires { get; set; }
		public bool IsClientOnly { get; set; }

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Fill(DbDto pDbDto) {}

	}

}