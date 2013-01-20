using Fabric.Api.Dto.Oauth;
using Fabric.Api.Server.Common;
using Nancy;

namespace Fabric.Api.Server.Oauth.Views {

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
			string err = vLogin.LoginErrorText;

			if ( err != null ) {
				err += "<br/>";
			}

			string html = 
				"<div>"+
				"	<p>"+
				"		The <b>"+vLogin.AppName+"</b> Fabric App would like connect to your account. "+
				"		Please sign in to accept this request for access."+
				"	</p>"+
				"	<form id='LoginForm' method='POST'>"+
				"		<h3>"+
				"			Login"+
				"		</h3>"+
				"		<div>"+
				"			<div class='label'>"+
				"				Username"+
				"			</div>"+
				"			<div class='field'>"+
				"				<input type='text' name='"+OauthLoginController.Username+
					"' value='"+vLogin.LoggedUserName+"' />"+
				"			</div>"+
				"			<div class='label'>"+
				"				Password"+
				"			</div>"+
				"			<div class='field'>"+
				"				<input type='password' name='"+OauthLoginController.Password+"' />"+
				"			</div>"+
				"			<div class='field'>"+
				"				<input type='checkbox' name='"+OauthLoginController.RememberMe+
					"' value='1' /> Remember me?"+
				"			</div>"+
				"			<p>"+
				"				<span class='fieldError'>"+err+"</span>"+
				"				<input type='submit' name='"+OauthLoginController.LoginAction+
					"' value='Login' />"+
				"				<input type='submit' name='"+OauthLoginController.CancelAction+
					"' value='Cancel' />"+
				"			</p>"+
				"		</div>"+
				"	</form>"+
				"</div>";

			return BuildResponse("Fabirc Login", html);
		}

	}

}