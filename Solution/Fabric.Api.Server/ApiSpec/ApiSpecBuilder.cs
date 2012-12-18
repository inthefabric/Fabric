using System;
using System.Text;
using Fabric.Api.Spec;
using Fabric.Infrastructure;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.ApiSpec {

	/*================================================================================================*/
	public class ApiSpecBuilder {


		////////////////////////////////////////////////////////////////////////////////////////////////
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
			var doc = new SpecDoc();
			doc.ApiVersion = ApiModule.ApiVersion;

			string cont;
			string contType;

			if ( true ) {
				cont = ApiSpecBuilderHtml.BuildHtml(doc);
				contType = "text/html";
			}
			else {
				cont = JsonSerializer.SerializeToString(doc);
				contType = "application/json";
			}

			byte[] bytes = UTF8Encoding.UTF8.GetBytes(cont);

			return new Response {
				ContentType = contType,
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

	}

}