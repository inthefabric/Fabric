using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Fabric.Infrastructure;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Util {

	/*================================================================================================*/
	public static class TestUtil {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static TEx CheckThrows<TEx>(bool pThrows, TestDelegate pFunc) where TEx : Exception {
			if ( pThrows ) {
				TEx e = (TEx)Assert.Throws(typeof(TEx), pFunc);
				Log.Info(e.Message);
				return e;
			}

			Assert.DoesNotThrow(pFunc);
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void CheckParam(IDictionary<string,string> pParams, string pKey, string pValue) {
			Assert.NotNull(pParams, "Query.Params should not be null.");
			Assert.True(pParams.ContainsKey(pKey), "Query.Params['"+pKey+"'] should be filled.");
			Assert.AreEqual(pValue, pParams[pKey], "Incorrect Query.Params['"+pKey+"'].");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static void LogWeaverScript(IWeaverScript pScripted) {
			string p = "";

			foreach ( string key in pScripted.Params.Keys ) {
				p += "\n\t"+key+" = "+pScripted.Params[key];
			}

			LogWeaverScript(pScripted.Script, p);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void LogWeaverScript(string pScript, string pParamOutput) {
			string script = pScript
				.Replace(".outE", "\n\t\t.outE")
				.Replace(".inE", "\n\t\t.inE")
				.Replace(".back", "\n\t\t.back")
				.Replace(";", ";\n\t");

			Log.Debug("Query:\n\n\t"+script+pParamOutput);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static NameValueCollection BuildQuery(string pQuery) {
			var q = new NameValueCollection();
			if ( string.IsNullOrEmpty(pQuery) ) { return q; }

			string[] pairs = pQuery.Split('&');

			foreach ( string pair in pairs ) {
				string[] nameVal = pair.Split('=');
				q.Add(nameVal[0], nameVal[1]);
			}

			return q;
		}

	}

}