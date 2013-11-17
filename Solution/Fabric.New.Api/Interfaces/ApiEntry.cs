using System;
using System.Collections.Generic;

namespace Fabric.New.Api.Interfaces {

	/*================================================================================================*/
	public class ApiEntry {

		public enum Method {
			Get = 1,
			Post,
			Put,
			Delete
		}

		public Method RequestMethod { get; private set; }
		public string Path { get; private set; }
		public Func<IApiRequest, IApiResponse> Function { get; private set; }
		public Type ResponseType { get; private set; }
		public IList<ApiEntryParam> Params { get; private set; }
		public bool MemberAuth { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiEntry(Method pMeth, string pPath, Func<IApiRequest, IApiResponse> pFunc,
								Type pRespType, IList<ApiEntryParam> pParams, bool pMemberAuth=false) {
			RequestMethod = pMeth;
			Path = pPath;
			Function = pFunc;
			ResponseType = pRespType;
			Params = (pParams ?? new List<ApiEntryParam>());
			MemberAuth = pMemberAuth;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ApiEntry Get(string pPath, Func<IApiRequest, IApiResponse> pFunc,
															Type pRespType, bool pMemberAuth=false) {
			return new ApiEntry(Method.Get, pPath, pFunc, pRespType, null,pMemberAuth);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ApiEntry Post(string pPath, Func<IApiRequest, IApiResponse> pFunc,
								Type pRespType, IList<ApiEntryParam> pParams, bool pMemberAuth=true) {
			return new ApiEntry(Method.Post, pPath, pFunc, pRespType, pParams, pMemberAuth);
		}

	}

}