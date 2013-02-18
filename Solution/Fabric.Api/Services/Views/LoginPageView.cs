using Fabric.Api.Common;
using Fabric.Api.Content;
using Fabric.Api.Dto.Oauth;
using Nancy;

namespace Fabric.Api.Services.Views {

	/*================================================================================================*/
	public class LoginPageView : HtmlView {

		private readonly FabOauthLogin vLogin;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LoginPageView(FabOauthLogin pLogin) {
			vLogin = pLogin;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override Response ToResponse() {
			string html = WebResources.LoginPageHtml
				.Replace("@AppName", vLogin.AppName)
				.Replace("@ErrorDisplayStyle", (vLogin.LoginErrorText != null ? "inherit" : "none"))
				.Replace("@ErrorReason", vLogin.LoginErrorText)
				.Replace("@UsernameInput", OauthLoginController.Username)
				.Replace("@LoggedUserName", vLogin.LoggedUserName)
				.Replace("@PasswordInput", OauthLoginController.Password)
				.Replace("@RememberInput", OauthLoginController.RememberMe)
				.Replace("@LoginAction", OauthLoginController.LoginAction)
				.Replace("@CancelAction", OauthLoginController.CancelAction);
			return BuildResponse("Fabirc Login", html);
		}

	}

}