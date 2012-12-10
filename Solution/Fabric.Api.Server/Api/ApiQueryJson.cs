using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Fabric.Api.Dto;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.Api {

	/*================================================================================================*/
	public class ApiQueryJson {

		private readonly GremlinRequest vRequest;
		private readonly Type vDtoType;
		private readonly FabResponse vResp;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiQueryJson(GremlinRequest pRequest, Type pDtoType, FabResponse pResponse) {
			vRequest = pRequest;
			vDtoType = pDtoType;
			vResp = pResponse;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Response BuildResponse() {
			var build = GetType()
				.GetMethod("BuildTypedJson", (BindingFlags.NonPublic | BindingFlags.Instance))
				.MakeGenericMethod(new[] { vDtoType });

			string dataJson = (string)build.Invoke(this, new object[] {});
			
			vResp.Data = "{DATA}";
			vResp.Size = dataJson.Length;
			vResp.Complete();

			string wrapJson = vResp.ToJson().Replace("\"{DATA}\"", dataJson);
			vResp.Data = dataJson;

			byte[] bytes = UTF8Encoding.UTF8.GetBytes(wrapJson);

			return new Response {
				ContentType = "application/json",
				StatusCode = HttpStatusCode.OK,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		private string BuildTypedJson<T>() where T : FabNode {
			if ( vRequest == null ) { return "{}"; }

			if ( vRequest.DtoList != null ) {
				var nodeList = new List<T>();
				var idMap = new HashSet<long>();

				foreach ( DbDto dbDto in vRequest.DtoList ) {
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

			if ( vRequest.Dto != null ) {
				T n = (T)Activator.CreateInstance(vDtoType);
				n.Fill(vRequest.Dto);
				++vResp.Count;
				return n.ToJson();
			}

			return "{\"Text\":\""+vRequest.ResponseString.Replace("\"", "\\\"")+"\"}";
		}

	}

}