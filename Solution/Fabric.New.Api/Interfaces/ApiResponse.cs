﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using ServiceStack.Text;

namespace Fabric.New.Api.Interfaces {

	/*================================================================================================*/
	public class ApiResponse : IApiResponse {

		public HttpStatusCode Status { get; set; }
		public string Html { get; set; }
		public string Json { get; set; }
		public string RedirectUrl { get; set; }
		public IDictionary<string, string> Headers { get; private set; }
		public IDictionary<string, string> Cookies { get; private set; }
		public bool IsError { get; set; }
		public Exception Unhandled { get; set; }

		private readonly Stopwatch vTimer;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiResponse() {
			Status = HttpStatusCode.OK;
			Headers = new Dictionary<string, string>();
			Cookies = new Dictionary<string, string>();
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