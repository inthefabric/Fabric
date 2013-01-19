using System;
using Fabric.Api.Server.Util;
using Nancy;

namespace Fabric.Api.Server.Common {

	/*================================================================================================*/
	public abstract class ViewBase {

		protected String MasterHtml { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ViewBase() {
			MasterHtml = 
				"<html>\n"+
				"	<head>\n"+
				"		<title>@TITLE</title>\n"+
				"	</head>\n"+
				"	<body>\n"+
				"		@CONTENT\n"+
				"	</body>\n"+
				"</html>";
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract Response ToResponse();

		/*--------------------------------------------------------------------------------------------*/
		protected Response BuildResponse(string pTitle, string pContent) {
			string html = MasterHtml.Replace("@TITLE", pTitle).Replace("@CONTENT", pContent);
			return NancyUtil.BuildHtmlResponse(HttpStatusCode.OK, html);
		}

	}

}