using System;
using System.Diagnostics;
using System.Net;
using ServiceStack.Text;

namespace Fabric.New.Api.Interfaces {

	/*================================================================================================*/
	public class ApiResponse : IApiResponse {

		public HttpStatusCode Status { get; set; }
		public string Json { get; set; }
		public string RedirectUrl { get; set; }
		public bool IsError { get; set; }
		public Exception Unhandled { get; set; }

		private readonly Stopwatch vTimer;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiResponse() {
			vTimer = new Stopwatch();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void StartTimer() {
			vTimer.Start();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void StopTimer() {
			vTimer.Stop();
		}

		/*--------------------------------------------------------------------------------------------*/
		public double GetTimerMilliseconds() {
			return vTimer.Elapsed.TotalMilliseconds;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void SetJsonWith(object pObject) {
			Json = (pObject == null ? "" : pObject.ToJson());
			//JsonSerializer.SerializeToString(pObject);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LogResponse(IApiRequest pApiReq) {
			//TODO: google analytics action
			//TODO: graphite action
			//TODO: log action
		}

	}

}