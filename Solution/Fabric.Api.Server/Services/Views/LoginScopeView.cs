using Fabric.Api.Dto.Oauth;
using Fabric.Api.Server.Common;
using Nancy;

namespace Fabric.Api.Server.Services.Views {

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
			string html = 
				"<div class='ContentPanel'>"+
				"	<h3>"+
				"		Authorize App Access"+
				"	</h3>"+
				"	<p>"+
				"		<b>"+vLogin.AppName+"</b> would like connect to your <b>"+
					vLogin.LoggedUserName+"</b> "+
				"		Fabric account. Would you like to authorize access for this App?"+
				"	</p>"+
				"	<form id='ScopeForm' method='POST'>"+
				"		<input type='submit' name='"+OauthLoginController.AllowAction+
					"' value='Allow Access' />"+
				"		<input type='submit' name='"+OauthLoginController.DenyAction+	
					"' value='Deny Access' />"+
				"	</form>"+
				"	<form id='logoutForm' method='POST'>"+
				"		<p>"+
				"			<input type='submit' name='"+OauthLoginController.LogoutAction+
					"' value='Not "+vLogin.LoggedUserName+"?' />"+
				"		</p>"+
				"	</form>"+
				"</div>";

			return BuildResponse("Fabirc Login: Scope", html);
		}

	}

}