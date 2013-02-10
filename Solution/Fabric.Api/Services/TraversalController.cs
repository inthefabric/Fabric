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
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Nancy;
using ServiceStack.Text;
using Weaver;
using Fabric.Api.Traversal.Operations;
using Fabric.Api.Traversal.Tasks;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class TraversalController : FabResponseController {

		public enum Route {
			Home,
			Root,
			CurrApp,
			CurrUser,
			CurrMember
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
				ServiceDto = FabHome.NewTraversalService(true);
				ServiceDtoJson = ServiceDto.ToJson();
				TravRootUriLength = (FabHome.TravUri+FabHome.TravRootUri).Length;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			switch ( vRoute ) {
				case Route.Home: return BuildHomeResponse();
				case Route.Root: return BuildRootResponse();
				case Route.CurrApp:
				case Route.CurrUser:
				case Route.CurrMember:
					return BuildCurrResponse();
			}

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildHomeResponse() {
			return NewResponse(new FabRespJsonView(FabResp, ServiceDtoJson));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response BuildRootResponse() {
			FillQueryInfo();
			ExecuteQuery();
			BuildDtoList();
			return BuildViewResponse();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected Response BuildCurrResponse() {
			var tasks = new TraversalTasks();
			string json = null;
			
			switch ( vRoute ) {
				case Route.CurrApp:
					var a = new GetActiveApp(tasks);
					json = a.Go(ApiCtx).ToJson();
					break;
					
				case Route.CurrUser:
					var u = new GetActiveUser(tasks);
					json = u.Go(ApiCtx).ToJson();
					break;
					
				case Route.CurrMember:
					var m = new GetActiveMember(tasks);
					json = m.Go(ApiCtx).ToJson();
					break;
			}
			
			return NewResponse(new FabRespJsonView(FabResp, json));
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

			if ( pEx is FabFault ) {
				ExceptionIsHandled();
				vModel.Error = FabError.ForFault(pEx as FabFault);
				vStatus = HttpStatusCode.BadRequest;
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