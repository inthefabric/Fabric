using System;
using System.Text;
using Fabric.Api.Spec;
using Fabric.Infrastructure;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.ApiSpec {

	/*================================================================================================*/
	public class ApiSpecBuilder {

		private readonly NancyContext vContext;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiSpecBuilder(NancyContext pContext) {
			vContext = pContext;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			try {
				return BuildResponse();
			}
			catch ( Exception ex ) {
				Log.Error("API Spec Exception", ex);
				return "Error: "+ex.Message;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildResponse() {
			var doc = new SpecDoc();
			doc.ApiVersion = ApiModule.ApiVersion;

			string cont;
			string contType;

			if ( ShouldReturnHtml() ) {
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

		/*--------------------------------------------------------------------------------------------*/
		private bool ShouldReturnHtml() {
			var acc = vContext.Request.Headers.Accept;

			foreach ( var a in acc ) {
				if ( a.Item1 != "text/html" ) { continue; }
				return true;
			}

			return false;
		}

	}

}