using System.Runtime.Serialization;

namespace Fabric.New.Api.Objects.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthLogout : FabObject {

		[DataMember(Name="success")]
		//TODO: [DtoProp("success")]
		public int Success { get; set; }

		[DataMember(Name="access_token")]
		//TODO: [DtoProp("access_token")]
		public string AccessToken { get; set; }

	}

}