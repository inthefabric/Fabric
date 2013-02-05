﻿using System;
using System.Collections.Generic;
using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services.Models;
using Fabric.Api.Services.Views;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Util;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Nancy;
using ServiceStack.Text;
using Weaver;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class TraversalController : FabResponseController { //TEST: TraversalController

		public enum Route {
			Home,
			Root
		}

		private static FabService ServiceDto;
		private static string ServiceDtoJson;
		private static int TravRootUriLength;

		private readonly Route vRoute;
		private readonly TraversalModel vModel;

		private IFinalStep vLastStep;
		private IApiDataAccess vReq;
		private HttpStatusCode vStatus;
		private string vApiUri;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks,
												Route pRoute) : base(pRequest, pApiCtx, pOauthTasks) {
			vRoute = pRoute;
			vStatus = HttpStatusCode.OK;
			vModel = new TraversalModel();
			vModel.Resp = FabResp;

			if ( ServiceDto == null ) {
				ServiceDto = FabServices.NewTraversalService(true);
				ServiceDtoJson = ServiceDto.ToJson();
				TravRootUriLength = (FabServices.TravUri+FabServices.TravRootUri).Length;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			switch ( vRoute ) {
				case Route.Home: return BuildHomeResponse();
				case Route.Root: return BuildRootResponse();
			}

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildHomeResponse() {
			return NewResponse(new FabRespJsonView(FabResp, ServiceDtoJson));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildRootResponse() {
			FillQueryInfo();
			ExecuteQuery();
			BuildDtoList();
			return BuildViewResponse();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void FillQueryInfo() {
			vApiUri = NancyReq.Path.Substring(TravRootUriLength);
			
			if ( vApiUri.Length > 0 ) {
				vApiUri = vApiUri.Substring(1); //remove "/"
			}

			vLastStep = PathRouter.GetPath(PathRouter.NewRootStep(), vApiUri);
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
				return NancyUtil.BuildHtmlResponse(vStatus, new TraversalHtmlView(vModel).GetContent());
			}
			
			return NancyUtil.BuildJsonResponse(vStatus, new TraversalJsonView(vModel).GetContent());
		}

	}

}