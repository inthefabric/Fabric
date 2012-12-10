using System;
using Fabric.Api.Dto;
using Fabric.Api.Paths;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api.Server.Api {

	/*================================================================================================*/
	public class ApiQuery {

		private readonly NancyContext vContext;
		private readonly string vQuery;
		private readonly Type vDtoType;
		private readonly FabResponse vResp;

		private bool vUseHtml;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiQuery(NancyContext pContext) {
			vResp = new FabResponse();
			vResp.StartEvent();
			vResp.BaseUri = "http://localhost:9000/api";

			vContext = pContext;
			CheckRequestAccept();
			
			try {
				string uri = vContext.Request.Path.Substring(5);
				vResp.RequestUri = (uri.Length > 0 ? "/"+uri : "");

				IPathBase pb = PathRouter.GetPath(uri);
				vQuery = pb.Path.Script;
				vDtoType = pb.DtoType;
				vResp.Type = vDtoType.Name;
				vResp.AvailableUris = pb.AvailablePaths;
			}
			catch ( Exception e ) {
				Log.Error("fail", e);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CheckRequestAccept() {
			foreach ( var a in vContext.Request.Headers.Accept ) {
				if ( a.Item1 != "text/html" ) { continue; }
				//if ( a.Item1 != "application/xml" ) { continue; }
				vUseHtml = true;
				break;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			try {
				var req = (vDtoType == typeof(FabRoot) ? null : new GremlinRequest(vQuery));
				vResp.DbEvent();

				if ( vUseHtml ) {
					var html = new ApiQueryHtml(req, vDtoType, vResp);
					return html.BuildResponse();
				}

				var json = new ApiQueryJson(req, vDtoType, vResp);
				return json.BuildResponse();
			}
			catch ( Exception ex ) {
				Log.Error("", ex);
				return "error: "+ex.Message+" / query: "+vQuery;
			}
		}

	}

}