﻿using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services.Views;
using Fabric.Api.Util;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class OauthController : FabResponseController { //TEST: OauthController

		public enum Route {
			Home
		}

		public static FabService ServiceDto { get; private set; }

		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthController(Request pRequest, IApiContext pApiCtx, IOauthTasks pTasks,
													Route pRoute) : base(pRequest, pApiCtx, pTasks) {
			vRoute = pRoute;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			FabResp.StartEvent();
			FabResp.HttpStatus = (int)HttpStatusCode.OK;

			if ( ServiceDto == null ) {
				ServiceDto = FabServices.NewOauthService(true);
			}

			string json = "";

			switch ( vRoute ) {
				case Route.Home:
					json = new HomeJsonView(FabResp, ServiceDto.ToJson()).GetContent();
					break;
			}

			ExecuteOauthLookup();
			return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, json);
		}

	}

}