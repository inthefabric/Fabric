﻿using Fabric.Api.Server.Common;
using Nancy;

namespace Fabric.Api.Server.Root.Views {

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
			string html = "<b>"+vError+"</b>";

			if ( vErrDesc != null ) {
				html += "<br/>"+vErrDesc.Replace('+', ' ');
			}

			return BuildResponse("Fabirc Login Page Error", html);
		}

	}

}