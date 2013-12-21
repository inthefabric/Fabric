using System;
using System.Net;
using Fabric.New.Api.Interfaces;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class BasicExecutor<T> : Executor {

		public Func<Exception, string> OnException { get; set; }

		private readonly Func<T> vGetResponse;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BasicExecutor(IApiRequest pApiReq, Func<T> pGetResponse) : base(pApiReq) {
			vGetResponse = pGetResponse;
			OnException = (e => null);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override IApiResponse Execute() {
			var resp = new ApiResponse();
			resp.Status = HttpStatusCode.OK;
			resp.StartTimer();

			try {
				resp.SetJsonWith(vGetResponse());
			}
			catch ( Exception e ) {
				resp.Json = OnException(e);

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