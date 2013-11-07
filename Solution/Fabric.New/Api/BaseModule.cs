using System;
using System.Collections.Generic;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public abstract class BaseModule {

		protected IDictionary<string, Func<dynamic, object>> Get { get; set; }
		protected IDictionary<string, Func<dynamic, object>> Post { get; set; }
		protected IDictionary<string, Func<dynamic, object>> Put { get; set; }
		protected IDictionary<string, Func<dynamic, object>> Delete { get; set; }
		
		private readonly IDictionary<ApiEntry.Method, 
			IDictionary<string, Func<dynamic, object>>> vMethodMap;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModule() {
			vMethodMap = new Dictionary<ApiEntry.Method, IDictionary<string,Func<dynamic, object>>>();
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
				vMethodMap[e.RequestMethod].Add(e.Path, (p => ee.Function(NewReq())));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static IApiRequest NewReq() {
			return new ApiRequest(null, null);
		}

	}

}