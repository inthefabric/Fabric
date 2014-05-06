using System;
using System.Net;
using Fabric.Api.Interfaces;

namespace Fabric.Api.Executors {

	/*================================================================================================*/
	public class CustomExecutor : Executor {

		private readonly Action<IApiResponse> vBuildResponse;
		private readonly Func<IApiRequest, IApiResponse, Exception, bool> vOnException;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CustomExecutor(IApiRequest pApiReq, Action<IApiResponse> pBuildResponse,
						Func<IApiRequest, IApiResponse, Exception, bool> pOnException) : base(pApiReq) {
			vBuildResponse = pBuildResponse;
			vOnException = pOnException;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override IApiResponse Execute() {
			var resp = new ApiResponse();
			resp.Status = HttpStatusCode.OK;
			resp.StartTimer();

			try {
				ApiReq.OpCtx.Auth.ExecuteOauth();
				vBuildResponse(resp);
			}
			catch ( Exception e ) {
				if ( !vOnException(ApiReq, resp, e) ) {
					OnUnhandledException(resp, e);
				}
			}

			resp.StopTimer();
			resp.LogResponse(ApiReq);
			return resp;
		}

	}

}