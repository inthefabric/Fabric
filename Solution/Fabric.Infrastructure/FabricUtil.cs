using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Fabric.Infrastructure {

	/*================================================================================================*/
	public static class FabricUtil {
		
		//When converted to strings, these reduced bounds won't cause Java/Gremlin overflow issues
		public const double DoubleMin = double.MinValue+1E+294;
		public const double DoubleMax = double.MaxValue-1E+294;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string ScriptAndParamsToJson(string pScript, Dictionary<string,string> pParams) {
			string json = "{\"script\":\""+JsonUnquote(pScript)+"\",\"params\":{";
			bool first = true;

			foreach ( string key in pParams.Keys ) {
				json += (first ? "" : ",")+"\""+JsonUnquote(key)+"\":\""+
					JsonUnquote(pParams[key])+"\"";
				first = false;
			}

			return json+"}}";
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string JsonUnquote(string pText) {
			return pText.Replace("\"", "\\\"");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string Code32 { get { return Guid.NewGuid().ToString("N"); } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		// Authentication
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
		
	}

}