using System;
using Fabric.Api.Content;
using Fabric.Api.Util;
using Nancy;

namespace Fabric.Api.Common {

	/*================================================================================================*/
	public abstract class HtmlView {

		protected String MasterHtml { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected HtmlView() {
			MasterHtml = WebResources.LayoutHtml;
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