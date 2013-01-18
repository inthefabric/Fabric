using Fabric.Api.Oauth;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.Common {
	
	/*================================================================================================*/
	public static class ApiFuncBaseExt {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Response ToResponse<T>(this IApiFunc<T> pFunc) {
			try {
				T result = pFunc.Go(pFunc.Context);
				return NancyUtil.BuildJsonResponse(HttpStatusCode.OK, result.ToJson());
			}
			catch ( OauthException oe ) {
				return NancyUtil.BuildJsonResponse(HttpStatusCode.Forbidden, oe.OauthError.ToJson());
			}
		}

	}

}