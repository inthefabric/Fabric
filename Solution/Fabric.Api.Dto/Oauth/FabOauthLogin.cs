using System.Runtime.Serialization;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthLogin : FabObject {

		[DataMember(Name="code")]
		[DtoProp("code")]
		public string Code { get; set; }

		[DataMember(Name="state")]
		[DtoProp("state")]
		public string State { get; set; }

		[DataMember(Name="error")]
		[DtoProp("error")]
		public string Error { get; set; }

		[DataMember(Name="error_description")]
		[DtoProp("error_description")]
		public string ErrorDesc { get; set; }

		[DtoProp(IsInternal=true)]
		public bool ShowLoginPage { get; set; }

		[DtoProp(IsInternal=true)]
		public long AppId { get; set; }

		[DtoProp(IsInternal=true)]
		public string AppName { get; set; }

		[DtoProp(IsInternal=true)]
		public long LoggedUserId { get; set; }

		[DtoProp(IsInternal=true)]
		public string LoggedUserName { get; set; }

		[DtoProp(IsInternal=true)]
		public string LoginErrorText { get; set; }

		[DtoProp(IsInternal=true)]
		public string ScopeRedirect { get; set; }

		[DtoProp(IsInternal=true)]
		public string ScopeCode { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}