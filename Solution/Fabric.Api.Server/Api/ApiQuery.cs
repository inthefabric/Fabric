using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Fabric.Api.Dto;
using Fabric.Api.Paths;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.Api {

	/*================================================================================================*/
	public class ApiQuery {

		private readonly NancyContext vContext;
		private readonly string vQuery;
		private readonly Type vDtoType;
		private readonly FabResponse vResp;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiQuery(NancyContext pContext) {
			vResp = new FabResponse();
			vResp.StartEvent();

			vContext = pContext;
			
			try {
				string uri = vContext.Request.Path.Substring(5);
				vQuery = PathRouter.GetPath(uri, out vDtoType).Script;
				vResp.Type = vDtoType.Name;
			}
			catch ( Exception e ) {
				Log.Error("fail", e);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			try {
				var req = new GremlinRequest(vQuery);
				vResp.DbEvent();
				return BuildJsonResponse(req);
			}
			catch ( Exception ex ) {
				Log.Error("", ex);
				return "error: "+ex.Message;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response BuildJsonResponse(GremlinRequest pReq) {
			var build = GetType()
				.GetMethod("BuildJson", (BindingFlags.NonPublic | BindingFlags.Instance))
				.MakeGenericMethod(new[] { vDtoType });

			string dataJson = (string)build.Invoke(this, new object[] { pReq });
			int count = (pReq.DtoList != null ? pReq.DtoList.Count : (pReq.Dto != null ? 1 : 0));
			string wrapJson = vResp.Complete(dataJson);
			byte[] bytes = UTF8Encoding.UTF8.GetBytes(wrapJson);

			return new Response {
				ContentType = "application/json",
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildJson<T>(GremlinRequest pReq) where T : FabNode {
			if ( pReq.DtoList != null ) {
				var nodeList = new List<T>();
				var idMap = new HashSet<long>();

				foreach ( DbDto dbDto in pReq.DtoList ) {
					if ( dbDto.Id != null ) {
						if ( idMap.Contains((long)dbDto.Id) ) {
							++vResp.RemovedDups;
							continue;
						}

						idMap.Add((long)dbDto.Id);
					}

					T n = (T)Activator.CreateInstance(vDtoType);
					n.Fill(dbDto);
					nodeList.Add(n);
					++vResp.Count;
				}

				return nodeList.ToJson();
			}
			
			if ( pReq.Dto != null ) {
				T n = (T)Activator.CreateInstance(vDtoType);
				n.Fill(pReq.Dto);
				++vResp.Count;
				return n.ToJson();
			}

			return "{\"Text\":\""+pReq.ResponseString.Replace("\"", "\\\"")+"\"}";
		}

	}

}