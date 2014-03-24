using System.Runtime.Serialization;
using Fabric.New.Infrastructure.Spec;

namespace Fabric.New.Api.Objects.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthLogout : FabObject {

		[DataMember(Name="success")]
		public int Success { get; set; }

		[DataMember(Name="access_token")]
		[SpecUnique]
		[SpecLen(32, 32)]
		public string AccessToken { get; set; }

	}

}