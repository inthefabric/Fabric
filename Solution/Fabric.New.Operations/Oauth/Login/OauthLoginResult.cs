using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Oauth.Login {

	/*================================================================================================*/
	public class OauthLoginResult : FabObject {

		public string Redirect { get; set; }
		public string Code { get; set; }

		public bool ShowLoginPage { get; set; }
		public long AppId { get; set; }
		public string AppName { get; set; }
		public long LoggedUserId { get; set; }
		public string LoggedUserName { get; set; }
		public string LoginErrorText { get; set; }

	}

}