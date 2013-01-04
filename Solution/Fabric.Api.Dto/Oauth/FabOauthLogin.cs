using Fabric.Infrastructure;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	public class FabOauthLogin : IFabDto {

		[DtoProp("code")]
		public string Code { get; set; }

		[DtoProp("state")]
		public string State { get; set; }

		[DtoProp("error")]
		public string Error { get; set; }

		[DtoProp("error_description")]
		public string ErrorDesc { get; set; }

		[DtoProp(true)]
		public bool ShowLoginPage { get; set; }

		[DtoProp(true)]
		public long AppId { get; set; }

		[DtoProp(true)]
		public string AppName { get; set; }

		[DtoProp(true)]
		public long LoggedUserId { get; set; }

		[DtoProp(true)]
		public string LoggedUserName { get; set; }

		[DtoProp(true)]
		public string LoginErrorText { get; set; }

		[DtoProp(true)]
		public string ScopeRedirect { get; set; }

		[DtoProp(true)]
		public string ScopeCode { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Fill(IDbDto pDbDto) {}

	}

}