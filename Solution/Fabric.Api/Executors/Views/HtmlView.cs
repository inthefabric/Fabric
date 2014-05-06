using Fabric.Api.Content;

namespace Fabric.Api.Executors.Views {

	/*================================================================================================*/
	public abstract class HtmlView {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public abstract string ToHtml();

		/*--------------------------------------------------------------------------------------------*/
		protected string BuildHtml(string pTitle, string pContent) {
			return WebResources.LayoutHtml
				.Replace("@TITLE", pTitle)
				.Replace("@CONTENT", pContent);
		}

	}

}