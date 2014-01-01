﻿using System;
using System.Collections.Generic;
using System.Net;

namespace Fabric.New.Api.Interfaces {

	/*================================================================================================*/
	public interface IApiResponse {

		HttpStatusCode Status { get; set; }
		string Json { get; set; }
		string Html { get; set; }
		string RedirectUrl { get; set; }
		IDictionary<string, string> Headers { get; }
		IDictionary<string, string> Cookies { get; }
		bool IsError { get; set; }
		Exception Unhandled { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void StartTimer();

		/*--------------------------------------------------------------------------------------------*/
		void StopTimer();

		/*--------------------------------------------------------------------------------------------*/
		double GetTimerMilliseconds();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetJsonWith(object pObject);

		/*--------------------------------------------------------------------------------------------*/
		void SetUserCookie(long? pUserId, bool pRememberMe);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void LogResponse(IApiRequest pApiReq);

	}

}