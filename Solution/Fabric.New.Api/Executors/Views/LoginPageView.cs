using Fabric.New.Api.Content;
using Fabric.New.Operations.Oauth.Login;

namespace Fabric.New.Api.Executors.Views {

	/*================================================================================================*/
	public class LoginPageView : HtmlView {

		private readonly OauthLoginResult vLogin;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LoginPageView(OauthLoginResult pLogin) {
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