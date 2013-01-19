using System;
using System.Collections.Generic;
using System.Text;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Nancy;
using Weaver;

namespace Fabric.Api.Server.Api {

	/*================================================================================================*/
	public class ApiQuery { //TEST: ApiQuery

		private const string ApiBaseUri = "http://localhost:9000/api";

		private readonly NancyContext vNanCtx;
		private readonly IApiContext vApiCtx;
		private readonly IOauthTasks vOauthTasks;
		private readonly ApiQueryInfo vInfo;
		private IFinalStep vLastStep;
		private string vUri;
		private IApiDataAccess vReq;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiQuery(NancyContext pNanCtx, IApiContext pApiCtx, IOauthTasks pOauthTasks) {
			vNanCtx = pNanCtx;
			vApiCtx = pApiCtx;
			vOauthTasks = pOauthTasks;
			vInfo = new ApiQueryInfo();
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			Response r;

			try {
				FillQueryInfo();
				ExecuteOauthLookup();
				ExecuteQuery();
				BuildDtoList();
				r = BuildResponse();
			}
			catch ( Exception ex ) {
				r = GetExceptionResponse(ex);
			}

			LogAction();
			return r;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void FillQueryInfo() {
			vInfo.HttpStatus = HttpStatusCode.OK;
			vInfo.NodeAction = DoNodeAction;

			vInfo.Resp = new FabResponse();
			vInfo.Resp.StartEvent();
			vInfo.Resp.HttpStatus = (int)vInfo.HttpStatus;

			vUri = vNanCtx.Request.Path.Substring(5); //removes "/api/"

			vInfo.Resp.BaseUri = ApiBaseUri;
			vInfo.Resp.RequestUri = (vUri.Length > 0 ? "/"+vUri : "");

			vLastStep = PathRouter.GetPath(PathRouter.NewRootStep(), vUri);

			vInfo.DtoType = vLastStep.DtoType;
			vInfo.Resp.SetLinks(vLastStep.AvailableLinks);
			vInfo.Resp.Functions = vLastStep.AvailableFuncs.ToArray();
			vInfo.Query = vLastStep.Path.Script;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ExecuteOauthLookup() {
			if ( vUri.Length >= 5 && vUri.Substring(0,5).ToLower() == "oauth" ) {
				return; //skip when performing an OAuth function
			}

			string token = NancyUtil.GetBearerToken(vNanCtx.Request.Headers);

			if ( token == null ) {
				return;
			}

			FabOauthAccess acc = vOauthTasks.GetAccessToken(token, vApiCtx);

			if ( acc == null ) {
				return;
			}

			vApiCtx.SetAppUserId(acc.AppId, acc.UserId);
			vInfo.Resp.AppId = vApiCtx.AppId;
			vInfo.Resp.UserId = vApiCtx.UserId;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ExecuteQuery() {
			if ( vLastStep.UseLocalData ) {
				return;
			}

			vInfo.Resp.DbStartEvent();

			var wq = new WeaverQuery();
			wq.FinalizeQuery(vInfo.Query);
			vReq = vApiCtx.DbData("Api", wq);

			vInfo.Resp.DbEndEvent();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void BuildDtoList() {
			if ( vReq == null ) {
				return;
			}

			if ( vReq.ResultDtoList != null ) {
				int max = vLastStep.Count;
				int count = 0;
				vInfo.DtoList = new List<IDbDto>();

				foreach ( DbDto dbDto in vReq.ResultDtoList ) {
					if ( count++ >= max ) { break; }
					vInfo.DtoList.Add(dbDto);
					CheckDtoType(dbDto);
					++vInfo.Resp.Count;
				}

				vInfo.Resp.StartIndex = vLastStep.Index;
				vInfo.Resp.HasMore = (vReq.ResultDtoList.Count > max);
				return;
			}

			vInfo.NonDtoText = vReq.ResultString;
		}
		

		/*--------------------------------------------------------------------------------------------*/
		private void CheckDtoType(IDbDto pDbDto) {
			if ( vInfo.DtoType.Name == "Fab"+pDbDto.Class ) {
				return;
			}

			throw new Exception("Incorrect DbDto.Class '"+pDbDto.Class+"', expected match for "+
				"DtoType '"+vInfo.DtoType.Name+"'.");
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

			byte[] bytes = Encoding.UTF8.GetBytes(cont);

			return new Response {
				ContentType = contType,
				StatusCode = vInfo.HttpStatus,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		private bool ShouldReturnHtml() {
			var acc = vNanCtx.Request.Headers.Accept;

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
			vInfo.Resp.Links = new FabStepLink[0];
			vInfo.Resp.Functions = new string[0];
			vInfo.Resp.StartIndex = 0;
			vInfo.Resp.Count = 0;

			if ( pEx is StepException ) {
				var se = (pEx as StepException);
				vInfo.Error = se.ToFabError();
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
				Log.Error("API Unhandled Exception", pEx);
				vInfo.Error = FabError.ForInternalServerError();
				vInfo.HttpStatus = HttpStatusCode.InternalServerError;
			}

			vInfo.Resp.HttpStatus = (int)vInfo.HttpStatus;
			return BuildResponse();
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void LogAction() {
			//REQv1: 
			//	ip, QueryCount, DbMs, TotalMs, DataLen, StartIndex, Count, HasMore,
			//		AppId, UserId, Timestamp, HttpStatus, IsError, method, path

			Request nr = vNanCtx.Request;
			FabResponse fr = vInfo.Resp;
			const string x = " | ";

			string v1 =
				nr.UserHostAddress +x+
				vApiCtx.DbQueryExecutionCount +x+
				fr.DbMs +x+
				fr.TotalMs +x+
				fr.DataLen +x+
				fr.StartIndex +x+
				fr.Count +x+
				fr.HasMore +x+
				fr.AppId +x+
				fr.UserId +x+
				fr.Timestamp +x+
				fr.HttpStatus +x+
				fr.IsError +x+
				nr.Method +x+
				vUri;

			Log.Info(vApiCtx.ContextId, "APIv1", v1);
		}

	}

}