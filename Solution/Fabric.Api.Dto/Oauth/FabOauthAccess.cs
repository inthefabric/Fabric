using System.Runtime.Serialization;
using Fabric.Infrastructure.Data;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthAccess : FabObject {

		[DataMember(Name="access_token")]
		[DtoProp("access_token", DomainPropName="Token")]
		public string AccessToken { get; set; }

		[DataMember(Name="token_type")]
		[DtoProp("token_type")]
		public string TokenType { get; set; }

		[DataMember(Name="refresh_token")]
		[DtoProp("refresh_token", DomainPropName="Refresh")]
		public string RefreshToken { get; set; }

		[DataMember(Name="expires_in")]
		[DtoProp("expires_in", DomainPropName="Expires")]
		public int ExpiresIn { get; set; }

		[DtoProp(IsInternal=true)]
		public long OauthAccessId { get; set; }

		[DtoProp(IsInternal=true)]
		public long AppId { get; set; }

		[DtoProp(IsInternal=true)]
		public long? UserId { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) {}

	}

}