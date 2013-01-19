﻿using System;
using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Server.Common;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Nancy;
using Weaver;

namespace Fabric.Api.Server.Api {

	/*================================================================================================*/
	public class ApiController : FabResponseController { //TEST: ApiController

		private readonly ApiModel vModel;
		private IFinalStep vLastStep;
		private IApiDataAccess vReq;
		private HttpStatusCode vStatus;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks) :
																base(pRequest, pApiCtx, pOauthTasks) {
			vStatus = HttpStatusCode.OK;
			vModel = new ApiModel();
			vModel.Resp = FabResp;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			FillQueryInfo();
			ExecuteOauthLookup();
			ExecuteQuery();
			BuildDtoList();
			return BuildViewResponse();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void FillQueryInfo() {
			FabResp.HttpStatus = (int)vStatus;
			FabResp.StartEvent();

			vLastStep = PathRouter.GetPath(PathRouter.NewRootStep(), ApiUri);
			FabResp.SetLinks(vLastStep.AvailableLinks);
			FabResp.Functions = vLastStep.AvailableFuncs.ToArray();
			vModel.Query = vLastStep.Path.Script;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ExecuteQuery() {
			if ( vLastStep.UseLocalData ) {
				return;
			}

			FabResp.DbStartEvent();

			var wq = new WeaverQuery();
			wq.FinalizeQuery(vModel.Query);
			vReq = ApiCtx.DbData("Api", wq);

			FabResp.DbEndEvent();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void BuildDtoList() {
			if ( vReq == null ) {
				return;
			}

			if ( vReq.ResultDtoList != null ) {
				int max = vLastStep.Count;
				int count = 0;
				vModel.DtoList = new List<IDbDto>();

				foreach ( DbDto dbDto in vReq.ResultDtoList ) {
					if ( count++ >= max ) { break; }
					vModel.DtoList.Add(dbDto);
					++FabResp.Count;
				}

				FabResp.StartIndex = vLastStep.Index;
				FabResp.HasMore = (vReq.ResultDtoList.Count > max);
				return;
			}

			vModel.NonDtoText = vReq.ResultString;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildExceptionResponse(Exception pEx) {
			vModel.Resp.IsError = true;
			vModel.Resp.Links = new FabStepLink[0];
			vModel.Resp.Functions = new string[0];
			vModel.Resp.StartIndex = 0;
			vModel.Resp.Count = 0;

			if ( pEx is StepException ) {
				ExceptionIsHandled();

				var se = (pEx as StepException);
				vModel.Error = se.ToFabError();
				vStatus = HttpStatusCode.BadRequest;

				/*switch ( step.ErrCode ) {
					case StepException.Code.IncorrectParamCount:
					case StepException.Code.IncorrectParamValue:
					case StepException.Code.IncorrectParamType:
						vStatus = HttpStatusCode.BadRequest;
						break;
				}*/
			}
			else {
				vModel.Error = FabError.ForInternalServerError();
				vStatus = HttpStatusCode.InternalServerError;
			}

			vModel.Resp.HttpStatus = (int)vStatus;
			return BuildViewResponse();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildViewResponse() {
			if ( NancyUtil.ShouldReturnHtml(NancyReq) ) {
				return NancyUtil.BuildHtmlResponse(vStatus, new ApiResponseHtml(vModel).GetContent());
			}
			
			return NancyUtil.BuildJsonResponse(vStatus, new ApiResponseJson(vModel).GetContent());
		}

	}

}