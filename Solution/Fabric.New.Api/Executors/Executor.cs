using System;
using System.Net;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Broadcast;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public abstract class Executor : IExecutor {
		
		private static readonly Logger Log = Logger.Build<Executor>();

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

			Log.Fatal("Unhandled exception: "+pEx.Message, pEx);
		}

	}

}