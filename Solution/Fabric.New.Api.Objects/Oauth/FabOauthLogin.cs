using System.Runtime.Serialization;

namespace Fabric.New.Api.Objects.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthLogin : FabObject {

		[DataMember(Name="code")]
		//TODO: [DtoProp("code")]
		public string Code { get; set; }

		[DataMember(Name="state")]
		//TODO: [DtoProp("state")]
		public string State { get; set; }

		[DataMember(Name="error")]
		//TODO: [DtoProp("error")]
		public string Error { get; set; }

		[DataMember(Name="error_description")]
		//TODO: [DtoProp("error_description")]
		public string ErrorDesc { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public bool ShowLoginPage { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public long AppId { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public string AppName { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public long LoggedUserId { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public string LoggedUserName { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public string LoginErrorText { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public string ScopeRedirect { get; set; }

		//TODO: [DtoProp(IsInternal=true)]
		public string ScopeCode { get; set; }

	}

}