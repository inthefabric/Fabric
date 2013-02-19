using Fabric.Api.Common;
using Fabric.Api.Content;
using Nancy;

namespace Fabric.Api.Services.Views {

	/*================================================================================================*/
	public class LoginErrorView : HtmlView {

		private readonly string vError;
		private readonly string vErrDesc;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LoginErrorView(string pError, string pErrDesc) {
			vError = pError;
			vErrDesc = pErrDesc;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override Response ToResponse() {
			string desc = (vErrDesc != null ? vErrDesc.Replace('+', ' ') : "");

			string html = WebResources.LoginErrorHtml
				.Replace("@ErrorName", vError)
				.Replace("@ErrorDesc", desc);

			return BuildResponse("Fabirc Login Page Error", html);
		}

	}

}