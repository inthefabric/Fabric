using System.Runtime.Serialization;
using Fabric.Infrastructure.Spec;

namespace Fabric.Api.Objects.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthLogin : FabObject {

		[DataMember(Name="code")]
		[SpecUnique]
		[SpecLen(32, 32)]
		public string Code { get; set; }

		[DataMember(Name="state")]
		[SpecOptional]
		public string State { get; set; }

		[DataMember(Name="error")]
		[SpecOptional]
		public string Error { get; set; }

		[DataMember(Name="error_description")]
		[SpecOptional]
		public string ErrorDesc { get; set; }

	}

}