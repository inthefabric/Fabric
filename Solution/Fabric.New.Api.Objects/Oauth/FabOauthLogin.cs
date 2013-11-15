using System.Runtime.Serialization;
using Fabric.New.Infrastructure.Spec;

namespace Fabric.New.Api.Objects.Oauth {

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

		[SpecInternal]
		public bool ShowLoginPage { get; set; }

		[SpecInternal]
		public long AppId { get; set; }

		[SpecInternal]
		public string AppName { get; set; }

		[SpecInternal]
		public long LoggedUserId { get; set; }

		[SpecInternal]
		public string LoggedUserName { get; set; }

		[SpecInternal]
		public string LoginErrorText { get; set; }

		[SpecInternal]
		public string ScopeRedirect { get; set; }

		[SpecInternal]
		public string ScopeCode { get; set; }

	}

}