﻿using System;
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
	public class ApiQuery {

		private const string ApiBaseUri = "http://localhost:9000/api";

		private readonly NancyContext vContext;
		private readonly ApiQueryInfo vInfo;
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
				Log.Error("API", ex);
				return "error: "+ex.Message;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void FillQueryInfo() {
			vInfo.Resp = new FabResponse();
			vInfo.Resp.StartEvent();

			vUri = vContext.Request.Path.Substring(5);
			IStep step = PathRouter.GetPath(vUri);

			vInfo.Query = step.Path.Script;
			vInfo.DtoType = step.DtoType;
			vInfo.NodeAction = DoNodeAction;

			vInfo.Resp.BaseUri = ApiBaseUri;
			vInfo.Resp.RequestUri = (vUri.Length > 0 ? "/"+vUri : "");
			vInfo.Resp.AvailableUris = step.AvailableSteps;
			vInfo.Resp.Type = vInfo.DtoType.Name;

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
				var idMap = new HashSet<long>();
				vInfo.DtoList = new List<DbDto>();

				foreach ( DbDto dbDto in vReq.DtoList ) {
					if ( dbDto.Id != null ) {
						if ( idMap.Contains((long)dbDto.Id) ) {
							++vInfo.Resp.RemovedDups;
							continue;
						}

						idMap.Add((long)dbDto.Id);
					}

					vInfo.DtoList.Add(dbDto);
					++vInfo.Resp.Count;
				}

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
				StatusCode = HttpStatusCode.OK,
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

	}

}