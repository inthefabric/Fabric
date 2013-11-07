using System;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public class ApiEntry {

		public enum Method {
			Get = 1,
			Post,
			Put,
			Delete
		}

		public Method RequestMethod { get; set; }
		public string Path { get; set; }
		public Func<IApiRequest, object> Function { get; set; }
		public Type ResponseType { get; set; }
		public bool MemberAuth { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiEntry(Method pMeth, string pPath, Func<IApiRequest, object> pFunc,
															Type pRespType, bool pMemberAuth=false) {
			RequestMethod = pMeth;
			Path = pPath;
			Function = pFunc;
			ResponseType = pRespType;
			MemberAuth = pMemberAuth;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ApiEntry Post(string pPath, Func<IApiRequest, object> pFunc,
															Type pRespType, bool pMemberAuth=true) {
			return new ApiEntry(Method.Post, pPath, pFunc, pRespType);
		}

	}

}