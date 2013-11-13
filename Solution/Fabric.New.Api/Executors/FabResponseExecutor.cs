using System;
using System.Collections.Generic;
using System.Net;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public abstract class FabResponseExecutor<T> : Executor where T : FabObject {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabResponseExecutor(IApiRequest pApiReq) : base(pApiReq) {}

		/*--------------------------------------------------------------------------------------------*/
		public override IApiResponse Execute() {
			var resp = new ApiResponse();
			resp.Status = HttpStatusCode.OK;
			resp.StartTimer();

			try {
				IList<T> list = GetResponse();
				resp.StopTimer();

				var fr = new FabResponse<T>(list);
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
					var fr = new FabResponse();
					fr.TotalMs = resp.GetTimerMilliseconds();
					fr.Error = err;
					resp.SetJsonWith(fr);
					resp.Status = HttpStatusCode.BadRequest;
				}
			}

			resp.LogResponse(ApiReq);
			return resp;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract IList<T> GetResponse();

		/*--------------------------------------------------------------------------------------------*/
		protected virtual FabError OnException(Exception pEx) {
			return (pEx is FabFault ? FabError.ForFault(pEx as FabFault) : null);
		}

	}

}