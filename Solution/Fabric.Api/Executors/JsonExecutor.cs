using System;
using System.Net;
using Fabric.Api.Interfaces;

namespace Fabric.Api.Executors {

	/*================================================================================================*/
	public class JsonExecutor<T> : Executor {

		public Func<IApiRequest, IApiResponse, Exception, string> OnException { get; set; }

		private readonly Func<T> vGetResponse;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public JsonExecutor(IApiRequest pApiReq, Func<T> pGetResponse) : base(pApiReq) {
			vGetResponse = pGetResponse;
			OnException = ((req, resp ,ex) => null);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override IApiResponse Execute() {
			var resp = new ApiResponse();
			resp.Status = HttpStatusCode.OK;
			resp.StartTimer();

			try {
				ApiReq.OpCtx.Auth.ExecuteOauth();
				resp.SetJsonWith(vGetResponse());
			}
			catch ( Exception e ) {
				resp.Json = OnException(ApiReq, resp, e);

				if ( resp.Json == null ) {
					OnUnhandledException(resp, e);
				}
			}

			resp.StopTimer();
			resp.LogResponse(ApiReq);
			return resp;
		}

	}

}