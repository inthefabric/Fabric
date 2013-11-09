using System.Collections.Generic;
using Fabric.New.Operations;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public class ApiRequest : IApiRequest {

		public IOperationContext OpCtx { get; private set; }
		public string Method { get; private set; }
		public string Path { get; private set; }
		public string IpAddress { get; private set; }

		private readonly object vNancyReq;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiRequest(IOperationContext pOpCtx, object pNancyReq) {
			OpCtx = pOpCtx;
			vNancyReq = pNancyReq;

			//Method = vNancyReq.Method;
			//Path = vNancyReq.Path;
			//IpAddress = vNancyReq.UserHostAddress;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string GetQueryValue(string pName) {
			//return vNancyReq.Form[pName];
			return null;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public string GetFormValue(string pName) {
			//return vNancyReq.Form[pName];
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IEnumerable<string> GetHeader(string pName) {
			//return vNancyReq.Headers[pName];
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetBearerToken() {
			IEnumerable<string> authList = GetHeader("Authorization");
			string token = null;

			foreach ( string auth in authList ) {
				if ( auth.Substring(0, 7) != "Bearer " ) {
					continue;
				}

				token = auth.Substring(7); //removes "Bearer " (with space)
			}

			if ( string.IsNullOrEmpty(token) || token.Length != 32 ) {
				return null;
			}

			return token;
		}

	}

}