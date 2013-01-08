using System;
using System.Text;
using Fabric.Api.Spec;
using Fabric.Infrastructure;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.ApiSpec {

	/*================================================================================================*/
	public class ApiSpecBuilder {

		public static SpecDoc ApiSpec;

		private readonly NancyContext vContext;
		private readonly string vSingleObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiSpecBuilder(NancyContext pContext, string pSingleObject=null) {
			vContext = pContext;
			vSingleObj = pSingleObject;

			if ( ApiSpec == null ) {
				ApiSpec = new SpecDoc { ApiVersion = ApiModule.ApiVersion };
			}
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
			string objName = vContext.Parameters["name"];
			string objNameLower = null;

			if ( objName != null ) {
				objNameLower = objName.ToLower();
			}

			////

			bool html = ShouldReturnHtml();
			string contType = (html ? "text/html" : "application/json");
			string cont = null;
			HttpStatusCode statusCode = HttpStatusCode.OK;

			switch ( vSingleObj ) {
				case "res":
					cont = (html ?
						ApiSpecBuilderHtml.BuildDtoHtml(ApiSpec.ApiResponse, ApiSpec) :
						JsonSerializer.SerializeToString(ApiSpec.ApiResponse));
					break;

				case "dto":
					foreach ( SpecDto dto in ApiSpec.DtoList ) {
						if ( dto.Name.ToLower() != objNameLower ) { continue; }
						cont = (html ?
							ApiSpecBuilderHtml.BuildDtoHtml(dto, ApiSpec) :
							JsonSerializer.SerializeToString(dto));
					}
					break;

				case "fun":
					foreach ( SpecFunc func in ApiSpec.FunctionList ) {
						if ( func.Name.ToLower() != objNameLower ) { continue; }
						cont = (html ? 
							ApiSpecBuilderHtml.BuildFuncHtml(func, ApiSpec) :
							JsonSerializer.SerializeToString(func));
					}
					break;

				default:
					cont = (html ?
						ApiSpecBuilderHtml.BuildHtml(ApiSpec) :
						JsonSerializer.SerializeToString(ApiSpec));
					break;
			}

			if ( cont == null ) {
				statusCode = HttpStatusCode.NotFound;
				cont = "Item '"+objName+"' could not be found.";

				if ( !html ) {
					cont = "{\"error\": \""+cont+"\"}";
				}
			}

			byte[] bytes = Encoding.UTF8.GetBytes(cont);

			return new Response {
				ContentType = contType,
				StatusCode = statusCode,
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