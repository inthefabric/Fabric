using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;
using Nancy;
using Nancy.ErrorHandling;
using Nancy.Responses;
using Nancy.Serializers.Json.ServiceStack;

namespace Fabric.New.Api.Handlers {

	/*================================================================================================*/
	public class Status404 : IStatusCodeHandler {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool HandlesStatusCode(HttpStatusCode pCode, NancyContext pContext) {
			return (pCode == HttpStatusCode.NotFound);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Handle(HttpStatusCode pCode, NancyContext pContext) {
			var err = new FabError();
			err.Code = (int)FabFault.Code.RequestNotFound;
			err.Name = FabFault.Code.RequestNotFound+"";
			err.Message = "Unknown API request: "+pContext.Request.Path;

			var fr = new FabResponse();
			fr.Error = err;

			var jr = new JsonResponse(fr, new ServiceStackJsonSerializer());
			jr.StatusCode = pCode;
			pContext.Response = jr;
		}

	}

}