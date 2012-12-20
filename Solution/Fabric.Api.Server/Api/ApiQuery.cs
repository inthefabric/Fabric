using System;
using System.Collections.Generic;
using System.Text;
using Fabric.Api.Dto;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api.Server.Api {

	/*================================================================================================*/
	public class ApiQuery {  //TEST: ApiQuery

		private const string ApiBaseUri = "http://localhost:9000/api";

		private readonly NancyContext vContext;
		private readonly ApiQueryInfo vInfo;
		private IFinalStep vLastStep;
		private string vUri;
		private GremlinRequest vReq;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiQuery(NancyContext pContext) {
			vContext = pContext;
			vInfo = new ApiQueryInfo();
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			try {
				FillQueryInfo();
				BuildDtoList();
				return BuildResponse();
			}
			catch ( Exception ex ) {
				return GetExceptionResponse(ex);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void FillQueryInfo() {
			vInfo.HttpStatus = HttpStatusCode.OK;
			vInfo.NodeAction = DoNodeAction;

			vInfo.Resp = new FabResponse();
			vInfo.Resp.StartEvent();
			vInfo.Resp.HttpStatus = (int)vInfo.HttpStatus;

			vUri = vContext.Request.Path.Substring(5);

			vInfo.Resp.BaseUri = ApiBaseUri;
			vInfo.Resp.RequestUri = (vUri.Length > 0 ? "/"+vUri : "");

			vLastStep = PathRouter.GetPath(PathRouter.NewRootStep(), vUri);

			vInfo.DtoType = vLastStep.DtoType;
			vInfo.Resp.Links = vLastStep.AvailableLinks.ToArray();
			vInfo.Resp.Functions = vLastStep.AvailableFuncs.ToArray();
			vInfo.Resp.Type = vInfo.DtoType.Name;
			vInfo.Query = vLastStep.Path.Script;

			if ( vInfo.DtoType != typeof(FabRoot) ) {
				vReq = new GremlinRequest(vInfo.Query);
			}

			vInfo.Resp.DbEvent();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void BuildDtoList() {
			if ( vReq == null ) {
				return;
			}

			if ( vReq.DtoList != null ) {
				int max = vLastStep.Count;
				int count = 0;
				vInfo.DtoList = new List<DbDto>();

				foreach ( DbDto dbDto in vReq.DtoList ) {
					if ( count++ >= max ) { break; }
					vInfo.DtoList.Add(dbDto);
					++vInfo.Resp.Count;
				}

				vInfo.Resp.StartIndex = vLastStep.Index;
				vInfo.Resp.HasMore = (vReq.DtoList.Count > max);
				return;
			}
			
			if ( vReq.Dto != null ) {
				vInfo.DtoList = new List<DbDto>();
				vInfo.DtoList.Add(vReq.Dto);
				vInfo.IsSingleDto = true;
				return;
			}
			
			vInfo.NonDtoText = vReq.ResponseString;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildResponse() {
			string cont;
			string contType;

			if ( ShouldReturnHtml() ) {
				cont = new ApiResponseHtml(vInfo).GetContent();
				contType = "text/html";
			}
			else {
				cont = new ApiResponseJson(vInfo).GetContent();
				contType = "application/json";
			}

			byte[] bytes = UTF8Encoding.UTF8.GetBytes(cont);

			return new Response {
				ContentType = contType,
				StatusCode = vInfo.HttpStatus,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		private bool ShouldReturnHtml() {
			var acc = vContext.Request.Headers.Accept;

			foreach ( var a in acc ) {
				if ( a.Item1 != "text/html" ) { continue; }
				return true;
			}

			return false;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void DoNodeAction(IFabNode pNode) {
			//nothing yet...
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response GetExceptionResponse(Exception pEx) {
			vInfo.Resp.IsError = true;
			vInfo.Resp.Links = new string[0];
			vInfo.Resp.Functions = new string[0];
			vInfo.Resp.StartIndex = 0;
			vInfo.Resp.Count = 0;

			if ( pEx is StepException ) {
				var step = (pEx as StepException);
				vInfo.Error = step.ToFabError();
				vInfo.HttpStatus = HttpStatusCode.BadRequest;

				/*switch ( step.ErrCode ) {
					case StepException.Code.IncorrectParamCount:
					case StepException.Code.IncorrectParamValue:
					case StepException.Code.IncorrectParamType:
						vInfo.HttpStatus = HttpStatusCode.BadRequest;
						break;
				}*/
			}
			else {
				Log.Error("API Exception", pEx);

				vInfo.Error = new FabError();
				vInfo.Error.Code = 0;
				vInfo.Error.CodeName = "InternalError";
				vInfo.Error.Type = typeof(Exception).Name;
				vInfo.Error.Message = "An internal server error occurred.";
				vInfo.HttpStatus = HttpStatusCode.InternalServerError;
			}

			vInfo.Resp.HttpStatus = (int)vInfo.HttpStatus;
			return BuildResponse();
		}

	}

}