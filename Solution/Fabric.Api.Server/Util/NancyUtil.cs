using System.Text;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.Util {

	/*================================================================================================*/
	public static class NancyUtil {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Response BuildJsonResponse<T>(HttpStatusCode pStatus, T pObject) {
			return BuildJsonResponse(pStatus, pObject.ToJson());
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Response BuildJsonResponse(HttpStatusCode pStatus, string pJson) {
			return BuildResponse(pStatus, pJson, "application/json");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Response BuildHtmlResponse(HttpStatusCode pStatus, string pHtml) {
			return BuildResponse(pStatus, pHtml, "text/html");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Response BuildResponse(HttpStatusCode pStatus, string pContent, string pType) {
			byte[] bytes = Encoding.UTF8.GetBytes(pContent);

			return new Response {
				ContentType = pType,
				StatusCode = pStatus,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Response Redirect(string pLocation) {
			var r = new Response();
			r.ContentType = "text/html";
			return Redirect(r, pLocation);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static Response Redirect(Response pResponse, string pLocation) {
			pResponse.StatusCode = HttpStatusCode.Found; //302
			pResponse.Headers.Add("Location", pLocation);
			return pResponse;
		}

	}

}