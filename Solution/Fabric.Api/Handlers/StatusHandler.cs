using Fabric.Api.Objects;
using Fabric.Infrastructure.Faults;
using Nancy;
using Nancy.ErrorHandling;
using Nancy.Responses;
using Nancy.Serializers.Json.ServiceStack;

namespace Fabric.Api.Handlers {

	/*================================================================================================*/
	public class StatusHandler : IStatusCodeHandler {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool HandlesStatusCode(HttpStatusCode pCode, NancyContext pContext) {
			return (pCode == HttpStatusCode.NotFound || pCode == HttpStatusCode.MethodNotAllowed);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Handle(HttpStatusCode pCode, NancyContext pContext) {
			var err = new FabError();
			err.Code = (int)FabFault.Code.HttpError;
			err.Name = FabFault.Code.HttpError+"";
			err.Message = pContext.Response.StatusCode+" ("+(int)pContext.Response.StatusCode+") "+
				"for API request: "+pContext.Request.Method+" "+pContext.Request.Path;

			var fr = new FabResponse();
			fr.Error = err;

			var jr = new JsonResponse(fr, new ServiceStackJsonSerializer());
			jr.StatusCode = pCode;
			pContext.Response = jr;
		}

	}

}