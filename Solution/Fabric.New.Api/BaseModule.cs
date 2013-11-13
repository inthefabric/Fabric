using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Infrastructure.Broadcast;
using Nancy;
using Nancy.Responses;
using Nancy.Serializers.Json.ServiceStack;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {
		
		private readonly IDictionary<ApiEntry.Method, RouteBuilder> vMethodMap;
		private readonly ServiceStackJsonSerializer JsonSerial = new ServiceStackJsonSerializer();
		

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
					IApiResponse r = ee.Function(NewReq());

					var tr = new TextResponse(r.Json, "application/json");
					tr.StatusCode = (HttpStatusCode)(int)r.Status;
					return tr;
				});
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static IApiRequest NewReq() {
			return new ApiRequest(null, null);
		}

	}

}