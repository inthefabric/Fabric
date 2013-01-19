using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using Nancy.Cookies;
using ServiceStack.Text;

namespace Fabric.Api.Server.Util {

	/*================================================================================================*/
	public static class NancyUtil {

		private const string FabricUserAuth = "FabricUserAuth";
		private const string EncryptKey = "Gu11iverIsMyD0gAuth";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static long GetUserIdFromCookies(IDictionary<string, string> pCookies) {
			string c;
			pCookies.TryGetValue(FabricUserAuth, out c);

			if ( c == null || c == "0" ) {
				return 0;
			}

			string val = EncryptUtil.DecryptData(EncryptKey, Uri.UnescapeDataString(c));
			return long.Parse(val.Split('|')[1]);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetUserCookie(Response pRes, long? pUserId, bool pRemember) {
			DateTime now = DateTime.UtcNow;

			if ( pUserId == null ) {
				pRes.AddCookie(FabricUserAuth, "", now.AddDays(-1));
				return;
			}

			string val = TwoDigitRandom()+"|"+pUserId;
			string encVal = EncryptUtil.EncryptData(EncryptKey, val);
			DateTime expires = (pRemember ? now.AddDays(30) : now.AddMinutes(20));
			pRes.AddCookie(FabricUserAuth, encVal, expires);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static int TwoDigitRandom() {
			return (new Random()).Next(89)+10;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static NancyCookie NewUserCookieForTesting(long pUserId) {
			string val = TwoDigitRandom()+"|"+pUserId;
			string encVal = EncryptUtil.EncryptData(EncryptKey, val);
			return new NancyCookie(FabricUserAuth, encVal);
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

	}

}