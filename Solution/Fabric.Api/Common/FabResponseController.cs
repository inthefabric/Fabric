using System;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services.Views;
using Fabric.Api.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Nancy;

namespace Fabric.Api.Common {

	/*================================================================================================*/
	public abstract class FabResponseController : Controller {

		protected FabResponse FabResp { get; private set; }
		protected IOauthTasks OauthTasks { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabResponseController(Request pRequest, IApiContext pApiContext, 
												IOauthTasks pOauthTasks) : base(pRequest, pApiContext) {
			FabResp = new FabResponse();
			OauthTasks = pOauthTasks;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override sealed Response BuildResponse() {
			FabResp.StartEvent();
			FabResp.HttpStatus = (int)HttpStatusCode.OK;
			FabResp.BaseUri = BaseModule.ApiUrl;
			FabResp.RequestUri = NancyReq.Path;
			ExecuteOauthLookup();
			return BuildFabResponse();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract Response BuildFabResponse();

		/*--------------------------------------------------------------------------------------------*/
		protected Response NewResponse(IView pView) {
			return NancyUtil.BuildJsonResponse((HttpStatusCode)FabResp.HttpStatus, pView.GetContent());
		}

		/*--------------------------------------------------------------------------------------------*/
		protected Response NewFabJsonResponse(string pJson) {
			return NewResponse(new FabRespJsonView(ApiCtx, FabResp, pJson));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void ExecuteOauthLookup() {
			string token = NancyUtil.GetBearerToken(NancyReq.Headers);

			if ( token == null ) {
				return;
			}

			FabOauthAccess acc = OauthTasks.GetAccessToken(token, ApiCtx);

			if ( acc == null ) {
				return;
			}

			ApiCtx.SetAppUserId(acc.AppId, acc.UserId);
			FabResp.AppId = ApiCtx.AppId;
			FabResp.UserId = ApiCtx.UserId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildExceptionResponse(Exception pEx) {
			FabResp.Links = null;
			FabResp.Functions = null;
			FabResp.StartIndex = 0;
			FabResp.Count = 0;

			if ( pEx is FabFault ) {
				ExceptionIsHandled();
				FabResp.Error = FabError.ForFault(pEx as FabFault);
			}
			else {
				FabResp.HttpStatus = (int)HttpStatusCode.InternalServerError;
				FabResp.Error = FabError.ForInternalServerError();
			}

			return NewFabJsonResponse(null);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void PreLogAction() {
			FabResp.DbMs = ApiCtx.DbQueryMillis;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void LogAction() {
			ApiCtx.Analytics.TrackRequest(NancyReq.Method, NancyReq.Path);

			string key = BuildGraphiteKey();
			RecordGraphite(key, FabResp.TotalMs, FabResp.DbMs);
			ApiCtx.Metrics.Counter(key+".fabresp", 1);
			ApiCtx.Metrics.Mean(key+".datalen", FabResp.DataLen);
			ApiCtx.Metrics.Mean(key+".items", FabResp.Count);

			//FRv1: (FabResponse log, version 1)
			//	Class, ip, QueryCount, TotalMs, DbMs, DataLen, StartIndex, Count, HasMore,
			//		AppId, UserId, Timestamp, HttpStatus, IsError, method, path, Exception

			const string name = "FRv1";
			const string x = " | ";

			string v1 =
				GetType().Name +x+
				NancyReq.UserHostAddress +x+
				ApiCtx.DbQueryExecutionCount +x+
				FabResp.TotalMs +x+
				FabResp.DbMs +x+
				FabResp.DataLen +x+
				FabResp.StartIndex +x+
				FabResp.Count +x+
				FabResp.HasMore +x+
				FabResp.AppId +x+
				FabResp.UserId +x+
				FabResp.Timestamp +x+
				FabResp.HttpStatus +x+
				(FabResp.Error != null ? FabResp.Error.Name : "OK") +x+
				NancyReq.Method +x+
				NancyReq.Path;

			if ( UnhandledException == null ) {
				Log.Info(ApiCtx.ContextId, name, v1);
			}
			else {
				Log.Error(ApiCtx.ContextId, name, v1, UnhandledException);
			}
		}

	}

}