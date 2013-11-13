using System;
using System.Net;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public abstract class Executor : IExecutor {

		protected IApiRequest ApiReq { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Executor(IApiRequest pApiReq) {
			ApiReq = pApiReq;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract IApiResponse Execute();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void OnUnhandledException(IApiResponse pResp, Exception pEx) {
			var fr = new FabResponse();
			fr.Error = FabError.ForInternalServerError();
			fr.TotalMs = pResp.GetTimerMilliseconds();

			pResp.SetJsonWith(fr);
			pResp.Status = HttpStatusCode.InternalServerError;
			pResp.Unhandled = pEx;
		}

	}

}