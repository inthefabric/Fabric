using System;
using System.Net;
using Fabric.New.Api.Interfaces;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class BasicExecutor<T> : Executor {

		public Func<IApiRequest, IApiResponse, Exception, bool> OnException { get; set; }
		public bool SkipJson { get; set; }
		public T Result { get; private set; }

		private readonly Func<T> vGetResponse;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BasicExecutor(IApiRequest pApiReq, Func<T> pGetResponse) : base(pApiReq) {
			vGetResponse = pGetResponse;
			OnException = ((req, resp ,ex) => false);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override IApiResponse Execute() {
			var resp = new ApiResponse();
			resp.Status = HttpStatusCode.OK;
			resp.StartTimer();

			try {
				Result = vGetResponse();

				if ( !SkipJson ) {
					resp.SetJsonWith(Result);
				}
			}
			catch ( Exception e ) {
				if ( !OnException(ApiReq, resp, e) ) {
					OnUnhandledException(resp, e);
				}
			}

			resp.StopTimer();
			resp.LogResponse(ApiReq);
			return resp;
		}

	}

}