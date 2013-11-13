﻿using System;
using System.Net;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public interface IApiResponse {

		HttpStatusCode Status { get; set; }
		string Json { get; set; }
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
		void SetJsonWith<T>(T pObject);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void LogResponse(IApiRequest pApiReq);

	}

}