using System.Collections.Generic;
using System.Text;
using Fabric.New.Infrastructure.Broadcast;
using Nancy;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {
		
		private readonly IDictionary<ApiEntry.Method, RouteBuilder> vMethodMap;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModule() {
			Logger.ConfigureOnce();

			vMethodMap = new Dictionary<ApiEntry.Method, RouteBuilder>();
			vMethodMap.Add(ApiEntry.Method.Get, Get);
			vMethodMap.Add(ApiEntry.Method.Post, Post);
			vMethodMap.Add(ApiEntry.Method.Put, Put);
			vMethodMap.Add(ApiEntry.Method.Delete, Delete);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void SetupFromApiEntries(IEnumerable<ApiEntry> pEntries) {
			foreach ( ApiEntry e in pEntries ) {
				ApiEntry ee = e;
				vMethodMap[e.RequestMethod][e.Path] = (p => {
					IApiResponse resp = ee.Function(NewReq());

					//TODO: map resp.Status to Nancy status codes...
					return BuildResponse(HttpStatusCode.OK, resp.Json, "application/json"); //text/html
				});
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static IApiRequest NewReq() {
			return new ApiRequest(null, null);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response BuildResponse(HttpStatusCode pStatus, string pContent, string pType) {
			byte[] bytes = Encoding.UTF8.GetBytes(pContent);

			return new Response {
				ContentType = pType,
				StatusCode = pStatus,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

	}

}