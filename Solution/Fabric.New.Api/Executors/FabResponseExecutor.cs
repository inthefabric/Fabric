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
				HttpStatusCode stat;
				FabError err = OnException(e, out stat);
				
				resp.Status = stat;
				resp.StopTimer();

				if ( err == null ) {
					OnUnhandledException(resp, e);
				}
				else {
					var fr = new FabResponse();
					fr.TotalMs = resp.GetTimerMilliseconds();
					fr.Error = err;
					resp.SetJsonWith(fr);
				}
			}

			resp.LogResponse(ApiReq);
			return resp;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract IList<T> GetResponse();

		/*--------------------------------------------------------------------------------------------*/
		protected virtual FabError OnException(Exception pEx, out HttpStatusCode pStatus) {
			if ( pEx is FabFault ) {
				pStatus = HttpStatusCode.BadRequest;
				return FabError.ForFault(pEx as FabFault);
			}

			pStatus = HttpStatusCode.InternalServerError;
			return FabError.ForInternalServerError();
		}

	}

}