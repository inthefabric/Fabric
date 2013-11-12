using System;
using System.Net;

namespace Fabric.New.Infrastructure.Util {

	/*================================================================================================*/
	public static class AuthUtil {

		public const string FabricUserAuth = "FabricUserAuth";
		private const string EncryptKey = "Gu11iverIsMyD0gAuth";


		////////////////////////////////////////////////////////////////////////////////////////////////
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

		/*--------------------------------------------------------------------------------------------*/
		private static int TwoDigitRandom() {
			return (new Random()).Next(89)+10;
		}

	}

}