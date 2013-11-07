using System;
using System.Diagnostics;
using System.Net;
using ServiceStack.Text;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public class ApiResponse : IApiResponse {

		public HttpStatusCode Status { get; set; }
		public string Json { get; set; }
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
		public int GetTimerMilliseconds() {
			return (int)vTimer.Elapsed.TotalMilliseconds;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void SetJsonWith<T>(T pObject) {
			Json = JsonSerializer.SerializeToString(pObject);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LogResponse(IApiRequest pApiReq) {
			//do google analytics action
			//do graphite action
			//do log action
		}

	}

}