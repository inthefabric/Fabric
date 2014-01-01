using Fabric.Api.Content;
using Fabric.New.Api.Objects.Oauth;

namespace Fabric.New.Api.Executors.Views {

	/*================================================================================================*/
	public class LoginPageView : HtmlView {

		private readonly FabOauthLogin vLogin;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LoginPageView(FabOauthLogin pLogin) {
			vLogin = pLogin;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string ToHtml() {
			string html = WebResources.LoginPageHtml
				.Replace("@AppName", vLogin.AppName)
				.Replace("@ErrorDisplayStyle", (vLogin.LoginErrorText != null ? "inherit" : "none"))
				.Replace("@ErrorReason", vLogin.LoginErrorText)
				.Replace("@UsernameInput", OauthExecutors.LoginUsername)
				.Replace("@LoggedUserName", vLogin.LoggedUserName)
				.Replace("@PasswordInput", OauthExecutors.LoginPassword)
				.Replace("@RememberInput", OauthExecutors.LoginRememberMe)
				.Replace("@LoginAction", OauthExecutors.LoginLogin)
				.Replace("@CancelAction", OauthExecutors.LoginCancel);
			return BuildHtml("Fabirc Login", html);
		}

	}

}