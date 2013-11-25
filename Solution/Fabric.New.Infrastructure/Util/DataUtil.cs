using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Weaver.Core.Query;

namespace Fabric.New.Infrastructure.Util {

	/*================================================================================================*/
	public static class DataUtil {

		private const int SecPerMin = (60+1);
		private const int SecPerHour = SecPerMin*(60+1);
		private const int SecPerDay = SecPerHour*(24+1);
		private const int SecPerMonth = SecPerDay*(31+1);
		private const int SecPerYear = SecPerMonth*(12+1); //38,698,400 sec; +/- 238 billion years


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string JsonUnquote(string pText) {
			return pText.Replace("\"", "\\\"");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string Code32 { get { return Guid.NewGuid().ToString("N"); } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string HashPassword(string pPassword) {
			//var hash = new SHA512Managed(); //64 byte hash
			var hash = new MD5CryptoServiceProvider(); //16 byte hash
			byte[] bytes = hash.ComputeHash(Encoding.Unicode.GetBytes(pPassword));
			var sb = new StringBuilder();

			for ( int i = 0 ; i < 16 ; i++ ) {
				sb.Append(bytes[i].ToString("x2"));
			}

			return sb.ToString();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static long EventorTimesToLong(long pYear, byte? pMonth, byte? pDay, byte? pHour,
																		byte? pMinute, byte? pSecond) {
			long t = pYear*SecPerYear;

			if ( pMonth != null ) {
				t += (byte)pMonth*SecPerMonth; //do not add 1
			}

			if ( pDay != null ) {
				t += (byte)pDay*SecPerDay; //do not add 1
			}

			if ( pHour != null ) {
				t += ((byte)pHour+1)*SecPerHour;
			}

			if ( pMinute != null ) {
				t += ((byte)pMinute+1)*SecPerMin;
			}

			if ( pSecond != null ) {
				t += ((byte)pSecond+1);
			}

			return t;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void EventorLongToTimes(long pDateTime, out long pYear, out byte? pMonth,
								out byte? pDay, out byte? pHour, out byte? pMinute, out byte? pSecond) {
			long mod = pDateTime%SecPerYear;
			long dt = mod;

			pYear = (pDateTime-mod)/SecPerYear;
			pMonth = EventorExtractTime(dt, SecPerMonth, 0, out dt);
			pDay = EventorExtractTime(dt, SecPerDay, 0, out dt);
			pHour = EventorExtractTime(dt, SecPerHour, -1, out dt);
			pMinute = EventorExtractTime(dt, SecPerMin, -1, out dt);
			pSecond = (dt == 0 ? null : (byte?)(dt-1));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static byte? EventorExtractTime(long pDateTime, int pSecs, int pOffset,
																				out long pNewDateTime) {
			long mod = pDateTime%pSecs;
			pNewDateTime = mod;
			long diff = (pDateTime-mod);

			if ( diff == 0 ) {
				return null;
			}

			byte val = (byte)(diff/pSecs);
			return (byte?)(val+pOffset);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public static string WeaverQueryToJson(IWeaverQuery pQuery) {
			return ScriptAndParamsToJson(pQuery.Script, pQuery.Params);
		}

		/*--------------------------------------------------------------------------------------------* /
		private static string ScriptAndParamsToJson(string pScript,
														IDictionary<string, IWeaverQueryVal> pParams) {
			string json = "{\"script\":\""+JsonUnquote(pScript)+"\"";
			bool first = true;

			if ( pParams.Keys.Count == 0 ) {
				return json+"}";
			}

			json += ",\"params\":{";

			foreach ( string key in pParams.Keys ) {
				json += (first ? "" : ",")+"\""+JsonUnquote(key)+"\":\""+
					JsonUnquote(pParams[key].RawText)+"\"";
				first = false;
			}

			return json+"}}";
		}*/

	}

}