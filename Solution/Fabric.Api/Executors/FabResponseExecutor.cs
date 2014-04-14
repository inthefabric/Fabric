using System;
using System.Collections.Generic;
using System.Net;
using Fabric.Api.Interfaces;
using Fabric.Api.Objects;
using Fabric.Infrastructure.Faults;

namespace Fabric.Api.Executors {

	/*================================================================================================*/
	public class FabResponseExecutor<T> : Executor where T : FabObject {

		public Func<Exception, FabError> OnException { get; set; }
		public Func<FabResponse<T>> NewFabResponse { get; set; }

		private readonly Func<IList<T>> vGetResponse;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabResponseExecutor(IApiRequest pReq, Func<IList<T>> pGetResponse) : base(pReq) {
			vGetResponse = pGetResponse;
			OnException = (e => (e is FabFault ? FabError.ForFault(e as FabFault) : null));
			NewFabResponse = (() => new FabResponse<T>());
		}

		/*--------------------------------------------------------------------------------------------*/
		public override IApiResponse Execute() {
			var resp = new ApiResponse();
			resp.Status = HttpStatusCode.OK;
			resp.StartTimer();

			try {
				ApiReq.OpCtx.Auth.ExecuteOauth();

				IList<T> list = vGetResponse();
				resp.StopTimer();

				FabResponse<T> fr = NewFabResponse();
				fr.Data = list;
				fr.TotalMs = resp.GetTimerMilliseconds();
				
				resp.SetJsonWith(fr);
			}
			catch ( Exception e ) {
				FabError err = OnException(e);
				resp.StopTimer();

				if ( err == null ) {
					OnUnhandledException(resp, e);
				}
				else {
					var fr = new FabResponse<FabObject>();
					fr.TotalMs = resp.GetTimerMilliseconds();
					fr.Error = err;
					resp.SetJsonWith(fr);
					resp.Status = (err.Code == (int)FabFault.Code.AuthorizationRequired ? 
						HttpStatusCode.Unauthorized : HttpStatusCode.BadRequest);
				}
			}

			resp.LogResponse(ApiReq);
			return resp;
		}

	}

}