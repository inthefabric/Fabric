using System.Runtime.Serialization;

namespace Fabric.New.Api.Objects.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthAccess : FabObject {

		[DataMember(Name="access_token")]
		//TODO: [DtoProp("access_token", DomainPropName="Token")]
		public string AccessToken { get; set; }

		[DataMember(Name="token_type")]
		//TODO: [DtoProp("token_type")]
		public string TokenType { get; set; }

		[DataMember(Name="refresh_token")]
		//TODO: [DtoProp("refresh_token", DomainPropName="Refresh")]
		public string RefreshToken { get; set; }

		[DataMember(Name="expires_in")]
		//TODO: [DtoProp("expires_in", DomainPropName="Expires")]
		public int ExpiresIn { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public long OauthAccessId { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public long AppId { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public long? UserId { get; set; }

	}

}