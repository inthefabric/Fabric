using Fabric.Api.Common;
using Fabric.Api.Content;
using Fabric.Api.Dto.Oauth;
using Nancy;

namespace Fabric.Api.Services.Views {

	/*================================================================================================*/
	public class LoginScopeView : HtmlView {

		private readonly FabOauthLogin vLogin;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LoginScopeView(FabOauthLogin pLogin) {
			vLogin = pLogin;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override Response ToResponse() {
			string html = WebResources.LoginScopeHtml
				.Replace("@AppName", vLogin.AppName)
				.Replace("@LoggedUserName", vLogin.LoggedUserName)
				.Replace("@AllowAction", OauthLoginController.AllowAction)
				.Replace("@DenyAction", OauthLoginController.DenyAction)
				.Replace("@LogoutAction", OauthLoginController.LogoutAction);

			return BuildResponse("Fabirc Login: Scope", html);
		}

	}

}