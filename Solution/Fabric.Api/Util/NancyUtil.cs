using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Fabric.Infrastructure.Api;
using Nancy;
using Nancy.Cookies;
using ServiceStack.Text;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace Fabric.Api.Util {

	/*================================================================================================*/
	public static class NancyUtil {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static long GetUserIdFromCookies(IDictionary<string, string> pCookies) {
			string c;
			pCookies.TryGetValue(AuthUtil.FabricUserAuth, out c);

			if ( c == null || c == "0" ) {
				return 0;
			}

			return AuthUtil.GetUserIdFromCookieString(Uri.UnescapeDataString(c));
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetUserCookie(Response pRes, long? pUserId, bool pRemember) {
			Tuple<Cookie, TimeSpan> pair = AuthUtil.CreateUserIdCookie(pUserId, pRemember);
			DateTime expires = DateTime.UtcNow.Add(pair.Item2);
			pRes.AddCookie(pair.Item1.Name, pair.Item1.Value, expires);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static NancyCookie NewUserCookieForTesting(long pUserId) {
			Tuple<Cookie, TimeSpan> pair = AuthUtil.CreateUserIdCookie(pUserId, false);
			return new NancyCookie(pair.Item1.Name, pair.Item1.Value);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetBearerToken(RequestHeaders pHeaders) {
			IEnumerable<string> authList = pHeaders["Authorization"];
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
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Response BuildJsonResponse<T>(HttpStatusCode pStatus, T pObject) {
			return BuildJsonResponse(pStatus, pObject.ToJson());
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Response BuildJsonResponse(HttpStatusCode pStatus, string pJson) {
			return BuildResponse(pStatus, pJson, "application/json");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Response BuildHtmlResponse(HttpStatusCode pStatus, string pHtml) {
			return BuildResponse(pStatus, pHtml, "text/html");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Response BuildResponse(HttpStatusCode pStatus, string pContent, string pType) {
			byte[] bytes = Encoding.UTF8.GetBytes(pContent);

			return new Response {
				ContentType = pType,
				StatusCode = pStatus,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		public static bool ShouldReturnHtml(Request pRequest) {
			var acc = pRequest.Headers.Accept;

			foreach ( var a in acc ) {
				if ( a.Item1 != "text/html" ) { continue; }
				return true;
			}

			return false;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Response Redirect(string pLocation) {
			var r = new Response();
			r.ContentType = "text/html";
			return Redirect(r, pLocation);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static Response Redirect(Response pResponse, string pLocation) {
			pResponse.StatusCode = HttpStatusCode.Found; //302
			pResponse.Headers.Add("Location", pLocation);
			return pResponse;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static HttpStatusCode ToNancyStatus(System.Net.HttpStatusCode pStatus) {
			switch ( pStatus ) {

				case System.Net.HttpStatusCode.OK:
					return HttpStatusCode.OK;

				case System.Net.HttpStatusCode.BadRequest:
					return HttpStatusCode.BadRequest;

				case System.Net.HttpStatusCode.InternalServerError:
					return HttpStatusCode.InternalServerError;

			}

			throw new Exception("Unmatched HttpStatusCode: "+pStatus+" ("+(int)pStatus+")");
		}

	}

}