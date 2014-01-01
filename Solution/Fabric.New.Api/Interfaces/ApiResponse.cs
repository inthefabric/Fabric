using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Fabric.New.Infrastructure.Util;
using ServiceStack.Text;

namespace Fabric.New.Api.Interfaces {

	/*================================================================================================*/
	public class ApiResponse : IApiResponse {

		public HttpStatusCode Status { get; set; }
		public string Html { get; set; }
		public string Json { get; set; }
		public string RedirectUrl { get; set; }
		public IDictionary<string, string> Headers { get; private set; }
		public IList<Cookie> Cookies { get; private set; }
		public bool IsError { get; set; }
		public Exception Unhandled { get; set; }

		private readonly Stopwatch vTimer;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiResponse() {
			Status = HttpStatusCode.OK;
			Headers = new Dictionary<string, string>();
			Cookies = new List<Cookie>();
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

		/*--------------------------------------------------------------------------------------------*/
		public void SetUserCookie(long? pUserId, bool pRememberMe) {
			Tuple<Cookie, TimeSpan> pair = AuthUtil.CreateUserIdCookie(pUserId, pRememberMe);
			Cookie c = pair.Item1;
			c.Expires = DateTime.UtcNow.Add(pair.Item2);
			Cookies.Add(c);
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