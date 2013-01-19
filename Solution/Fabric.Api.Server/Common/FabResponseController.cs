using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server.Common {

	/*================================================================================================*/
	public abstract class FabResponseController : Controller {

		private const string ApiBaseUri = "http://localhost:9000";

		protected FabResponse FabResp { get; private set; }
		protected IOauthTasks OauthTasks { get; private set; }
		protected string ApiUri { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabResponseController(Request pRequest, IApiContext pApiContext, 
												IOauthTasks pOauthTasks) : base(pRequest, pApiContext) {
			FabResp = new FabResponse();
			OauthTasks = pOauthTasks;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override sealed Response BuildResponse() {
			ApiUri = NancyReq.Path.Substring(1); //remove "/"

			FabResp.BaseUri = ApiBaseUri;
			FabResp.RequestUri = (ApiUri.Length > 0 ? "/"+ApiUri : "");

			return BuildFabResponse();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract Response BuildFabResponse();


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
		protected override void LogAction() {
			//FRv1: (FabResponse log, version 1)
			//	Class, ip, QueryCount, DbMs, TotalMs, DataLen, StartIndex, Count, HasMore,
			//		AppId, UserId, Timestamp, HttpStatus, IsError, method, path, Exception

			const string name = "FRv1";
			const string x = " | ";

			string v1 =
				GetType().Name +x+
				NancyReq.UserHostAddress +x+
				ApiCtx.DbQueryExecutionCount +x+
				FabResp.DbMs +x+
				FabResp.TotalMs +x+
				FabResp.DataLen +x+
				FabResp.StartIndex +x+
				FabResp.Count +x+
				FabResp.HasMore +x+
				FabResp.AppId +x+
				FabResp.UserId +x+
				FabResp.Timestamp +x+
				FabResp.HttpStatus +x+
				FabResp.IsError +x+
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