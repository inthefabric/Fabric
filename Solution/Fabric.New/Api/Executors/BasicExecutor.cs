using System;
using System.Net;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public abstract class BasicExecutor<T> : Executor {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BasicExecutor(IApiRequest pApiReq) : base(pApiReq) {}

		/*--------------------------------------------------------------------------------------------*/
		public override IApiResponse Execute() {
			var resp = new ApiResponse();
			resp.Status = HttpStatusCode.OK;
			resp.StartTimer();

			try {
				resp.SetJsonWith(GetResponse());
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract T GetResponse();

		/*--------------------------------------------------------------------------------------------*/
		protected virtual string OnException(Exception pEx) {
			return null;
		}

	}

}