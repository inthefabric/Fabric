using Fabric.Api.Content;
using Fabric.New.Api.Objects.Oauth;

namespace Fabric.New.Api.Executors.Views {

	/*================================================================================================*/
	public class LoginScopeView : HtmlView {

		private readonly FabOauthLogin vLogin;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LoginScopeView(FabOauthLogin pLogin) {
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