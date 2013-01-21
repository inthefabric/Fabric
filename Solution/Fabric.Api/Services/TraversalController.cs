using System;
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
using Weaver;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class TraversalController : FabResponseController { //TEST: TraversalController

		private readonly ApiModel vModel;
		private IFinalStep vLastStep;
		private IApiDataAccess vReq;
		private HttpStatusCode vStatus;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks) :
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
			FabResp.StartEvent();
			FabResp.HttpStatus = (int)vStatus;

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
				return NancyUtil.BuildHtmlResponse(vStatus, new ApiHtmlView(vModel).GetContent());
			}
			
			return NancyUtil.BuildJsonResponse(vStatus, new ApiJsonView(vModel).GetContent());
		}

	}

}