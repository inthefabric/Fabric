using System.Runtime.Serialization;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthAccess : FabDto {

		[DataMember(Name="access_token")]
		[DtoProp("access_token")]
		public string AccessToken { get; set; }

		[DataMember(Name="token_type")]
		[DtoProp("token_type")]
		public string TokenType { get; set; }

		[DataMember(Name="refresh_token")]
		[DtoProp("refresh_token")]
		public string RefreshToken { get; set; }

		[DataMember(Name="expires_in")]
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