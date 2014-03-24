using Fabric.Api.Content;

namespace Fabric.Api.Executors.Views {

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
		public override string ToHtml() {
			string desc = (vErrDesc != null ? vErrDesc.Replace('+', ' ') : "");

			string html = WebResources.LoginErrorHtml
				.Replace("@ErrorName", vError)
				.Replace("@ErrorDesc", desc);

			return BuildHtml("Fabirc Login Page Error", html);
		}

	}

}