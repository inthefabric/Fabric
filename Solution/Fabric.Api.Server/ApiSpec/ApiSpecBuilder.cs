using System;
using System.Text;
using Fabric.Infrastructure;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.ApiSpec {

	/*================================================================================================*/
	public class ApiSpecBuilder {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiSpecBuilder() {
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			try {
				return BuildResponse();
			}
			catch ( Exception ex ) {
				Log.Error("API", ex);
				return "error: "+ex.Message;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildResponse() {
			var doc = new ApiSpecDoc();
			var json = JsonSerializer.SerializeToString(doc);
			byte[] bytes = UTF8Encoding.UTF8.GetBytes(json);

			return new Response {
				ContentType = "application/json",
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

	}

}