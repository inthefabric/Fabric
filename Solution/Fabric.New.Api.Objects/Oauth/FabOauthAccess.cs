using System.Runtime.Serialization;
using Fabric.New.Infrastructure.Spec;

namespace Fabric.New.Api.Objects.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthAccess : FabObject {

		[DataMember(Name="access_token")]
		[SpecUnique]
		[SpecLen(32, 32)]
		public string AccessToken { get; set; }

		[DataMember(Name="token_type")]
		public string TokenType { get; set; }

		[DataMember(Name="refresh_token")]
		[SpecUnique]
		[SpecLen(32, 32)]
		public string RefreshToken { get; set; }

		[DataMember(Name="expires_in")]
		public int ExpiresIn { get; set; }

		[SpecInternal]
		public long OauthAccessId { get; set; }

		[SpecInternal]
		public long AppId { get; set; }

		[SpecInternal]
		public long? UserId { get; set; }

	}

}