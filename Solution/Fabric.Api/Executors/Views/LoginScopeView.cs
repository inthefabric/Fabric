using Fabric.Api.Content;
using Fabric.Operations.Oauth;

namespace Fabric.Api.Executors.Views {

	/*================================================================================================*/
	public class LoginScopeView : HtmlView {

		private readonly OauthLoginResult vLogin;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LoginScopeView(OauthLoginResult pLogin) {
			vLogin = pLogin;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string ToHtml() {
			string html = WebResources.LoginScopeHtml
				.Replace("@AppName", vLogin.AppName)
				.Replace("@LoggedUserName", vLogin.LoggedUserName)
				.Replace("@AllowAction", OauthExecutors.LoginAllow)
				.Replace("@DenyAction", OauthExecutors.LoginDeny)
				.Replace("@LogoutAction", OauthExecutors.LoginLogout);

			return BuildHtml("Fabirc Login: Scope", html);
		}

	}

}