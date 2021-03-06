﻿using System;
using System.Collections.Generic;
using System.Net;

namespace Fabric.Infrastructure.Util {

	/*================================================================================================*/
	public static class AuthUtil { //TEST: AuthUtil

		private const string FabricUserAuth = "FabricUserAuth";
		private const string EncryptKey = "Gu11iverIsMyD0gAuth";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static long? GetUserIdFromCookies(IDictionary<string, string> pCookies) {
			string c;
			pCookies.TryGetValue(FabricUserAuth, out c);

			if ( c == null || c == "0" ) {
				return null;
			}

			return GetUserIdFromCookieString(Uri.UnescapeDataString(c));
		}

		/*--------------------------------------------------------------------------------------------*/
		public static long GetUserIdFromCookieString(string pCookieString) {
			string val = EncryptUtil.DecryptData(EncryptKey, pCookieString);
			return long.Parse(val.Split('|')[1]);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Tuple<Cookie, TimeSpan> CreateUserIdCookie(long? pUserId, bool pRemember) {
			Cookie cook;
			TimeSpan exp;

			if ( pUserId == null ) {
				cook = new Cookie(FabricUserAuth, "");
				exp = new TimeSpan(-1, 0, 0, 0);
			}
			else {
				string val = TwoDigitRandom()+"|"+pUserId;
				string encVal = EncryptUtil.EncryptData(EncryptKey, val);

				cook = new Cookie(FabricUserAuth, encVal);
				exp = (pRemember ? new TimeSpan(30, 0, 0, 0) : new TimeSpan(0, 0, 20, 0));
			}

			return new Tuple<Cookie, TimeSpan>(cook, exp);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static int TwoDigitRandom() {
			return (new Random()).Next(89)+10;
		}

	}

}