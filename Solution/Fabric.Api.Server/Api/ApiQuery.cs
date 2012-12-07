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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiQuery(NancyContext pContext) {
			vContext = pContext;
			
			try {
				string uri = vContext.Request.Path.Substring(5);
				vQuery = PathRouter.GetPath(uri, out vDtoType).Script;
			}
			catch ( Exception e ) {
				Log.Error("fail", e);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response GetResponse() {
			try {
				var req = new GremlinRequest(vQuery);
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
			byte[] bytes = pReq.ResponseBytes;

			var build = GetType()
				.GetMethod("BuildJson", (BindingFlags.NonPublic | BindingFlags.Instance))
				.MakeGenericMethod(new[] { vDtoType });

			string json = (string)build.Invoke(this, new object[] { pReq });

			if ( json != null ) {
				bytes = UTF8Encoding.UTF8.GetBytes(json);
			}

			return new Response {
				ContentType = "application/json",
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildJson<T>(GremlinRequest pReq) where T : FabNode {
			string json = null;

			if ( pReq.DtoList != null ) {
				var nodeList = new List<T>();

				foreach ( DbDto dbDto in pReq.DtoList ) {
					T n = (T)Activator.CreateInstance(vDtoType);
					n.Fill(dbDto);
					nodeList.Add(n);
				}

				json = nodeList.ToJson();
			}
			else if ( pReq.Dto != null ) {
				T n = (T)Activator.CreateInstance(vDtoType);
				n.Fill(pReq.Dto);
				json = n.ToJson();
			}

			return json;
		}

	}

}